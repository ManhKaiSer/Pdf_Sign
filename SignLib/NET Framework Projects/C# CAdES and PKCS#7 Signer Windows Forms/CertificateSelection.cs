using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

using SignLib.Certificates;

namespace FileSigner
{
    public partial class CertificateSelection : Form
    {

        //used for obtaining the signing certificate
        //public DigitalCertificates digitalCertificate = new DigitalCertificates();

        //the signing certificate
        public X509Certificate2 selectedSigningCert = null;

        public CertificateSelection()
        {
            InitializeComponent();
        }


        private void linkLabelCertificates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://ca.signfiles.com/userEnroll.aspx");
            }
            catch
            {
            }
        }

        private void radioButtonWindowsCertStore_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWindowsCertStore.Checked == true)
                groupBoxPFXCertificate.Enabled = false;
            else
                groupBoxPFXCertificate.Enabled = true;
        }

        private void buttonSelectPFX_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPDFFile = new OpenFileDialog();
            openPDFFile.Multiselect = false;
            openPDFFile.Filter = "PFX digital certificates *.pfx|*.pfx";
            openPDFFile.Title = "Select the PFX certificate";
            if (openPDFFile.ShowDialog() != DialogResult.OK)
                return;

            textBoxPFXFile.Text = openPDFFile.FileName;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            try
            {
                //Use a certificate from Microsoft Store
                if (radioButtonWindowsCertStore.Checked == true)
                {
                    selectedSigningCert = DigitalCertificate.LoadCertificate(checkBoxValidOnly.Checked, "", "Digital certificates", "Select the signing certificate");
                    buttonOK.DialogResult = DialogResult.OK;
                    this.Close();
                }

                //Use a certificate from PFX file
                if (radioButtonPFXCert.Checked == true)
                {
                    if (System.IO.File.Exists(textBoxPFXFile.Text) == false)
                    {
                        MessageBox.Show("The selected PFX signing certificate cannot be found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedSigningCert = DigitalCertificate.LoadCertificate(System.IO.File.ReadAllBytes(textBoxPFXFile.Text), textBoxPFXPassword.Text);
                    buttonOK.DialogResult = DialogResult.OK;
                    this.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Certificate error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
