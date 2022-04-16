namespace DOCXSigner
{
    partial class FrmMain
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
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.labelDigitallySign = new System.Windows.Forms.Label();
            this.buttonSelectDestination = new System.Windows.Forms.Button();
            this.labelDestination = new System.Windows.Forms.Label();
            this.textBoxDestinationPath = new System.Windows.Forms.TextBox();
            this.radioButtonFolderWithDocuments = new System.Windows.Forms.RadioButton();
            this.labelSource = new System.Windows.Forms.Label();
            this.radioButtonSingleDocument = new System.Windows.Forms.RadioButton();
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.textBoxSourcePath = new System.Windows.Forms.TextBox();
            this.buttonApplyDigitalSignature = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarSign = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxPath.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.labelDigitallySign);
            this.groupBoxPath.Controls.Add(this.buttonSelectDestination);
            this.groupBoxPath.Controls.Add(this.labelDestination);
            this.groupBoxPath.Controls.Add(this.textBoxDestinationPath);
            this.groupBoxPath.Controls.Add(this.radioButtonFolderWithDocuments);
            this.groupBoxPath.Controls.Add(this.labelSource);
            this.groupBoxPath.Controls.Add(this.radioButtonSingleDocument);
            this.groupBoxPath.Controls.Add(this.buttonSelectSource);
            this.groupBoxPath.Controls.Add(this.textBoxSourcePath);
            this.groupBoxPath.Location = new System.Drawing.Point(12, 20);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(386, 156);
            this.groupBoxPath.TabIndex = 0;
            this.groupBoxPath.TabStop = false;
            // 
            // labelDigitallySign
            // 
            this.labelDigitallySign.AutoSize = true;
            this.labelDigitallySign.Location = new System.Drawing.Point(6, 19);
            this.labelDigitallySign.Name = "labelDigitallySign";
            this.labelDigitallySign.Size = new System.Drawing.Size(68, 13);
            this.labelDigitallySign.TabIndex = 0;
            this.labelDigitallySign.Text = "Digitally sign:";
            // 
            // buttonSelectDestination
            // 
            this.buttonSelectDestination.Location = new System.Drawing.Point(5, 126);
            this.buttonSelectDestination.Name = "buttonSelectDestination";
            this.buttonSelectDestination.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectDestination.TabIndex = 9;
            this.buttonSelectDestination.Text = "...";
            this.buttonSelectDestination.UseVisualStyleBackColor = true;
            this.buttonSelectDestination.Click += new System.EventHandler(this.buttonSelectDestination_Click);
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(6, 109);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(63, 13);
            this.labelDestination.TabIndex = 8;
            this.labelDestination.Text = "Destination:";
            // 
            // textBoxDestinationPath
            // 
            this.textBoxDestinationPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDestinationPath.Location = new System.Drawing.Point(43, 126);
            this.textBoxDestinationPath.Name = "textBoxDestinationPath";
            this.textBoxDestinationPath.Size = new System.Drawing.Size(333, 20);
            this.textBoxDestinationPath.TabIndex = 10;
            // 
            // radioButtonFolderWithDocuments
            // 
            this.radioButtonFolderWithDocuments.AutoSize = true;
            this.radioButtonFolderWithDocuments.Location = new System.Drawing.Point(160, 39);
            this.radioButtonFolderWithDocuments.Name = "radioButtonFolderWithDocuments";
            this.radioButtonFolderWithDocuments.Size = new System.Drawing.Size(138, 17);
            this.radioButtonFolderWithDocuments.TabIndex = 2;
            this.radioButtonFolderWithDocuments.Text = "A folder with documents";
            this.radioButtonFolderWithDocuments.UseVisualStyleBackColor = true;
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(6, 61);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 3;
            this.labelSource.Text = "Source:";
            // 
            // radioButtonSingleDocument
            // 
            this.radioButtonSingleDocument.AutoSize = true;
            this.radioButtonSingleDocument.Checked = true;
            this.radioButtonSingleDocument.Location = new System.Drawing.Point(9, 39);
            this.radioButtonSingleDocument.Name = "radioButtonSingleDocument";
            this.radioButtonSingleDocument.Size = new System.Drawing.Size(112, 17);
            this.radioButtonSingleDocument.TabIndex = 1;
            this.radioButtonSingleDocument.TabStop = true;
            this.radioButtonSingleDocument.Text = "A single document";
            this.radioButtonSingleDocument.UseVisualStyleBackColor = true;
            this.radioButtonSingleDocument.CheckedChanged += new System.EventHandler(this.radioButtonSingleDocument_CheckedChanged);
            // 
            // buttonSelectSource
            // 
            this.buttonSelectSource.Location = new System.Drawing.Point(6, 78);
            this.buttonSelectSource.Name = "buttonSelectSource";
            this.buttonSelectSource.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectSource.TabIndex = 4;
            this.buttonSelectSource.Text = "...";
            this.buttonSelectSource.UseVisualStyleBackColor = true;
            this.buttonSelectSource.Click += new System.EventHandler(this.buttonSelectSource_Click);
            // 
            // textBoxSourcePath
            // 
            this.textBoxSourcePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSourcePath.Location = new System.Drawing.Point(44, 78);
            this.textBoxSourcePath.Name = "textBoxSourcePath";
            this.textBoxSourcePath.Size = new System.Drawing.Size(332, 20);
            this.textBoxSourcePath.TabIndex = 5;
            // 
            // buttonApplyDigitalSignature
            // 
            this.buttonApplyDigitalSignature.Location = new System.Drawing.Point(183, 182);
            this.buttonApplyDigitalSignature.Name = "buttonApplyDigitalSignature";
            this.buttonApplyDigitalSignature.Size = new System.Drawing.Size(140, 23);
            this.buttonApplyDigitalSignature.TabIndex = 6;
            this.buttonApplyDigitalSignature.Text = "Apply Digital Signature";
            this.buttonApplyDigitalSignature.UseVisualStyleBackColor = true;
            this.buttonApplyDigitalSignature.Click += new System.EventHandler(this.buttonApplyDigitalSignature_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(329, 182);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(59, 23);
            this.buttonExit.TabIndex = 7;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBarSign});
            this.statusStrip.Location = new System.Drawing.Point(0, 224);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(407, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel.Text = "DOCX Signer";
            // 
            // toolStripProgressBarSign
            // 
            this.toolStripProgressBarSign.Minimum = 1;
            this.toolStripProgressBarSign.Name = "toolStripProgressBarSign";
            this.toolStripProgressBarSign.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBarSign.Value = 1;
            this.toolStripProgressBarSign.Visible = false;
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 246);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonApplyDigitalSignature);
            this.Controls.Add(this.groupBoxPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DOCX Signer";
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.Label labelDigitallySign;
        private System.Windows.Forms.Button buttonSelectDestination;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.TextBox textBoxDestinationPath;
        private System.Windows.Forms.RadioButton radioButtonFolderWithDocuments;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.RadioButton radioButtonSingleDocument;
        private System.Windows.Forms.Button buttonSelectSource;
        private System.Windows.Forms.TextBox textBoxSourcePath;
        private System.Windows.Forms.Button buttonApplyDigitalSignature;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarSign;
    }
}

