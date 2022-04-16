using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Security.Cryptography.X509Certificates;

//https://www.pkcs11interop.net/
using Net.Pkcs11Interop.Common;
using Net.Pkcs11Interop.HighLevelAPI;

using SignLib.Certificates;
using SignLib.Pdf;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Math;
using SignLib.Cades;
using System.Diagnostics;

namespace SignLibTest
{
    /// <summary>
    /// Create the external signature using a third party engine. The class must be inherited from SignLib.Certificates.IExternalSignature interface and 
    /// must implements the method public byte[] ApplySignature(byte[] dataToSign, System.Security.Cryptography.Oid oid)
    /// </summary>
    public class ExternalSignature : SignLib.Certificates.IExternalSignature
    {
        // Defines path to unmanaged PKCS#11 library provided by the cryptographic device vendor
        string _pkcs11LibraryPath;
        string _smartCardPin;

        public ExternalSignature(string pathToPKCS11Module, string smartCardPin)
        {
            _pkcs11LibraryPath = pathToPKCS11Module;
            _smartCardPin = smartCardPin;
        }

        public X509Certificate2 PKCS11SignatureCertificate { get; set; }

        public X509Certificate2Collection GetCertificatesFromSmartCard()
        {
            X509Certificate2Collection col = new X509Certificate2Collection();

            // Load unmanaged PKCS#11 library
            using (Pkcs11 pkcs11 = new Pkcs11(_pkcs11LibraryPath, AppType.MultiThreaded))
            {
                if (pkcs11.GetSlotList(SlotsType.WithTokenPresent).Count == 0)
                    throw new System.Security.Cryptography.CryptographicException("PKCS#11 smart card is not present.");

                Slot slot = pkcs11.GetSlotList(SlotsType.WithTokenPresent)[0];

                // Open RW session
                using (Session session = slot.OpenSession(SessionType.ReadWrite))
                {
                    // Login as normal user
                    session.Login(CKU.CKU_USER, _smartCardPin);

                    List<ObjectAttribute> objectAttributes = new List<ObjectAttribute>();

                    objectAttributes.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_CERTIFICATE));
                    objectAttributes.Add(new ObjectAttribute(CKA.CKA_CERTIFICATE_TYPE, CKC.CKC_X_509));

                    List<ObjectHandle> certificateList = session.FindAllObjects(objectAttributes);

                    //find all certificates stored on the smart card and add them into collection
                    foreach (ObjectHandle certificate in certificateList)
                    {
                        List<CKA> attributes = new List<CKA>();
                        attributes.Add(CKA.CKA_VALUE);

                        List<ObjectAttribute> certificateAttributes = session.GetAttributeValue(certificate, attributes);
                        byte[] signingCertificate = certificateAttributes[0].GetValueAsByteArray();

                        col.Add(new X509Certificate2(signingCertificate));
                    }

                }
            }

            return col;
        }

        public byte[] ApplySignature(byte[] dataToSign, System.Security.Cryptography.Oid oid)
        {
            try
            {
                // Load unmanaged PKCS#11 library
                using (Pkcs11 pkcs11 = new Pkcs11(_pkcs11LibraryPath, AppType.MultiThreaded))
                {
                    if (pkcs11.GetSlotList(SlotsType.WithTokenPresent).Count == 0)
                        throw new System.Security.Cryptography.CryptographicException("PKCS#11 smart card is not present.");

                    Slot slot = pkcs11.GetSlotList(SlotsType.WithTokenPresent)[0];

                    // Open RW session
                    using (Session session = slot.OpenSession(SessionType.ReadOnly))
                    {
                        // Login as normal user
                        session.Login(CKU.CKU_USER, _smartCardPin);

                        List<ObjectAttribute> objectAttributes = new List<ObjectAttribute>();

                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_CERTIFICATE));
                        objectAttributes.Add(new ObjectAttribute(CKA.CKA_CERTIFICATE_TYPE, CKC.CKC_X_509));

                        List<ObjectHandle> certificateList = session.FindAllObjects(objectAttributes);

                        string certificateId = null;

                        //find the right private key
                        //the certificate and the private key have the same ID
                        foreach (ObjectHandle certificate in certificateList)
                        {
                            List<CKA> attributes = new List<CKA>();
                            attributes.Add(CKA.CKA_VALUE);
                            attributes.Add(CKA.CKA_ID);

                            List<ObjectAttribute> certificateAttributes = session.GetAttributeValue(certificate, attributes);

                            byte[] signingCertificate = certificateAttributes[0].GetValueAsByteArray();

                            //get the certificate ID
                            if (PKCS11SignatureCertificate.Thumbprint == new X509Certificate2(signingCertificate).Thumbprint)
                            {
                                certificateId = ConvertUtils.BytesToHexString(certificateAttributes[1].GetValueAsByteArray());
                                break; //exit the loop because we have fond the right certificate
                            }
                        }

                        //now we must find the corresponding private key
                        // Define search template for private keys
                        List<ObjectAttribute> keySearchTemplate = new List<ObjectAttribute>();
                        keySearchTemplate.Add(new ObjectAttribute(CKA.CKA_CLASS, CKO.CKO_PRIVATE_KEY));

                        // Define private key attributes that should be read
                        List<CKA> keyAttributes = new List<CKA>();
                        keyAttributes.Add(CKA.CKA_ID);

                        // Find private keys
                        List<ObjectHandle> privateKeyList = session.FindAllObjects(keySearchTemplate);
                        foreach (ObjectHandle privateKey in privateKeyList)
                        {
                            List<ObjectAttribute> privateKeyAttributes = session.GetAttributeValue(privateKey, keyAttributes);

                            string ckaId = ConvertUtils.BytesToHexString(privateKeyAttributes[0].GetValueAsByteArray());

                            //the certificate and the private key have the same ID
                            if (ckaId == certificateId)
                            {

                                byte[] digest = null;
                                byte[] digestInfo = null;

                                digest = ComputeDigest(dataToSign, oid.Value);
                                digestInfo = CreateDigestInfo(digest, oid.Value);

                                Mechanism mechanism = new Mechanism(CKM.CKM_RSA_PKCS);

                                return session.Sign(mechanism, privateKey, digestInfo);

                            }
                        }
                    }
                }

                //the private key is not present
                throw new Exception("Private key was not found.");

            }
            catch (Exception ex)
            {
                throw new Exception("PKCS#11 signature cannot be performed: " + ex.Message);

            }
        }

        private byte[] ComputeDigest(byte[] message, string hashOid)
        {
            try
            {
                System.Security.Cryptography.HashAlgorithm sha = null;

                if (hashOid == "1.3.14.3.2.26") //SHA1
                    sha = new System.Security.Cryptography.SHA1Managed();

                if (hashOid == "2.16.840.1.101.3.4.2.1") //SHA256
                    sha = new System.Security.Cryptography.SHA256Managed();

                if (hashOid == "2.16.840.1.101.3.4.2.2") //SHA384
                    sha = new System.Security.Cryptography.SHA384Managed();

                if (hashOid == "2.16.840.1.101.3.4.2.3") //SHA512
                    sha = new System.Security.Cryptography.SHA512Managed();

                return sha.ComputeHash(message);

            }
            catch
            {
                throw;
            }
        }

        private byte[] CreateDigestInfo(byte[] hash, string hashOid)
        {
            Org.BouncyCastle.Asn1.DerObjectIdentifier derObjectIdentifier = new Org.BouncyCastle.Asn1.DerObjectIdentifier(hashOid);
            Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier algorithmIdentifier = new Org.BouncyCastle.Asn1.X509.AlgorithmIdentifier(derObjectIdentifier, null);
            Org.BouncyCastle.Asn1.X509.DigestInfo digestInfo = new Org.BouncyCastle.Asn1.X509.DigestInfo(algorithmIdentifier, hash);
            return digestInfo.GetDerEncoded();
        }

    }

    class Program
    {

        //This demo project uses Pkcs11Interop library available here: https://www.pkcs11interop.net/

        /*************************************
        On the demo version of the library, a 10 seconds delay will be added for every operation.
        The certificate will be valid only 30 days on the demo version of the library
        */

        static void DigitallySignCAdES(string unsignedDocument, string signedDocument)
        {

            //put your smart card PKCS#11 driver here and the smart card password
            //a list is availabe here: http://wiki.ncryptoki.com/Known-PKCS-11-modules.ashx
            ExternalSignature exSignature = new ExternalSignature(@"c:\Windows\System32\eTPKCS11.dll", "1234567890");

            X509Certificate2Collection smartCardCertificates = exSignature.GetCertificatesFromSmartCard();

            if (smartCardCertificates.Count == 0)
                throw new Exception("No certificate was found on the smart card.");

            //add System.Secrutiy as reference
            X509Certificate2Collection selectedCertificate = X509Certificate2UI.SelectFromCollection(smartCardCertificates, "Select Certificate", "Select the signature certificate", X509SelectionFlag.SingleSelection);

            if (selectedCertificate.Count == 0)
                throw new Exception("No certificate was selected.");
            else
                exSignature.PKCS11SignatureCertificate = selectedCertificate[0];


            //to not ask for the certificate for every signature it can be loaded directly from the .CER file
            //the certificate can be exported from Microsoft Certificate Store (start - run - certmgr.msc)
            //X509Certificate2 cert = new X509Certificate2(File.ReadAllBytes("my_certificate.cer"));
            //exSignature.PKCS11SignatureCertificate = cert;

            CadesSignature cs = new CadesSignature("YourSerialNumber");
            cs.HashAlgorithm = SignLib.HashAlgorithm.SHA256;

            
            cs.SignatureStandard = CadesSignatureStandard.CadesBes;
            cs.DigitalSignatureCertificate = exSignature.PKCS11SignatureCertificate;
            SignLib.Certificates.DigitalCertificate.UseExternalSignatureProvider = exSignature;

            //bind the external signature with the library
            SignLib.Certificates.DigitalCertificate.UseExternalSignatureProvider = exSignature;

            //write the signed file
            File.WriteAllBytes(signedDocument, cs.ApplyDigitalSignature(unsignedDocument));

            Console.WriteLine("The CADES signature was created." + Environment.NewLine);

        }

        static void ExtractCertificateInformation(X509Certificate2 cert)
        {
            Console.WriteLine("Certificate subject:" + cert.Subject);
            Console.WriteLine("Certificate issued by:" + cert.GetNameInfo(X509NameType.SimpleName, true));
            Console.WriteLine("Certificate will expire on: " + cert.NotAfter.ToString());
            Console.WriteLine("Certificate is time valid: " + DigitalCertificate.VerifyDigitalCertificate(cert, VerificationType.LocalTime).ToString());
        }

        static void VerifyCAdESSignature(string signedDocument)
        {
            CadesVerify cv = new CadesVerify(signedDocument, "YourSerialNumber");

            Console.WriteLine("Number of signatures: " + cv.Signatures.Count.ToString());
            Console.WriteLine("Signature Standard: " + cv.SignatureStandard.ToString());

            //verify every digital signature from the signed document
            foreach (CadesSignatureInfo csi in cv.Signatures)
            {
                Console.WriteLine("Hash Algorithm: " + csi.HashAlgorithm.FriendlyName);
                Console.WriteLine("Signature Certificate Information");
                ExtractCertificateInformation(csi.SignatureCertificate);
                Console.WriteLine("Signature Is Valid: " + csi.SignatureIsValid.ToString());
                Console.WriteLine("Signature Time: " + csi.SignatureTime.ToLocalTime().ToString());
                Console.WriteLine("Is Timestamped: " + csi.SignatureIsTimestamped);

                if (csi.SignatureIsTimestamped == true)
                {
                    Console.WriteLine("Hash Algorithm: " + csi.TimestampInfo.HashAlgorithm.FriendlyName);
                    Console.WriteLine("Is TimestampAltered: " + csi.TimestampInfo.IsTimestampAltered.ToString());
                    Console.WriteLine("TimestampSerial Number: " + csi.TimestampInfo.SerialNumber);
                    Console.WriteLine("TSA Certificate: " + csi.TimestampInfo.TsaCertificate.Subject);
                }

                Console.WriteLine(Environment.NewLine);
            }

            Console.WriteLine("Done CAdES signature verification." + Environment.NewLine + Environment.NewLine);
        }


        static void Main(string[] args)
        {
            try
            {
                DigitallySignCAdES("test.xml", "test.xml.p7s");
                VerifyCAdESSignature("test.xml.p7s");
                
            }
            catch (Exception ex)
            {
                Console.Write("General exception: " + ex.Message);
            }

        }
    }
}


