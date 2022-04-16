using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Net;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using SignLib.Certificates;
using SignLib.Pdf;

namespace PDFSigner
{

    public partial class FormPDFSigner : Form
    {

        /*************************************
        On the demo version of the library, a 10 seconds delay will be added for every operation.
        The certificate will be valid only 30 days on the demo version of the library
        */
        string serialNumber = "YourSerialNumber";

        OpenFileDialog openPDFFile = new OpenFileDialog();
        FolderBrowserDialog openPDFDirectory = new FolderBrowserDialog();
        SaveFileDialog savePDFSignedFile = new SaveFileDialog();
        FolderBrowserDialog savePDFSignedDirectory = new FolderBrowserDialog();

        OpenFileDialog openImageFile = new OpenFileDialog();

        public FormPDFSigner()
        {
            try
            {
                InitializeComponent();
                
                comboBoxBasicSignaturePosition.SelectedIndex = 0;
                comboBoxBasicSignaturePage.SelectedIndex = 0;

                comboBoxTimestampingServer.SelectedIndex = 0; 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        #region Application Logic

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

        private byte[] ComputeHash(byte[] msg)
        {
            try
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                return sha.ComputeHash(msg);
            }
            catch
            {
                return null;
            }
        }

        private PdfSignature BuildPDFSignatureObject(string inputFile, X509Certificate2 certificate)
        {
            try
            {
                PdfSignature pdfObj = new PdfSignature(serialNumber);

                pdfObj.LoadPdfDocument(inputFile);

                pdfObj.DigitalSignatureCertificate = certificate;

                if (pdfObj.DigitalSignatureCertificate == null)
                    throw new Exception("Digital signature certificate is not valid.");

                //Signature Reason/Location
                pdfObj.SigningReason = reasonText.Text;
                pdfObj.SigningLocation = locationText.Text;


                if (checkBoxShowSignature.Checked == false)
                    pdfObj.VisibleSignature = false;
                else
                {
                    //Signature Page
                    if (comboBoxBasicSignaturePage.SelectedIndex == 0)
                        pdfObj.SignaturePage = 1;

                    if (comboBoxBasicSignaturePage.SelectedIndex == 1)
                        pdfObj.SignaturePage = int.MaxValue;

                        //pdfObj.SignatureToAllPages = true;


                    //Basic Signature Position
                    if (radioButtonAdvancedSignature.Checked == true)
                        pdfObj.SignatureAdvancedPosition = new System.Drawing.Rectangle(int.Parse(textBoxAdvancedXCoord.Text), int.Parse(textBoxAdvancedYCoord.Text), int.Parse(textBoxAdvancedWidth.Text), int.Parse(textBoxAdvancedHeight.Text));
                    else
                    {
                        if (comboBoxBasicSignaturePosition.SelectedIndex == 0)
                            pdfObj.SignaturePosition = SignaturePosition.TopRight;

                        if (comboBoxBasicSignaturePosition.SelectedIndex == 1)
                            pdfObj.SignaturePosition = SignaturePosition.TopLeft;


                        if (comboBoxBasicSignaturePosition.SelectedIndex == 2)
                            pdfObj.SignaturePosition = SignaturePosition.BottomRight;

                        if (comboBoxBasicSignaturePosition.SelectedIndex == 3)
                            pdfObj.SignaturePosition = SignaturePosition.BottomLeft;

                    } //if basic signature position

         
                        //image file exists
                    if (File.Exists(textBoxImageFile.Text) == true)
                    {
                        pdfObj.SignatureImage = File.ReadAllBytes(textBoxImageFile.Text);


                        if (radioButtonImageAndText.Checked == true)
                            pdfObj.SignatureImageType = SignatureImageType.ImageAndText;

                        if (radioButtonImageAsBackgorund.Checked == true)
                            pdfObj.SignatureImageType = SignatureImageType.ImageAsBackground;

                        if (radioButtonImageNoText.Checked == true)
                            pdfObj.SignatureImageType = SignatureImageType.ImageWithNoText;
                    }
                } // if visible signature box

                //Certify Document
                //pdfObj.CertifySignature = CertifyMethod.NoChangesAllowed;

                //Signature Hash Algorithm
                pdfObj.HashAlgorithm = SignLib.HashAlgorithm.SHA1;

                //Time stamp document
                if (checkBoxTimestampDocument.Checked == true)
                    pdfObj.TimeStamping.ServerUrl = new Uri(comboBoxTimestampingServer.Text);

                return pdfObj;

            }

            catch
            {
                throw;
            }


        }


        private void SignPdf(string inputFile, string outputFile, X509Certificate2 card)
        {
            try
            {
                PdfSignature pdfSign = BuildPDFSignatureObject(inputFile, card);

                File.WriteAllBytes(outputFile, pdfSign.ApplyDigitalSignature());
            }
            catch (Exception ex)
            {
               throw new Exception("An error has occurred: " + ex.Message);
            }

        }

        #endregion
        

        private void buttonSource_Click(object sender, EventArgs e)
        {
            try
            {
                openPDFFile = new OpenFileDialog();
                openPDFFile.Multiselect = false;
                openPDFFile.Filter = StringEN.PDFFileFilter;
                openPDFFile.Title = StringEN.openPDFFileTitle;
                if (openPDFFile.ShowDialog() != DialogResult.OK)
                    return;

                inputBox.Text = openPDFFile.FileName;

                outputBox.Text = Path.Combine(Path.GetDirectoryName(openPDFFile.FileName), Path.GetFileNameWithoutExtension(openPDFFile.FileName) + StringEN.signedFileSuffix + Path.GetExtension(openPDFFile.FileName));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonDestination_Click(object sender, EventArgs e)
        {
            try
            {
                savePDFSignedFile = new SaveFileDialog();

                try
                {
                    savePDFSignedFile.InitialDirectory = Path.GetDirectoryName(inputBox.Text);
                    savePDFSignedFile.FileName = Path.GetFileName(inputBox.Text);
                }
                catch
                {
                }

                savePDFSignedFile.AddExtension = true;
                savePDFSignedFile.Filter = StringEN.PDFFileFilter;
                savePDFSignedFile.Title = StringEN.savePDFSignedFileTitle;
                if (savePDFSignedFile.ShowDialog() != DialogResult.OK)
                    return;

                outputBox.Text = savePDFSignedFile.FileName;

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            try
            {

                X509Certificate2 card = null;


                if (File.Exists(inputBox.Text) == false)
                {
                    MessageBox.Show(StringEN.MessageBoxSelectSourceFile, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    Path.GetFullPath(outputBox.Text);
                }
                catch
                {
                    MessageBox.Show(StringEN.MessageBoxSelectDestinationFile, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (inputBox.Text.Trim().ToUpper() == outputBox.Text.Trim().ToUpper())
                {
                    MessageBox.Show(StringEN.MessageBoxDestinationSourceSameFile, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (File.Exists(outputBox.Text) == true)
                {
                    MessageBox.Show(StringEN.MessageBoxDestinationFileExists, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (checkBoxTimestampDocument.Checked == true)
                {
                    if (comboBoxTimestampingServer.Text == null || comboBoxTimestampingServer.Text.Trim().Length == 0)
                    {
                        MessageBox.Show(StringEN.MessageBoxTSAServerURL, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                if (checkBoxShowSignature.Checked == true && checkBoxIncludeImage.Checked == true)
                {
                    if (File.Exists(textBoxImageFile.Text.Trim()) == false)
                    {
                        MessageBox.Show(StringEN.imageNotExists, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                card = GetCertificate();

                if (card == null)
                {
                    return;
                }

                SignPdf(inputBox.Text, outputBox.Text, card);


                MessageBox.Show(StringEN.MessageBoxFileSignedSuccessfully, StringEN.MessageBoxInformation, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Buttons & Interface


        private void buttonQuit_Click(object sender, EventArgs e)
        {
            try
            {

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void buttonOpenSigned_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(outputBox.Text);
            }
            catch
            {
            }
        }

        private void buttonSelectImage_Click(object sender, EventArgs e)
        {
            openImageFile = new OpenFileDialog();
            openImageFile.Multiselect = false;
            openImageFile.Filter = StringEN.ImageFileFilter;
            openImageFile.Title = StringEN.openImageFileTitle;
            if (openImageFile.ShowDialog() != DialogResult.OK)
                return;

            textBoxImageFile.Text = openImageFile.FileName;
        }
        

        private void radioButtonAdvancedSignature_CheckedChanged(object sender, EventArgs e)
        {
            labelAdvancedTopLeft.Enabled = radioButtonAdvancedSignature.Checked;
            textBoxAdvancedXCoord.Enabled = radioButtonAdvancedSignature.Checked;
            labelAdvancedTopRight.Enabled = radioButtonAdvancedSignature.Checked;
            textBoxAdvancedYCoord.Enabled = radioButtonAdvancedSignature.Checked;
            labelAdvancedWidth.Enabled = radioButtonAdvancedSignature.Checked;
            textBoxAdvancedWidth.Enabled = radioButtonAdvancedSignature.Checked;
            labelAdvancedHeight.Enabled = radioButtonAdvancedSignature.Checked;
            textBoxAdvancedHeight.Enabled = radioButtonAdvancedSignature.Checked;
        }

        private void radioButtonBasicSignature_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxBasicSignaturePosition.Enabled = radioButtonBasicSignature.Checked;
        }

        
        private void checkBoxVisible_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSignaturePosition.Enabled = checkBoxShowSignature.Checked;
            checkBoxIncludeImage.Enabled = checkBoxShowSignature.Checked;

            if (checkBoxShowSignature.Checked == false)
                groupBoxSignatureImage.Enabled = checkBoxShowSignature.Checked;


            if (checkBoxShowSignature.Checked == true && checkBoxIncludeImage.Checked == true)
                groupBoxSignatureImage.Enabled = checkBoxShowSignature.Checked;

        }




        private void checkBoxIncludeImage_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowSignature.Checked == true)
                groupBoxSignatureImage.Enabled = checkBoxIncludeImage.Checked;
        }

        private void checkBoxTSA_CheckedChanged(object sender, EventArgs e)
        {
            labelTimestampingServer.Enabled = checkBoxTimestampDocument.Checked;
            comboBoxTimestampingServer.Enabled = checkBoxTimestampDocument.Checked;

        }

       
        private void FormPDFSigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormPDFSigner_DragDrop(object sender, DragEventArgs e)
        {

            // When file(s) are dragged from Explorer to the form, IDataObject
            // contains array of file names. If one file is dragged,
            // array contains one element.
            Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

            if (a != null)
            {
                // Extract string from first array element
                // (ignore all files except first if number of files are dropped).
                string inputPDF = a.GetValue(0).ToString();

                inputBox.Text = inputPDF;

                //propunem si calea de salvare
                outputBox.Text = Path.Combine(Path.GetDirectoryName(inputPDF), Path.GetFileNameWithoutExtension(inputPDF) + StringEN.signedFileSuffix + Path.GetExtension(inputPDF));

                this.Activate();

            }

        }

        private void FormPDFSigner_DragEnter(object sender, DragEventArgs e)
        {
            // If file is dragged, show cursor "Drop allowed"
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                Array a = (Array)e.Data.GetData(DataFormats.FileDrop);

                if (Path.GetExtension(a.GetValue(0).ToString().ToLower()) == ".pdf")
                {
                    e.Effect = DragDropEffects.Copy;
                }
            }
            else
                e.Effect = DragDropEffects.None;
        }

        #endregion

    }

}