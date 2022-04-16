namespace CertSelector
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
            this.comboBoxCertificates = new System.Windows.Forms.ComboBox();
            this.buttonShowSigninigCertificate = new System.Windows.Forms.Button();
            this.labelCertificates = new System.Windows.Forms.Label();
            this.checkBoxValidOnly = new System.Windows.Forms.CheckBox();
            this.groupBoxWindowsCertificateStore = new System.Windows.Forms.GroupBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxWindowsCertificateStore.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxCertificates
            // 
            this.comboBoxCertificates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCertificates.FormattingEnabled = true;
            this.comboBoxCertificates.Location = new System.Drawing.Point(8, 42);
            this.comboBoxCertificates.Name = "comboBoxCertificates";
            this.comboBoxCertificates.Size = new System.Drawing.Size(286, 21);
            this.comboBoxCertificates.TabIndex = 1;
            this.comboBoxCertificates.SelectedIndexChanged += new System.EventHandler(this.comboBoxCertificates_SelectedIndexChanged);
            // 
            // buttonShowSigninigCertificate
            // 
            this.buttonShowSigninigCertificate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowSigninigCertificate.Location = new System.Drawing.Point(300, 42);
            this.buttonShowSigninigCertificate.Name = "buttonShowSigninigCertificate";
            this.buttonShowSigninigCertificate.Size = new System.Drawing.Size(91, 21);
            this.buttonShowSigninigCertificate.TabIndex = 2;
            this.buttonShowSigninigCertificate.Text = "Show certificate";
            this.buttonShowSigninigCertificate.UseVisualStyleBackColor = true;
            this.buttonShowSigninigCertificate.Click += new System.EventHandler(this.buttonShowSigninigCertificate_Click);
            // 
            // labelCertificates
            // 
            this.labelCertificates.Location = new System.Drawing.Point(8, 70);
            this.labelCertificates.Name = "labelCertificates";
            this.labelCertificates.Size = new System.Drawing.Size(382, 13);
            this.labelCertificates.TabIndex = 3;
            this.labelCertificates.Text = "certificates";
            // 
            // checkBoxValidOnly
            // 
            this.checkBoxValidOnly.AutoSize = true;
            this.checkBoxValidOnly.Location = new System.Drawing.Point(8, 19);
            this.checkBoxValidOnly.Name = "checkBoxValidOnly";
            this.checkBoxValidOnly.Size = new System.Drawing.Size(146, 17);
            this.checkBoxValidOnly.TabIndex = 5;
            this.checkBoxValidOnly.Text = "Use only valid certificates";
            this.checkBoxValidOnly.UseVisualStyleBackColor = true;
            this.checkBoxValidOnly.CheckedChanged += new System.EventHandler(this.checkBoxValidOnly_CheckedChanged);
            // 
            // groupBoxWindowsCertificateStore
            // 
            this.groupBoxWindowsCertificateStore.Controls.Add(this.checkBoxValidOnly);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.comboBoxCertificates);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.buttonShowSigninigCertificate);
            this.groupBoxWindowsCertificateStore.Controls.Add(this.labelCertificates);
            this.groupBoxWindowsCertificateStore.Location = new System.Drawing.Point(5, 18);
            this.groupBoxWindowsCertificateStore.Name = "groupBoxWindowsCertificateStore";
            this.groupBoxWindowsCertificateStore.Size = new System.Drawing.Size(397, 93);
            this.groupBoxWindowsCertificateStore.TabIndex = 6;
            this.groupBoxWindowsCertificateStore.TabStop = false;
            this.groupBoxWindowsCertificateStore.Text = "Installed certificates";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(337, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(59, 23);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // CertificateSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(407, 168);
            this.Controls.Add(this.groupBoxWindowsCertificateStore);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CertificateSelection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Certificate Selector";
            this.Load += new System.EventHandler(this.CertificateSelection_Load);
            this.groupBoxWindowsCertificateStore.ResumeLayout(false);
            this.groupBoxWindowsCertificateStore.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCertificates;
        private System.Windows.Forms.Button buttonShowSigninigCertificate;
        private System.Windows.Forms.Label labelCertificates;
        private System.Windows.Forms.CheckBox checkBoxValidOnly;
        private System.Windows.Forms.GroupBox groupBoxWindowsCertificateStore;
        private System.Windows.Forms.Button buttonCancel;
    }
}