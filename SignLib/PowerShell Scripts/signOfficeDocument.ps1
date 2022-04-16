#digitally sign a file file using a PFX certificate creted on the fly
#the format of the signed file will be CAdES
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
    
#digitally sign the file in CAdES format
    $sign = new-object -typeName SignLib.OfficeSignature("serial number")
    $sign.DigitalSignatureCertificate = [SignLib.Certificates.DigitalCertificate]::LoadCertificate($certificate, $pFXFilePassword)

    echo "Perform the digital signature..."
    $sign.ApplyDigitalSignature($args[0], $args[1])    

}