using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace PDFSigner
{
    public partial class CertificateSelection : Form
    {
      

        public CertificateSelection()
        {
            InitializeComponent();

            SetLanguage();
        }

        private void SetLanguage()
        {
            this.Text = StringEN.CertificateSelection;
            selectTheDigitalCertificate.Text = StringEN.selectTheDigitalCertificate;
            radioButtonWindowsCertStore.Text = StringEN.radioButtonWindowsCertStore;
            groupBoxWindowsCertificateStore.Text = StringEN.groupBoxWindowsCertificateStore;
            checkBoxValidOnly.Text = StringEN.checkBoxValidOnly;
            buttonShowSigninigCertificate.Text = StringEN.buttonShowSigninigCertificate;
            radioButtonPFXCert.Text = StringEN.radioButtonPFXCert;
            groupBoxPFXCertificate.Text = StringEN.groupBoxPFXCertificate;
            PFXFilePassword.Text = StringEN.PFXFilePassword;
            buttonCancel.Text = StringEN.buttonCancel;
            buttonOK.Text = StringEN.buttonOK;
        }



        public X509Certificate2 selectedSigningCert = null;

        X509Certificate2Collection signingCerts = new X509Certificate2Collection();

        private X509Certificate2Collection GetCertificatesFromStore(bool validonly)
        {

            X509Store st = new X509Store(StoreName.My, StoreLocation.CurrentUser);

            try
            {
                st.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);

                X509Certificate2Collection col = st.Certificates.Find(X509FindType.FindByIssuerName, "", validonly);

                return col;
            }
            catch
            {
                return null;
            }
            finally
            {
                st.Close();
            }
        }

        private void LoadCertificates(bool validonly)
        {
            comboBoxCertificates.Items.Clear();
            signingCerts = GetCertificatesFromStore(validonly);

            foreach (X509Certificate2 cert in signingCerts)
                comboBoxCertificates.Items.Add(cert.GetNameInfo(X509NameType.SimpleName, false) + StringEN.validUntil + cert.NotAfter.ToShortDateString());

            if (comboBoxCertificates.Items.Count > 0)
            {
                comboBoxCertificates.SelectedIndex = 0;
                labelCertificates.Text = signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, false) + StringEN.issuedBy + signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, true);
                buttonShowSigninigCertificate.Enabled = true;
            }
            else
            {
                labelCertificates.Text = StringEN.noCertificatesFound;
                buttonShowSigninigCertificate.Enabled = false;
            }
        }

        private void CertificateSelection_Load(object sender, EventArgs e)
        {
            LoadCertificates(checkBoxValidOnly.Checked);
        }

        private void buttonShowSigninigCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                X509Certificate2UI.DisplayCertificate(new X509Certificate2(signingCerts[comboBoxCertificates.SelectedIndex]));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBoxValidOnly_CheckedChanged(object sender, EventArgs e)
        {
            LoadCertificates(checkBoxValidOnly.Checked);
        }

        private void radioButtonWindowsCertStore_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWindowsCertStore.Checked == true)
            {
                groupBoxWindowsCertificateStore.Enabled = true;
                groupBoxPFXCertificate.Enabled = false;
            }
            else
            {
                groupBoxWindowsCertificateStore.Enabled = false;
                groupBoxPFXCertificate.Enabled = true;
            }
        }

        private void buttonSelectPFX_Click(object sender, EventArgs e)
        {
            OpenFileDialog openPDFFile = new OpenFileDialog();
            openPDFFile.Multiselect = false;
            openPDFFile.Filter = StringEN.PFXFileFilter;
            openPDFFile.Title = StringEN.openPFXFileTitle;
            if (openPDFFile.ShowDialog() != DialogResult.OK)
                return;

            textBoxPFXFile.Text = openPDFFile.FileName;

        }

        private void comboBoxCertificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelCertificates.Text = signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, false) + StringEN.issuedBy + signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, true);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            //microsoft store
            if (radioButtonWindowsCertStore.Checked == true)
            {
                if (signingCerts.Count == 0)
                {
                    MessageBox.Show(StringEN.noCertificatesFound, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    selectedSigningCert = signingCerts[comboBoxCertificates.SelectedIndex];
                    buttonOK.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }

            if (radioButtonPFXCert.Checked == true)
            {
                if (System.IO.File.Exists(textBoxPFXFile.Text) == false)
                {
                    MessageBox.Show(StringEN.theSelectedPFXCannotBeFound, StringEN.MessageBoxWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                try
                {
                    X509Certificate2 tempcert = new X509Certificate2(textBoxPFXFile.Text, textBoxPFXPassword.Text, X509KeyStorageFlags.MachineKeySet);
                    selectedSigningCert = tempcert;
                    buttonOK.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(StringEN.PFXCertificateError + ex.Message, StringEN.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

        }

 

    }
}
