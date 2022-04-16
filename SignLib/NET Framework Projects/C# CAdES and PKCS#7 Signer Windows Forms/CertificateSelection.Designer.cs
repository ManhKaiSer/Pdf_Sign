namespace FileSigner
{
    partial class CertificateSelection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CertificateSelection));
            this.buttonOK = new System.Windows.Forms.Button();
            this.linkLabelCertificates = new System.Windows.Forms.LinkLabel();
            this.checkBoxValidOnly = new System.Windows.Forms.CheckBox();
            this.radioButtonWindowsCertStore = new System.Windows.Forms.RadioButton();
            this.radioButtonPFXCert = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPFXCertificate = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSelectPFX = new System.Windows.Forms.Button();
            this.textBoxPFXPassword = new System.Windows.Forms.TextBox();
            this.textBoxPFXFile = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxPFXCertificate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(304, 203);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "Apply signature";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // linkLabelCertificates
            // 
            this.linkLabelCertificates.AutoSize = true;
            this.linkLabelCertificates.Location = new System.Drawing.Point(9, 208);
            this.linkLabelCertificates.Name = "linkLabelCertificates";
            this.linkLabelCertificates.Size = new System.Drawing.Size(112, 13);
            this.linkLabelCertificates.TabIndex = 4;
            this.linkLabelCertificates.TabStop = true;
            this.linkLabelCertificates.Text = "Get a digital certificate";
            this.linkLabelCertificates.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelCertificates_LinkClicked);
            // 
            // checkBoxValidOnly
            // 
            this.checkBoxValidOnly.AutoSize = true;
            this.checkBoxValidOnly.Location = new System.Drawing.Point(32, 63);
            this.checkBoxValidOnly.Name = "checkBoxValidOnly";
            this.checkBoxValidOnly.Size = new System.Drawing.Size(146, 17);
            this.checkBoxValidOnly.TabIndex = 5;
            this.checkBoxValidOnly.Text = "Use only valid certificates";
            this.checkBoxValidOnly.UseVisualStyleBackColor = true;
            // 
            // radioButtonWindowsCertStore
            // 
            this.radioButtonWindowsCertStore.AutoSize = true;
            this.radioButtonWindowsCertStore.Checked = true;
            this.radioButtonWindowsCertStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonWindowsCertStore.Location = new System.Drawing.Point(13, 40);
            this.radioButtonWindowsCertStore.Name = "radioButtonWindowsCertStore";
            this.radioButtonWindowsCertStore.Size = new System.Drawing.Size(172, 17);
            this.radioButtonWindowsCertStore.TabIndex = 7;
            this.radioButtonWindowsCertStore.TabStop = true;
            this.radioButtonWindowsCertStore.Text = "Windows Certificate Store";
            this.radioButtonWindowsCertStore.UseVisualStyleBackColor = true;
            this.radioButtonWindowsCertStore.CheckedChanged += new System.EventHandler(this.radioButtonWindowsCertStore_CheckedChanged);
            // 
            // radioButtonPFXCert
            // 
            this.radioButtonPFXCert.AutoSize = true;
            this.radioButtonPFXCert.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPFXCert.Location = new System.Drawing.Point(12, 98);
            this.radioButtonPFXCert.Name = "radioButtonPFXCert";
            this.radioButtonPFXCert.Size = new System.Drawing.Size(168, 17);
            this.radioButtonPFXCert.TabIndex = 7;
            this.radioButtonPFXCert.Text = "PFX digital certificate file";
            this.radioButtonPFXCert.UseVisualStyleBackColor = true;
            this.radioButtonPFXCert.CheckedChanged += new System.EventHandler(this.radioButtonWindowsCertStore_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Select the digital certificate used for signing";
            // 
            // groupBoxPFXCertificate
            // 
            this.groupBoxPFXCertificate.Controls.Add(this.label2);
            this.groupBoxPFXCertificate.Controls.Add(this.buttonSelectPFX);
            this.groupBoxPFXCertificate.Controls.Add(this.textBoxPFXPassword);
            this.groupBoxPFXCertificate.Controls.Add(this.textBoxPFXFile);
            this.groupBoxPFXCertificate.Enabled = false;
            this.groupBoxPFXCertificate.Location = new System.Drawing.Point(4, 121);
            this.groupBoxPFXCertificate.Name = "groupBoxPFXCertificate";
            this.groupBoxPFXCertificate.Size = new System.Drawing.Size(397, 76);
            this.groupBoxPFXCertificate.TabIndex = 6;
            this.groupBoxPFXCertificate.TabStop = false;
            this.groupBoxPFXCertificate.Text = "PFX certificate file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "PFX file password:";
            // 
            // buttonSelectPFX
            // 
            this.buttonSelectPFX.Location = new System.Drawing.Point(8, 19);
            this.buttonSelectPFX.Name = "buttonSelectPFX";
            this.buttonSelectPFX.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectPFX.TabIndex = 4;
            this.buttonSelectPFX.Text = "...";
            this.buttonSelectPFX.UseVisualStyleBackColor = true;
            this.buttonSelectPFX.Click += new System.EventHandler(this.buttonSelectPFX_Click);
            // 
            // textBoxPFXPassword
            // 
            this.textBoxPFXPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPFXPassword.Location = new System.Drawing.Point(108, 45);
            this.textBoxPFXPassword.Name = "textBoxPFXPassword";
            this.textBoxPFXPassword.Size = new System.Drawing.Size(282, 20);
            this.textBoxPFXPassword.TabIndex = 5;
            this.textBoxPFXPassword.UseSystemPasswordChar = true;
            // 
            // textBoxPFXFile
            // 
            this.textBoxPFXFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPFXFile.Location = new System.Drawing.Point(46, 19);
            this.textBoxPFXFile.Name = "textBoxPFXFile";
            this.textBoxPFXFile.Size = new System.Drawing.Size(344, 20);
            this.textBoxPFXFile.TabIndex = 5;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(239, 203);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // CertificateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(407, 234);
            this.Controls.Add(this.checkBoxValidOnly);
            this.Controls.Add(this.linkLabelCertificates);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonPFXCert);
            this.Controls.Add(this.radioButtonWindowsCertStore);
            this.Controls.Add(this.groupBoxPFXCertificate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CertificateSelection";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Signing certificate";
            this.groupBoxPFXCertificate.ResumeLayout(false);
            this.groupBoxPFXCertificate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.LinkLabel linkLabelCertificates;
        private System.Windows.Forms.CheckBox checkBoxValidOnly;
        private System.Windows.Forms.RadioButton radioButtonWindowsCertStore;
        private System.Windows.Forms.RadioButton radioButtonPFXCert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxPFXCertificate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSelectPFX;
        private System.Windows.Forms.TextBox textBoxPFXPassword;
        private System.Windows.Forms.TextBox textBoxPFXFile;
        private System.Windows.Forms.Button buttonCancel;
    }
}