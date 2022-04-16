#digitally sign a PDF file using a PFX certificate creted on the fly
#the script can be configured to use an existing PFX file or a certificate loaded from Microsoft Store (smart card certificate)

if ($args.Length -eq 0)
{
    echo "Usage: signpdf.ps1 <unsigned file> <signed file>"
}
else
{


$DllPath = 'd:\SignLib.dll'
[System.Reflection.Assembly]::LoadFrom($DllPath)


#create a PFX digital certificate
    $generator = new-object -typeName SignLib.Certificates.X509CertificateGenerator("serial number")
    $pFXFilePassword = "tempP@ssword"
    
    $generator.Subject = "CN=Your Certificate, E=useremail@email.com, O=Organzation"
    $generator.Extensions.AddKeyUsage([SignLib.Certificates.CertificateKeyUsage]::DigitalSignature)
    $generator.Extensions.AddEnhancedKeyUsage([SignLib.Certificates.CertificateEnhancedKeyUsage]::DocumentSigning)
    
    echo "Create the certificate..."
    $certificate = $generator.GenerateCertificate($pFXFilePassword)
    
#digitally sign the pdf file
    $sign = new-object -typeName SignLib.Pdf.PdfSignature("serial number")
    $sign.LoadPdfDocument([System.IO.File]::ReadAllBytes($args[0]))
    $sign.DigitalSignatureCertificate = [SignLib.Certificates.DigitalCertificate]::LoadCertificate($certificate, $pFXFilePassword)


    $sign.SigningReason = "I approve this document"
    $sign.SigningLocation = "Europe branch"
    $sign.SignaturePage = 1
    $sign.SignaturePosition = [SignLib.Pdf.SignaturePosition]::TopRight

    echo "Perform the digital signature..."
    [System.IO.File]::WriteAllBytes($args[1], $sign.ApplyDigitalSignature())
    

}