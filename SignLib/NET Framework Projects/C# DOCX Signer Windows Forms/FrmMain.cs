using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;

using SignLib;


 

namespace DOCXSigner
{
    public partial class FrmMain : Form
    {
      

        #region Application Logic


        private void verifySingleDocumentConfiguration()
        {
            try
            {
                //no file is selected
                if (string.IsNullOrEmpty(textBoxSourcePath.Text) == true)
                    throw new Exception("Select the source document.");

                //verify path for source
                try
                {
                    Path.GetFullPath(textBoxSourcePath.Text);
                }
                catch (Exception ex)
                {
                    throw new Exception("Source path is invalid: " + ex.Message);
                }

                //source file not exists
                if (File.Exists(textBoxSourcePath.Text) == false)
                    throw new Exception("Source document not exists.");


                //destination file is not selected
                if (string.IsNullOrEmpty(textBoxDestinationPath.Text) == true)
                    throw new Exception("Select the destination file for the signed document.");

                //verify path for destination
                try
                {
                    Path.GetFullPath(textBoxDestinationPath.Text);
                }
                catch (Exception ex)
                {
                    throw new Exception("The Destination path for the signed document is invalid: " + ex.Message);
                }

                //destination file cannot be the same as source file
                if (Path.GetFullPath(textBoxSourcePath.Text).ToUpper() == Path.GetFullPath(textBoxDestinationPath.Text).ToUpper())
                    throw new Exception("The destination file for the signed document cannot be the same as the source file.");

                //destination file already exists
                if (File.Exists(textBoxDestinationPath.Text) == true)
                    throw new Exception("The destination file for the signed document already exists.");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void verifyFolderWithDocumentsConfiguration()
        {
            try
            {
                //no input folder is selected
                if (string.IsNullOrEmpty(textBoxSourcePath.Text) == true)
                    throw new Exception("Select the source folder.");

                //verify path for source
                try
                {
                    Path.GetFullPath(textBoxSourcePath.Text);
                }
                catch (Exception ex)
                {
                    throw new Exception("Source path is invalid: " + ex.Message);
                }

                //source folder not exists
                if (Directory.Exists(textBoxSourcePath.Text) == false)
                    throw new Exception("Source folder not exists.");


                //destination folder is not selected
                if (string.IsNullOrEmpty(textBoxDestinationPath.Text) == true)
                    throw new Exception("Select the destination folder for the signed documents.");

                //verify path for destination
                try
                {
                    Path.GetFullPath(textBoxDestinationPath.Text);
                }
                catch (Exception ex)
                {
                    throw new Exception("The destination folder for the signed documents is invalid: " + ex.Message);
                }

                //destination directory not exists
                if (Directory.Exists(textBoxDestinationPath.Text) == false)
                    throw new Exception("The destination folder for the signed document not exists.");

                //destination folder cannot be the same as source folder
                if (Path.GetFullPath(textBoxSourcePath.Text).ToUpper() == Path.GetFullPath(textBoxDestinationPath.Text).ToUpper())
                    throw new Exception("The destination folder cannot be the same as the source folder.");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private int getNumberOfDocumentsInFolder(string folder)
        {
            try
            {
                //DirectoryInfo di = new DirectoryInfo(folder);
                //return di.GetFiles("*.*").Length;

                string lookfor = "*.docx;*.xlsx;*.pptx";
                string[] extensions = lookfor.Split(new char[] { ';' });

                System.Collections.ArrayList myfileinfos = new System.Collections.ArrayList();
                DirectoryInfo di = new DirectoryInfo(folder);

                foreach (string ext in extensions)
                {
                    myfileinfos.AddRange(di.GetFiles(ext));
                }

                FileInfo[] rgFiles = (FileInfo[])myfileinfos.ToArray(typeof(FileInfo));

                return rgFiles.Length;

            }
            catch
            {
                throw;
            }
        }

        private void verifyConfiguration()
        {
            try
            {
                //verify Path, Names
                if (radioButtonSingleDocument.Checked == true)
                    verifySingleDocumentConfiguration();
                else
                    verifyFolderWithDocumentsConfiguration();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void selectSinglePDFDocument()
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = false;
                openFile.Filter = "All Office Documents|*.docx;*.xlsx;*.pptx|Word Documents (*.docx)|*.docx|Excel Workbooks (*.xlsx)|*.xlsx|PowerPoint Presentations (*.pptx)|*.pptx";
                openFile.Title = "Select document";
                if (openFile.ShowDialog() != DialogResult.OK)
                    return;

                textBoxSourcePath.Text = openFile.FileName;

                //Saving Path
                textBoxDestinationPath.Text = Path.Combine(Path.GetDirectoryName(textBoxSourcePath.Text), Path.GetFileNameWithoutExtension(textBoxSourcePath.Text) + "[signed]" + Path.GetExtension(textBoxSourcePath.Text));

                toolStripStatusLabel.Text = "Selected document: " + Path.GetFileName(textBoxSourcePath.Text);
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured: " + ex.Message);
            }
        }

        private void saveSingleDocument()
        {
            try
            {
                SaveFileDialog saveSignedFile = new SaveFileDialog();

                //keep old path and file name
                try
                {
                    saveSignedFile.InitialDirectory = Path.GetDirectoryName(textBoxSourcePath.Text);
                    saveSignedFile.FileName = Path.GetFileNameWithoutExtension(textBoxSourcePath.Text) + "[signed]"; Path.GetExtension(textBoxSourcePath.Text);
                }
                catch { }

                saveSignedFile.AddExtension = true;
                saveSignedFile.Filter = "All Office Documents|*.docx;*.xlsx;*.pptx|Word Documents (*.docx)|*.docx|Excel Workbooks (*.xlsx)|*.xlsx|PowerPoint Presentations (*.pptx)|*.pptx";
                saveSignedFile.Title = "Save the signed document";
                if (saveSignedFile.ShowDialog() != DialogResult.OK)
                    return;

                textBoxDestinationPath.Text = saveSignedFile.FileName;
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured: " + ex.Message);
            }
        }

        private void selectFolderWithDocuments()
        {
            try
            {
                FolderBrowserDialog openPDFDirectory = new FolderBrowserDialog();

                //keep old path
                try
                {
                    openPDFDirectory.SelectedPath = textBoxSourcePath.Text;
                }
                catch { }

                openPDFDirectory.ShowNewFolderButton = false;
                openPDFDirectory.Description = "Select the source folder with documents";

                if (openPDFDirectory.ShowDialog() != DialogResult.OK)
                    return;

                textBoxSourcePath.Text = openPDFDirectory.SelectedPath;

                try
                {

                    int noOfPDFFiles = getNumberOfDocumentsInFolder(openPDFDirectory.SelectedPath);
                    toolStripStatusLabel.Text = "Number of documents: " + noOfPDFFiles;

                    if (noOfPDFFiles == 0)
                        MessageBox.Show("The selected folder does not contain documents.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch { }

            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured: " + ex.Message);
            }
        }

        private void saveFolderWithPDFSignedDocuments()
        {
            try
            {
                FolderBrowserDialog openPDFDirectory = new FolderBrowserDialog();

                //keep old path
                try
                {
                    openPDFDirectory.SelectedPath = textBoxSourcePath.Text;
                }
                catch { }

                openPDFDirectory.Description = "Select the destination folder for the signed documents";

                if (openPDFDirectory.ShowDialog() != DialogResult.OK)
                    return;

                int noOfPDFFiles = getNumberOfDocumentsInFolder(openPDFDirectory.SelectedPath);

                DialogResult dr = DialogResult.Yes;

                if (noOfPDFFiles > 0)
                    dr = MessageBox.Show("The selected folder already contains documents. Would you like to use this folder as destination folder anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dr == DialogResult.No)
                    return;

                textBoxDestinationPath.Text = openPDFDirectory.SelectedPath;

            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured: " + ex.Message);
            }
        }

        #endregion

        private void buttonApplyDigitalSignature_Click(object sender, EventArgs e)
        {

            try
            {
                MessageBox.Show("On the demo version, 10 seconds delay is added on every digital signature operation.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                OfficeSignature docxSign = new OfficeSignature("serial number");

                FrmCertificates cert = new FrmCertificates();

                cert.ShowDialog();

                docxSign.DigitalSignatureCertificate = cert.signingCert;

                bool isFolderError = false;

                //sign single file
                if (radioButtonSingleDocument.Checked == true)
                {
                    docxSign.ApplyDigitalSignature(textBoxSourcePath.Text, textBoxDestinationPath.Text);

                    toolStripStatusLabel.Text = "Operation finished.";
                    MessageBox.Show("The file was digitally signed succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    //FileInfo[] rgFiles = new DirectoryInfo(textBoxSourcePath.Text).GetFiles("*.pdf");

                    string lookfor = "*.docx;*.xlsx;*.pptx";
                    string[] extensions = lookfor.Split(new char[] { ';' });

                    System.Collections.ArrayList myfileinfos = new System.Collections.ArrayList();
                    DirectoryInfo di = new DirectoryInfo(textBoxSourcePath.Text);

                    foreach (string ext in extensions)
                    {
                        myfileinfos.AddRange(di.GetFiles(ext));
                    }

                    FileInfo[] rgFiles = (FileInfo[])myfileinfos.ToArray(typeof(FileInfo));

                    toolStripProgressBarSign.Maximum = rgFiles.Length + 1;
                    toolStripProgressBarSign.Visible = true;
                    int i = 1;

                    foreach (FileInfo fi in rgFiles)
                    {
                        try
                        {
                            //progress
                            toolStripStatusLabel.Text = "Progress: file " + i++.ToString() + " of " + rgFiles.Length.ToString();
                            toolStripProgressBarSign.Value = i;
                            Application.DoEvents();

                            docxSign.ApplyDigitalSignature(textBoxSourcePath.Text + "\\" + fi.Name, textBoxDestinationPath.Text + "\\" + fi.Name);

                        }
                        catch (Exception ex)
                        {
                            isFolderError = true;

                            DialogResult dr = MessageBox.Show("An error has occured: " + ex.Message + " on file: " + fi.Name +"\r\n\r\nIgnore the error and continue with next file?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                            if (dr == DialogResult.No)
                                break;
                        }

                    }

                    toolStripProgressBarSign.Visible = false;

                    if (isFolderError == false)
                    {
                        toolStripStatusLabel.Text = "Operation finished.";
                        MessageBox.Show("The files available on the source folder was digitally signed succesfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        toolStripStatusLabel.Text = "Operation finished with errors.";
                        MessageBox.Show("Operation finished with errors.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Main Interface and Buttons

        public FrmMain()
        {
            InitializeComponent();
        }



        private void buttonExit_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void radioButtonSingleDocument_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //clear the textboxes when the option is changed
                textBoxSourcePath.Clear();
                textBoxDestinationPath.Clear();
            }
            catch { }
        }

        private void buttonSelectSource_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonSingleDocument.Checked == true)
                    selectSinglePDFDocument();
                else
                    selectFolderWithDocuments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSelectDestination_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonSingleDocument.Checked == true)
                    saveSingleDocument();
                else
                    saveFolderWithPDFSignedDocuments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
