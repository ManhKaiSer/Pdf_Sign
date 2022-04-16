using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

using System.Security.Cryptography.X509Certificates;

using SignLib.Cades;

//http://www.signfiles.com/file-sign-library/
namespace FileSigner
{

    public partial class FileSigner : Form
    {

        /*************************************
        On the demo version of the library, a 10 seconds delay will be added for every operation.
        */
        static string serialNumber = "YourSerialNumber";

        byte[] unsignedFile = null;
        string unsignedFileName = null;


        public FileSigner()
        {
            InitializeComponent();
        }

        #region Digitally Sign a file in PKCS#7 format (p7s)

        private X509Certificate2 GetCertificate()
        {
            try
            {
                CertificateSelection cs = new CertificateSelection();
                cs.ShowDialog();
                return cs.selectedSigningCert;
            }
            catch
            {
                return null;
            }
        }

        private void SignFile(string inputFile, string outputFile, X509Certificate2 card)
        {
            try
            {
                //digitally sign a file in PKCS#7 format
                //on the demo version it will be a 5 seconds delay for every operation (digital signature creation or verification)
                //this is the single restriction of the library
                //http://www.signfiles.com/file-sign-library/
                CadesSignature pkcs7Sign = new CadesSignature(serialNumber);

                //set the certificate
                pkcs7Sign.DigitalSignatureCertificate = card;


                //optionally, the file can be timestamped
                if (checkBoxTimeStamp.Checked == true)
                    pkcs7Sign.TimeStamping.ServerUrl = new Uri("http://ca.signfiles.com/TSAServer.aspx");

                //thi file can be saved as .p7s or .p7m file
                File.WriteAllBytes(outputFile, pkcs7Sign.ApplyDigitalSignature(inputFile));
                
            }
            catch (Exception ex)
            {
                throw new Exception("Error on file: " + inputFile + "\n" + ex.Message);
            }
        }

        #endregion    

        #region Verify Signed File

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            try
            {
                textBoxSignatureInfo.Clear();

                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = false;
                openFile.Filter = "All Signed Files|*.p7s;*p7m";
                openFile.Title = "Select the signed file";
                if (openFile.ShowDialog() != DialogResult.OK)
                    return;

                textBoxVerifyFile.Text = openFile.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonVerifySignedFile_Click(object sender, EventArgs e)
        {
            try
            {
                string info = string.Empty;

                //prepare the object from the signed file

                //on the demo version it will be a 5 seconds delay for every operation (digital signature creation or verification)
                //this is the single restriction of the library
                //http://www.signfiles.com/file-sign-library/
                CadesVerify pkcs7Verify = new CadesVerify(textBoxVerifyFile.Text, serialNumber);

                int numberOfSignatures = pkcs7Verify.Signatures.Count;
               
                info = "Number of signatures: " + numberOfSignatures;
                info += "\r\nOriginal document name: " + pkcs7Verify.DocumentName;

                //extract the unsigned file content
                if (pkcs7Verify.UnsignedDocument != null)
                {
                    buttonUnsignedFile.Enabled = true;
                    unsignedFile = pkcs7Verify.UnsignedDocument;
                }

                //the signed document can contains multiple signatures
                foreach (CadesSignatureInfo si in pkcs7Verify.Signatures)
                {
                    info += "\r\n\r\nSignature:\r\n";

                    info += "\r\nSignature is valid: " + si.SignatureIsValid;

                    info += "\r\nSigning Certificate: " + si.SignatureCertificate.SubjectName.Name;
                    info += "\r\nSigning Reason: " + si.SignatureReason;
                    info += "\r\nSigning Date (computer time): " + si.SignatureTime.ToLocalTime().ToString();
                    info += "\r\nSigning hash algorithm: " + si.HashAlgorithm.FriendlyName;
                    info += "\r\nIs timestamped: " + si.SignatureIsTimestamped;

                    if (si.SignatureIsTimestamped == true)
                    {
                        info += "\r\nTime Stamp Certificate: " + si.TimestampInfo.TsaCertificate.SubjectName.Name;
                        info += "\r\nTime Stamp Signature date: " + si.TimestampInfo.SignatureTime.ToLocalTime().ToString();
                        info += "\r\nTime Stamp Server Policy: " + si.TimestampInfo.Policy.Value;
                    }

                }

                textBoxSignatureInfo.Text = info;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonUnsignedFile_Click(object sender, EventArgs e)
        {
            try
            {
                //open unsigned document
                string unsignedFilePath = Path.GetTempPath() + Path.GetFileNameWithoutExtension(textBoxVerifyFile.Text);
                File.WriteAllBytes(unsignedFilePath, unsignedFile);
                System.Diagnostics.Process.Start(unsignedFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        #region Interface Stuff

        private void buttonSource_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = false;
                openFile.Filter = "All Files|*.*";
                openFile.Title = "Select file";
                if (openFile.ShowDialog() != DialogResult.OK)
                    return;

                inputBox.Text = openFile.FileName;

                //add the extension
                outputBox.Text = openFile.FileName + ".p7s";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveSignedFile = new SaveFileDialog();

                try
                {
                    saveSignedFile.InitialDirectory = Path.GetDirectoryName(inputBox.Text);
                    saveSignedFile.FileName = Path.GetFileName(inputBox.Text);
                }
                catch
                {
                }

                saveSignedFile.AddExtension = true;
                saveSignedFile.Filter = "P7S Files|*.p7s";
                saveSignedFile.Title = "Save the signed file";
                if (saveSignedFile.ShowDialog() != DialogResult.OK)
                    return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("On the demo version, 10 seconds of delay is added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //signing certificate
                X509Certificate2 card = GetCertificate();

                //on the demo version it will be a 5 seconds delay for every operation (digital signature creation or verification)
                //this is the single restriction of the library
                //http://www.signfiles.com/file-sign-library/
                SignFile(inputBox.Text, outputBox.Text, card);

                MessageBox.Show("File was signed succesfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxVerifyFile.Text = outputBox.Text;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }

        #endregion

    }

}