using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace CertSelector
{
    public partial class CertificateSelection : Form
    {
      
        public CertificateSelection()
        {
            InitializeComponent();
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
                comboBoxCertificates.Items.Add(cert.GetNameInfo(X509NameType.SimpleName, false) + " valid until " + cert.NotAfter.ToShortDateString());

            if (comboBoxCertificates.Items.Count > 0)
            {
                comboBoxCertificates.SelectedIndex = 0;
                labelCertificates.Text = signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, false) + " issued by " + signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, true);
                buttonShowSigninigCertificate.Enabled = true;
            }
            else
            {
                labelCertificates.Text = "No digital certificates was found on Microsoft Certificate Store";
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


        private void comboBoxCertificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            labelCertificates.Text = signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, false) + " issued by " + signingCerts[comboBoxCertificates.SelectedIndex].GetNameInfo(X509NameType.SimpleName, true);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

          
                if (signingCerts.Count == 0)
                {
                    MessageBox.Show("No digital certificates was found on Microsoft Certificate Store", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    selectedSigningCert = signingCerts[comboBoxCertificates.SelectedIndex];
                    this.Close();
                }
            

         

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 

    }
}
