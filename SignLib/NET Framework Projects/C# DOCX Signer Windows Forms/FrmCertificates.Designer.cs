namespace DOCXSigner
{
    partial class FrmCertificates
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
            this.labelSelectTheDigitalCertificate = new System.Windows.Forms.Label();
            this.radioButtonPFXCertificate = new System.Windows.Forms.RadioButton();
            this.radioButtonWindowsCertificateStore = new System.Windows.Forms.RadioButton();
            this.groupBoxPFXCertificate = new System.Windows.Forms.GroupBox();
            this.PFXFilePassword = new System.Windows.Forms.Label();
            this.buttonSelectPFXCertificate = new System.Windows.Forms.Button();
            this.textBoxPFXPassword = new System.Windows.Forms.TextBox();
            this.textBoxPFXFile = new System.Windows.Forms.TextBox();
            this.buttonShowSigninigCertificatePFX = new System.Windows.Forms.Button();
            this.groupBoxWindowsCertificateStore = new System.Windows.Forms.GroupBox();
            this.comboBoxCertificateStore = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxShowExpiredCertificates = new System.Windows.Forms.CheckBox();
            this.comboBoxCertificates = new System.Windows.Forms.ComboBox();
            this.buttonShowSigninigCertificateStore = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCertificateInformation = new System.Windows.Forms.Label();
            this.groupBoxPFXCertificate.SuspendLayout();
            this.groupBoxWindowsCertificateStore.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSelectTheDigitalCertificate
            // 
            this.labelSelectTheDigitalCertificate.AutoSize = true;
            this.labelSelectTheDigitalCertificate.Location = new System.Drawing.Point(10, 14);
            this.labelSelectTheDigitalCertificate.Name = "labelSelectTheDigitalCertificate";
            this.labelSelectTheDigitalCertificate.Size = new System.Drawing.Size(251, 13);
            this.labelSelectTheDigitalCertificate.TabIndex = 0;
            this.labelSelectTheDigitalCertificate.Text = "Select the digital certificate used for digital signature";
            // 
            // radioButtonPFXCertificate
            // 
            this.radioButtonPFXCertificate.AutoSize = true;
            this.radioButtonPFXCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonPFXCertificate.Location = new System.Drawing.Point(22, 161);
            this.radioButtonPFXCertificate.Name = "radioButtonPFXCertificate";
            this.radioButtonPFXCertificate.Size = new System.Drawing.Size(168, 17);
            this.radioButtonPFXCertificate.TabIndex = 3;
            this.radioButtonPFXCertificate.Text = "PFX digital certificate file";
            this.radioButtonPFXCertificate.UseVisualStyleBackColor = true;
            this.radioButtonPFXCertificate.CheckedChanged += new System.EventHandler(this.radioButtonSelectCertificateLocation_CheckedChanged);
            // 
            // radioButtonWindowsCertificateStore
            // 
            this.radioButtonWindowsCertificateStore.AutoSize = true;
            this.radioButtonWindowsCertificateStore.Checked = true;
            this.radioButtonWindowsCertificateStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonWindowsCertificateStore.Location = new System.Drawing.Point(21, 39);
            this.radioButtonWindowsCertificateStore.Name = "radioButtonWindowsCertificateStore";
            this.radioButtonWindowsCertificateStore.Size = new System.Drawing.Size(172, 17);
            this.radioButtonWindowsCertificateStore.TabIndex = 1;
            this.radioButtonWindowsCertificateStore.TabStop = true;
            this.radioButtonWindowsCertificateStore.Text = "Windows Certificate Store";
            this.radioButtonWindowsCertificateStore.UseVisualStyleBackColor = true;
            this.radioButtonWindowsCertificateStore.CheckedChanged += new System.EventHandler(this.radioButtonSelectCertificateLocation_CheckedChanged);
            // 
            // groupBoxPFXCertificate
            // 
            this.groupBoxPFXCertificate.Controls.Add(this.PFXFilePassword);
            this.groupBoxPFXCertificate.Controls.Add(this.buttonSelectPFXCertificate);
            this.groupBoxPFXCertificate.Controls.Add(this.textBoxPFXPassword);
            this.groupBoxPFXCertificate.Controls.Add(this.textBoxPFXFile);
            this.groupBoxPFXCertificate.Controls.Add(this.buttonShowSigninigCertificatePFX);
            this.groupBoxPFXCertificate.Enabled = false;
            this.groupBoxPFXCertificate.Location = new System.Drawing.Point(14, 186);
            this.groupBoxPFXCertificate.Name = "groupBoxPFXCertificate";
            this.groupBoxPFXCertificate.Size = new System.Drawing.Size(379, 87);
            this.groupBoxPFXCertificate.TabIndex = 4;
            this.groupBoxPFXCertificate.TabStop = false;
            this.groupBoxPFXCertificate.Text = "PFX Certificate File";
            // 
            // PFXFilePassword
            // 
            this.PFXFilePassword.AutoSize = true;
            this.PFXFilePassword.Location = new System.Drawing.Point(8, 56);
            this.PFXFilePassword.Name = "PFXFilePassword";
            this.PFXFilePassword.Size = new System.Drawing.Size(94, 13);
            this.PFXFilePassword.TabIndex = 2;
            this.PFXFilePassword.Text = "PFX file password:";
            // 
            // buttonSelectPFXCertificate
            // 
            this.buttonSelectPFXCertificate.Location = new System.Drawing.Point(8, 22);
            this.buttonSelectPFXCertificate.Name = "buttonSelectPFXCertificate";
            this.buttonSelectPFXCertificate.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectPFXCertificate.TabIndex = 0;
            this.buttonSelectPFXCertificate.Text = "...";
            this.buttonSelectPFXCertificate.UseVisualStyleBackColor = true;
            this.buttonSelectPFXCertificate.Click += new System.EventHandler(this.buttonSelectPFXCertificate_Click);
            // 
            // textBoxPFXPassword
            // 
            this.textBoxPFXPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPFXPassword.Location = new System.Drawing.Point(108, 52);
            this.textBoxPFXPassword.Name = "textBoxPFXPassword";
            this.textBoxPFXPassword.Size = new System.Drawing.Size(194, 20);
            this.textBoxPFXPassword.TabIndex = 3;
            this.textBoxPFXPassword.UseSystemPasswordChar = true;
            this.textBoxPFXPassword.TextChanged += new System.EventHandler(this.textBoxPFXFile_TextChanged);
            // 
            // textBoxPFXFile
            // 
            this.textBoxPFXFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPFXFile.Location = new System.Drawing.Point(46, 22);
            this.textBoxPFXFile.Name = "textBoxPFXFile";
            this.textBoxPFXFile.Size = new System.Drawing.Size(327, 20);
            this.textBoxPFXFile.TabIndex = 1;
            this.textBoxPFXFile.TextChanged += new System.EventHandler(this.textBoxPFXFile_TextChanged);
            // 
            // buttonShowSigninigCertificatePFX
            // 
            this.buttonShowSigninigCertificatePFX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowSigninigCertificatePFX.Location = new System.Drawing.Point(308, 51);
            this.buttonShowSigninigCertificatePFX.Name = "buttonShowSigninigCertificatePFX";
            this.buttonShowSigninigCertificatePFX.Size = new System.Drawing.Size(65, 23);
            this.buttonShowSigninigCertificatePFX.TabIndex = 4;
            this.buttonShowSigninigCertificatePFX.Text = "Show";
            this.buttonShowSigninigCertificatePFX.UseVisualStyleBackColor = true;
            this.buttonShowSigninigCertificatePFX.Click += new System.EventHandler(this.buttonShowSigninigCertificate_Click);
            // 
            // groupBoxWindowsCertificateStore
            // 
            this.groupBoxWindowsCertificateStore.Controls.Add(this.comboBoxCertificateStore);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.label1);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.checkBoxShowExpiredCertificates);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.comboBoxCertificates);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.buttonShowSigninigCertificateStore);
            this.groupBoxWindowsCertificateStore.Location = new System.Drawing.Point(13, 64);
            this.groupBoxWindowsCertificateStore.Name = "groupBoxWindowsCertificateStore";
            this.groupBoxWindowsCertificateStore.Size = new System.Drawing.Size(379, 89);
            this.groupBoxWindowsCertificateStore.TabIndex = 2;
            this.groupBoxWindowsCertificateStore.TabStop = false;
            this.groupBoxWindowsCertificateStore.Text = "Certificates Available on Microsoft Store";
            // 
            // comboBoxCertificateStore
            // 
            this.comboBoxCertificateStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCertificateStore.FormattingEnabled = true;
            this.comboBoxCertificateStore.Items.AddRange(new object[] {
            "Current User",
            "Local Machine"});
            this.comboBoxCertificateStore.Location = new System.Drawing.Point(100, 26);
            this.comboBoxCertificateStore.Name = "comboBoxCertificateStore";
            this.comboBoxCertificateStore.Size = new System.Drawing.Size(94, 21);
            this.comboBoxCertificateStore.TabIndex = 1;
            this.comboBoxCertificateStore.SelectedIndexChanged += new System.EventHandler(this.comboBoxCertificateStore_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Certificate Store:";
            // 
            // checkBoxShowExpiredCertificates
            // 
            this.checkBoxShowExpiredCertificates.AutoSize = true;
            this.checkBoxShowExpiredCertificates.Location = new System.Drawing.Point(208, 29);
            this.checkBoxShowExpiredCertificates.Name = "checkBoxShowExpiredCertificates";
            this.checkBoxShowExpiredCertificates.Size = new System.Drawing.Size(144, 17);
            this.checkBoxShowExpiredCertificates.TabIndex = 2;
            this.checkBoxShowExpiredCertificates.Text = "Show expired certificates";
            this.checkBoxShowExpiredCertificates.UseVisualStyleBackColor = true;
            this.checkBoxShowExpiredCertificates.CheckedChanged += new System.EventHandler(this.comboBoxCertificateStore_SelectedIndexChanged);
            // 
            // comboBoxCertificates
            // 
            this.comboBoxCertificates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCertificates.FormattingEnabled = true;
            this.comboBoxCertificates.Location = new System.Drawing.Point(9, 56);
            this.comboBoxCertificates.Name = "comboBoxCertificates";
            this.comboBoxCertificates.Size = new System.Drawing.Size(293, 21);
            this.comboBoxCertificates.TabIndex = 3;
            this.comboBoxCertificates.SelectedIndexChanged += new System.EventHandler(this.comboBoxCertificates_SelectedIndexChanged);
            // 
            // buttonShowSigninigCertificateStore
            // 
            this.buttonShowSigninigCertificateStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowSigninigCertificateStore.Location = new System.Drawing.Point(308, 54);
            this.buttonShowSigninigCertificateStore.Name = "buttonShowSigninigCertificateStore";
            this.buttonShowSigninigCertificateStore.Size = new System.Drawing.Size(65, 23);
            this.buttonShowSigninigCertificateStore.TabIndex = 4;
            this.buttonShowSigninigCertificateStore.Text = "Show";
            this.buttonShowSigninigCertificateStore.UseVisualStyleBackColor = true;
            this.buttonShowSigninigCertificateStore.Click += new System.EventHandler(this.buttonShowSigninigCertificate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(307, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(226, 364);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 7;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelCertificateInformation);
            this.groupBox1.Location = new System.Drawing.Point(15, 279);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 74);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Certificate Information";
            // 
            // labelCertificateInformation
            // 
            this.labelCertificateInformation.Location = new System.Drawing.Point(8, 17);
            this.labelCertificateInformation.Name = "labelCertificateInformation";
            this.labelCertificateInformation.Size = new System.Drawing.Size(359, 48);
            this.labelCertificateInformation.TabIndex = 0;
            this.labelCertificateInformation.Text = "label3";
            // 
            // FrmCertificates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(402, 395);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelSelectTheDigitalCertificate);
            this.Controls.Add(this.radioButtonPFXCertificate);
            this.Controls.Add(this.radioButtonWindowsCertificateStore);
            this.Controls.Add(this.groupBoxPFXCertificate);
            this.Controls.Add(this.groupBoxWindowsCertificateStore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCertificates";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Digital Certificates";
            this.Load += new System.EventHandler(this.FrmCertificates_Load);
            this.groupBoxPFXCertificate.ResumeLayout(false);
            this.groupBoxPFXCertificate.PerformLayout();
            this.groupBoxWindowsCertificateStore.ResumeLayout(false);
            this.groupBoxWindowsCertificateStore.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectTheDigitalCertificate;
        private System.Windows.Forms.RadioButton radioButtonPFXCertificate;
        private System.Windows.Forms.RadioButton radioButtonWindowsCertificateStore;
        private System.Windows.Forms.GroupBox groupBoxPFXCertificate;
        private System.Windows.Forms.Label PFXFilePassword;
        private System.Windows.Forms.Button buttonSelectPFXCertificate;
        private System.Windows.Forms.TextBox textBoxPFXPassword;
        private System.Windows.Forms.TextBox textBoxPFXFile;
        private System.Windows.Forms.GroupBox groupBoxWindowsCertificateStore;
        private System.Windows.Forms.CheckBox checkBoxShowExpiredCertificates;
        private System.Windows.Forms.ComboBox comboBoxCertificates;
        private System.Windows.Forms.Button buttonShowSigninigCertificateStore;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxCertificateStore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCertificateInformation;
        private System.Windows.Forms.Button buttonShowSigninigCertificatePFX;
    }
}