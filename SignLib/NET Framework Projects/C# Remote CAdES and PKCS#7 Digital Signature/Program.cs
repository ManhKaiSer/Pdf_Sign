using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;

using System.Security.Cryptography.X509Certificates;
using SignLib.Certificates;
using SignLib.Cades;

namespace SignLibTest
{
    /// <summary>
    /// Create the external signature using a third party engine. The class must be inherited from SignLib.Certificates.IExternalSignature interface and 
    /// must implements the method public byte[] ApplySignature(byte[] dataToSign, System.Security.Cryptography.Oid oid)
    /// </summary>
    public class ExternalSignature : SignLib.Certificates.IExternalSignature
    {

        public ExternalSignature()
        {
            //obtaining the remote signature certificate
            remote.signature.RemoteSignature rs = new remote.signature.RemoteSignature();
            RemoteSignatureCertificate = new X509Certificate2(rs.GetSigningCertificate());
        }

        public X509Certificate2 RemoteSignatureCertificate { get; set; }

        public byte[] ApplySignature(byte[] dataToSign, System.Security.Cryptography.Oid oid)
        {
            try
            {

                remote.signature.RemoteSignature rs = new remote.signature.RemoteSignature();
                return rs.RemoteSignWithOid(dataToSign, oid.Value.ToString());

            }
            catch (Exception ex)
            {
                throw new Exception("Remote signature cannot be performed: " + ex.Message);

            }
        }
    }

    class Program
    {
        /*************************************
        On the demo version of the library, a 10 seconds delay will be added for every operation.
        The certificate will be valid only 30 days on the demo version of the library
        */
        static string serialNumber = "YourSerialNumber";

        static void ExtractCertificateInformation(X509Certificate2 cert)
        {
            Console.WriteLine("Certificate subject:" + cert.Subject);
            Console.WriteLine("Certificate issued by:" + cert.GetNameInfo(X509NameType.SimpleName, true));
            Console.WriteLine("Certificate will expire on: " + cert.NotAfter.ToString());
            Console.WriteLine("Certificate is time valid: " + DigitalCertificate.VerifyDigitalCertificate(cert, VerificationType.LocalTime).ToString());
        }

        static void DigitallySignInCAdESFormat(string unsignedDocument, string signedDocument)
        {
            CadesSignature cs = new CadesSignature(serialNumber);

            cs.HashAlgorithm = SignLib.HashAlgorithm.SHA256;

            cs.SignatureStandard = CadesSignatureStandard.CadesBes;

            ExternalSignature exSignature = new ExternalSignature();

            //set the certificate
            cs.DigitalSignatureCertificate = exSignature.RemoteSignatureCertificate;

            //bind the external signature with the library
            SignLib.Certificates.DigitalCertificate.UseExternalSignatureProvider = exSignature;


            //optionally, the signature can be timestamped.
            //cs.TimeStamping.ServerUrl = new Uri("http://ca.signfiles.com/TSAServer.aspx");

            //write the signed file
            //usually, the signed CAdES file should be saved with .p7s or .p7m extension
            File.WriteAllBytes(signedDocument, cs.ApplyDigitalSignature(unsignedDocument));

            Console.WriteLine("The CAdES signature was created." + Environment.NewLine);

        }

        static void VerifyCAdESSignature(string signedDocument)
        {
            CadesVerify cv = new CadesVerify(signedDocument, serialNumber);

            Console.WriteLine("Number of signatures: " + cv.Signatures.Count.ToString());

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
                //usually, the signed CAdES file should be saved with .p7s or .p7m extension
                DigitallySignInCAdESFormat("test.txt", "test.txt.p7s");

                VerifyCAdESSignature("test.txt.p7s");

                Console.WriteLine("All done!");
            }
            catch (Exception ex)
            {
                Console.Write("General exception: " + ex.Message);
            }

        }
    }
}


