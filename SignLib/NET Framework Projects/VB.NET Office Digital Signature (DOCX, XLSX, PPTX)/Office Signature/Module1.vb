
Imports System.Collections.Generic
Imports System.Collections
Imports System.IO

Imports System.Security.Cryptography.X509Certificates
Imports SignLib.Certificates
Imports SignLib

Module Module1

    Sub Main()

        'usually, the signed CAdES file should be saved with .p7s or .p7m extension
        DigitallySignOfficeDocument(Environment.CurrentDirectory + "\test.docx", Environment.CurrentDirectory + "\test[signed].docx")

        VerifyOfficeSignature(Environment.CurrentDirectory + "\test[signed].docx")

        Console.WriteLine("All done!")

    End Sub

    Private Function CreateDigitalCertificate() As X509Certificate2
        Dim certificatePassword As String = "temp_passw0rd"
        'on the demo version the certificates will be valid 30 days only
        'this is the single restriction of the library in demo mode
        Dim certGenerator As New X509CertificateGenerator("YourSerialNumber")

        'set the validity of the certificate
        certGenerator.ValidFrom = DateTime.Now
        'The certificate will be valid only 30 days on the demo version of the library
        certGenerator.ValidTo = DateTime.Now.AddYears(2)

        'set the signing algorithm and the key size
        certGenerator.KeySize = KeySize.KeySize1024Bit
        certGenerator.SignatureAlgorithm = SignatureAlgorithm.SHA256WithRSA

        'set the certificate sobject
        certGenerator.Subject = "CN=Digital Signature Certificate, OU=Organization Unit, E=user@email.com"

        'add some simple extensions to the client certificate
        certGenerator.Extensions.AddKeyUsage(CertificateKeyUsage.DigitalSignature)
        certGenerator.Extensions.AddKeyUsage(CertificateKeyUsage.NonRepudiation)

        'add some enhanced extensions to the client certificate marked as critical
        certGenerator.Extensions.AddEnhancedKeyUsage(CertificateEnhancedKeyUsage.DocumentSigning)
        certGenerator.Extensions.AddEnhancedKeyUsage(CertificateEnhancedKeyUsage.ClientAuthentication)

        Console.WriteLine("User certificate was created!")

        'convert the resulting PFX certificate to X509Certificate2 that can be used by .NET
        Return New X509Certificate2(certGenerator.GenerateCertificate(certificatePassword, False), certificatePassword)
    End Function

    Private Sub ExtractCertificateInformation(ByVal cert As X509Certificate2)
        Console.WriteLine("Certificate subject:" + cert.Subject)
        Console.WriteLine("Certificate issued by:" + cert.GetNameInfo(X509NameType.SimpleName, True))
        Console.WriteLine("Certificate will expire on: " + cert.NotAfter.ToString())
        Console.WriteLine("Certificate is time valid: " + DigitalCertificate.VerifyDigitalCertificate(cert, VerificationType.LocalTime).ToString())
    End Sub


    Private Sub DigitallySignOfficeDocument(ByVal unsignedDocument As String, ByVal signedDocument As String)
        Dim cs As New OfficeSignature("serial number")

        'Digital signature certificate can be loaded from vorious sources

        'Load the signature certificate from a PFX or P12 file
        cs.DigitalSignatureCertificate = DigitalCertificate.LoadCertificate(Environment.CurrentDirectory + "\cert.pfx", "123456")

        'Create a digital signature certificate on the fly (X509Certificate2 certificate)
        'cs.DigitalSignatureCertificate = CreateDigitalCertificate()

        'Load the certificate from Microsoft Store. 
        'The smart card or USB token certificates are usually available on Microsoft Certificate Store (start - run - certmgr.msc).
        'If the smart card certificate not appears on Microsoft Certificate Store it cannot be used by the library
        'cs.DigitalSignatureCertificate = DigitalCertificate.LoadCertificate(false, string.Empty, "Select Certificate", "Select the certificate for digital signature")

        'The smart card PIN dialog can be bypassed for some smart cards/USB Tokens. 
        'ATTENTION: This feature will NOT work for all available smart card/USB Tokens becauase of the drivers or other security measures.
        'Use this property carefully.
        'DigitalCertificate.SmartCardPin = "123456"

        'write the signed file
        cs.ApplyDigitalSignature(unsignedDocument, signedDocument)

        Console.WriteLine("Office signature was created." + Environment.NewLine)

    End Sub

    Private Sub VerifyOfficeSignature(ByVal signedDocument As String)
        Dim cv As New OfficeSignature("serial number")

        Console.WriteLine("Number of signatures: " + cv.GetNumberOfSignatures(signedDocument).ToString())

        'verify the first signature
        Console.WriteLine("Signature validity status: " + cv.VerifyDigitalSignature(signedDocument, 1))

        Console.WriteLine("Done Office signature verification." + Environment.NewLine + Environment.NewLine)
    End Sub

End Module
