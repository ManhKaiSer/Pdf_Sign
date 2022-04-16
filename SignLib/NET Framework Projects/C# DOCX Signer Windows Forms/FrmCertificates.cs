using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.IO;

namespace DOCXSigner
{
    public partial class FrmCertificates : Form
    {

        X509Certificate2Collection signingCerts = new X509Certificate2Collection();

        public X509Certificate2 signingCert = null;

        #region Application Logic

        private void setInitialValues()
        {
            try
            {
                comboBoxCertificateStore.SelectedIndex = 0;
            }
            catch { }
        }

        private void interfaceCheck()
        {
            try
            {
                groupBoxWindowsCertificateStore.Enabled = radioButtonWindowsCertificateStore.Checked;
                groupBoxPFXCertificate.Enabled = radioButtonPFXCertificate.Checked;
            }
            catch
            {
            }
        }

        private void verifyConfiguration()
        {
            try
            {
                if (radioButtonWindowsCertificateStore.Checked == true)
                {
                    if (comboBoxCertificates.SelectedIndex == 0)
                        throw new Exception("Select a digital certificate from Microsoft Store.");
                }

                if (radioButtonPFXCertificate.Checked == true)
                {
                    //no file is selected
                    if (string.IsNullOrEmpty(textBoxPFXFile.Text) == true)
                        throw new Exception("Select the PFX certificate file.");

                    if (File.Exists(textBoxPFXFile.Text) == false)
                        throw new Exception("PFX certificate file not exists.");

                    if (string.IsNullOrEmpty(textBoxPFXPassword.Text) == true)
                        throw new Exception("PFX file cannot be empty.");

                    try
                    {
                        X509Certificate2 tempCert = new X509Certificate2(File.ReadAllBytes(textBoxPFXFile.Text), textBoxPFXPassword.Text);
                        
                        if (tempCert.HasPrivateKey == false)
                            throw new Exception("Error obtaining the private key from the PFX file. The certificate cannot be used to create digital signatures.");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error obtaining the certificate from the PFX file. Probably PFX password is not correct or the PFX file is invalid: " + ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private X509Certificate2Collection GetCertificatesFromStore(StoreLocation store)
        {

            X509Store st = new X509Store();
            X509Certificate2Collection col = new X509Certificate2Collection();
            try
            {
                st = new X509Store(StoreName.My, store);
                //st = new X509Store(StoreName.AddressBook, store);
                st.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadOnly);


                if (checkBoxShowExpiredCertificates.Checked == false)
                    col = st.Certificates.Find(X509FindType.FindByTimeValid, DateTime.Now, false); //valid cert
                else
                    col = st.Certificates.Find(X509FindType.FindByIssuerName, string.Empty, false); //all certificates

                /*
                // remove certs that don't have private key
                // work backward so we don't disturb the enumeration
                for (int i = col.Count - 1; i >= 0; i--)
                    if (!col[i].HasPrivateKey)
                        col.RemoveAt(i);
                */

                return col;
            }
            catch
            {
                throw;
            }
            finally
            {
                st.Close();
            }
        }

        private string getCertificateInfo(X509Certificate2 cert)
        {
            try
            {

                return "Issued to: " + cert.GetNameInfo(X509NameType.SimpleName, false) +  ", Issued by: " + cert.GetNameInfo(X509NameType.SimpleName, true) + ", Valid until: " + cert.NotAfter.ToShortDateString();
            }
            catch
            {
                return "Certificate information is not available.";
            }
        }

        private void showCertificatesFromStore(string loadStore)
        {
            try
            {
                if (loadStore == "Current User")
                    signingCerts = GetCertificatesFromStore(StoreLocation.CurrentUser);
                else
                    signingCerts = GetCertificatesFromStore(StoreLocation.LocalMachine);

                comboBoxCertificates.Items.Clear();

                comboBoxCertificates.Items.Add("<No certificate selected>");

                foreach (X509Certificate2 cert in signingCerts)
                    comboBoxCertificates.Items.Add(cert.GetNameInfo(X509NameType.SimpleName, false));

                if (signingCerts.Count > 0)
                    comboBoxCertificates.SelectedIndex = 1;
                else
                {
                    comboBoxCertificates.SelectedIndex = 0;
                    labelCertificateInformation.Text = "No certificates was found on " + comboBoxCertificateStore.Text + " certificate store.";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private X509Certificate2 getCertificateFromPFX()
        {
            try
            {
                X509Certificate2 tempCert = new X509Certificate2(File.ReadAllBytes(textBoxPFXFile.Text), textBoxPFXPassword.Text);

                if (tempCert.HasPrivateKey == true)
                    return new X509Certificate2(File.ReadAllBytes(textBoxPFXFile.Text), textBoxPFXPassword.Text);
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        public FrmCertificates()
        {
            InitializeComponent();
        }

        private void FrmCertificates_Load(object sender, EventArgs e)
        {
            try
            {
                setInitialValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxInterfaceCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                interfaceCheck();
            }
            catch
            {
            }
        }

        private void buttonShowSigninigCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonWindowsCertificateStore.Checked == true)
                {
                    if (comboBoxCertificates.SelectedIndex > 0)
                        X509Certificate2UI.DisplayCertificate(new X509Certificate2(signingCerts[comboBoxCertificates.SelectedIndex - 1]));
                }
                else
                {
                    verifyConfiguration();
                    X509Certificate2UI.DisplayCertificate(getCertificateFromPFX());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void comboBoxCertificateStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                showCertificatesFromStore(comboBoxCertificateStore.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxCertificates_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxCertificates.SelectedIndex > 0)
                {
                    labelCertificateInformation.Text = getCertificateInfo(signingCerts[comboBoxCertificates.SelectedIndex - 1]);

                    if (signingCerts[comboBoxCertificates.SelectedIndex - 1].HasPrivateKey == false)
                        MessageBox.Show("The private key of the selected certificate cannot be found.\r\nThe certificate cannot be used for digital signature operations.\r\n\r\nSelect another digital certificate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    labelCertificateInformation.Text = "Certificate information is not available."; //no certificate selected
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButtonSelectCertificateLocation_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                interfaceCheck();

                if (radioButtonWindowsCertificateStore.Checked == true)
                {
                    showCertificatesFromStore(comboBoxCertificateStore.Text);
                }
                else
                {
                      labelCertificateInformation.Text = getCertificateInfo(getCertificateFromPFX());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSelectPFXCertificate_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openPDFFile = new OpenFileDialog();
                openPDFFile.Multiselect = false;
                openPDFFile.Filter = "PFX digital certificates *.pfx|*.pfx";
                openPDFFile.Title = "Select the PFX certificate";
                if (openPDFFile.ShowDialog() != DialogResult.OK)
                    return;

                textBoxPFXFile.Text = openPDFFile.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPFXFile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                labelCertificateInformation.Text = getCertificateInfo(getCertificateFromPFX());
            }
            catch
            {
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonWindowsCertificateStore.Checked == true)
                    signingCert = signingCerts[comboBoxCertificates.SelectedIndex - 1];
                else
                    signingCert = new X509Certificate2(textBoxPFXFile.Text, textBoxPFXPassword.Text);

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
