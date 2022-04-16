using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Net;
 

using System.Security.Cryptography.X509Certificates;
using SignLib;
using SignLib.Certificates;


namespace SignLibTest
{

    class Program
    {
        //display only the certificates that have the private key
        private static X509Certificate2 GetCertificateFromStore()
        {
            X509Store st = null;

            try
            {
                try
                {
                    st = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                    st.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);
                }
                catch
                {
                    throw new System.Security.Cryptography.CryptographicException("Signing certificates store cannot be opened.");
                }

                X509Certificate2Collection col = new X509Certificate2Collection();

                //loads all the certificates available on teh Microsoft Store
                col.AddRange(st.Certificates.Find(X509FindType.FindByIssuerName, "", false));


                //from all certificates select just the certificates that have the private key and are stored on a hardware device
                X509Certificate2Collection finalCol = new X509Certificate2Collection();

                foreach (X509Certificate2 cert in col)
                {
                    try
                    {
                        System.Security.Cryptography.RSACryptoServiceProvider rsa = new System.Security.Cryptography.RSACryptoServiceProvider();

                        //the private key is available
                        if (cert.HasPrivateKey == true)
                        {
                            /*
                            //select only the certificates stored on a hardware device
                            //if the smart card/token is not entered on a USB port, the certificate will not be selected
                              
                             rsa = cert.PrivateKey as System.Security.Cryptography.RSACryptoServiceProvider;
                                 if (rsa.CspKeyContainerInfo.HardwareDevice == true)
                             */
                            
                            finalCol.Add(cert);
                        }
                    }
                    catch
                    {
                    }
                }

                if (finalCol.Count == 0)
                {
                    return null;
                }

                //add System.Security as reference
                X509Certificate2Collection sel = X509Certificate2UI.SelectFromCollection(finalCol, "", "", X509SelectionFlag.SingleSelection);
                if (sel.Count > 0)
                {
                    X509Certificate2Enumerator en = sel.GetEnumerator();
                    en.MoveNext();

                    return en.Current;
                }

                return null;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (st != null)
                    st.Close();
            }
        }

        static void SelectAndVerifyCertificate()
        {

            //check if the certificate is time valid
            //Verify the certificate issued for google.com website
            X509Certificate2 certificate = GetCertificateFromStore();

            if (certificate == null)
                throw new Exception("No certificate was found or selected.");

            Console.WriteLine("Verify against the local time: " + DigitalCertificate.VerifyDigitalCertificate(certificate, VerificationType.LocalTime));
            Console.WriteLine("Verify against the CRL: " + DigitalCertificate.VerifyDigitalCertificate(certificate, VerificationType.CRL));
            Console.WriteLine("Verify against the OCSP: " + DigitalCertificate.VerifyDigitalCertificate(certificate, VerificationType.OCSP));

            //CertificateStatus.Expired - the certificate is expired
            //CertificateStatus.Revoked - the certificate is revoked 
            //CertificateStatus.Unknown - the CRL or the OCSP service is unavailable
            //CertificateStatus.Valid - the certificate is OK


            Console.WriteLine("Done certificate validation.");

        }

        static void Main(string[] args)
        {
            try
            {
                SelectAndVerifyCertificate();

                Console.WriteLine("All done!");
            }
            catch (Exception ex)
            {
                Console.Write("General exception: " + ex.Message);
            }

        }
    }
}


