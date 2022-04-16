namespace FileSigner
{
    partial class FileSigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileSigner));
            this.inputBox = new System.Windows.Forms.TextBox();
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.buttonSelectDestination = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.checkBoxTimeStamp = new System.Windows.Forms.CheckBox();
            this.buttonSign = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.textBoxVerifyFile = new System.Windows.Forms.TextBox();
            this.buttonVerifySignedFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxSignatureInfo = new System.Windows.Forms.TextBox();
            this.buttonUnsignedFile = new System.Windows.Forms.Button();
            this.groupBoxPath.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(44, 32);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(367, 20);
            this.inputBox.TabIndex = 3;
            // 
            // buttonSelectSource
            // 
            this.buttonSelectSource.Location = new System.Drawing.Point(6, 32);
            this.buttonSelectSource.Name = "buttonSelectSource";
            this.buttonSelectSource.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectSource.TabIndex = 2;
            this.buttonSelectSource.Text = "...";
            this.buttonSelectSource.UseVisualStyleBackColor = true;
            this.buttonSelectSource.Click += new System.EventHandler(this.buttonSource_Click);
            // 
            // outputBox
            // 
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.Location = new System.Drawing.Point(44, 80);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(367, 20);
            this.outputBox.TabIndex = 5;
            // 
            // buttonSelectDestination
            // 
            this.buttonSelectDestination.Location = new System.Drawing.Point(6, 80);
            this.buttonSelectDestination.Name = "buttonSelectDestination";
            this.buttonSelectDestination.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectDestination.TabIndex = 4;
            this.buttonSelectDestination.Text = "...";
            this.buttonSelectDestination.UseVisualStyleBackColor = true;
            this.buttonSelectDestination.Click += new System.EventHandler(this.buttonDestination_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Location = new System.Drawing.Point(358, 488);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 7;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelDestination
            // 
            this.labelDestination.AutoSize = true;
            this.labelDestination.Location = new System.Drawing.Point(6, 63);
            this.labelDestination.Name = "labelDestination";
            this.labelDestination.Size = new System.Drawing.Size(63, 13);
            this.labelDestination.TabIndex = 29;
            this.labelDestination.Text = "Destination:";
            // 
            // labelSource
            // 
            this.labelSource.AutoSize = true;
            this.labelSource.Location = new System.Drawing.Point(6, 16);
            this.labelSource.Name = "labelSource";
            this.labelSource.Size = new System.Drawing.Size(44, 13);
            this.labelSource.TabIndex = 29;
            this.labelSource.Text = "Source:";
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.checkBoxTimeStamp);
            this.groupBoxPath.Controls.Add(this.buttonSelectDestination);
            this.groupBoxPath.Controls.Add(this.labelDestination);
            this.groupBoxPath.Controls.Add(this.outputBox);
            this.groupBoxPath.Controls.Add(this.labelSource);
            this.groupBoxPath.Controls.Add(this.buttonSelectSource);
            this.groupBoxPath.Controls.Add(this.inputBox);
            this.groupBoxPath.Location = new System.Drawing.Point(12, 9);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(423, 132);
            this.groupBoxPath.TabIndex = 0;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Digitally sign files";
            // 
            // checkBoxTimeStamp
            // 
            this.checkBoxTimeStamp.AutoSize = true;
            this.checkBoxTimeStamp.Location = new System.Drawing.Point(19, 106);
            this.checkBoxTimeStamp.Name = "checkBoxTimeStamp";
            this.checkBoxTimeStamp.Size = new System.Drawing.Size(156, 17);
            this.checkBoxTimeStamp.TabIndex = 36;
            this.checkBoxTimeStamp.Text = "Add Time stamp information";
            this.checkBoxTimeStamp.UseVisualStyleBackColor = true;
            // 
            // buttonSign
            // 
            this.buttonSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSign.Location = new System.Drawing.Point(18, 147);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(100, 23);
            this.buttonSign.TabIndex = 5;
            this.buttonSign.Text = "Digitally Sign";
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Verify a signed file:";
            // 
            // buttonVerify
            // 
            this.buttonVerify.Location = new System.Drawing.Point(6, 32);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(32, 20);
            this.buttonVerify.TabIndex = 36;
            this.buttonVerify.Text = "...";
            this.buttonVerify.UseVisualStyleBackColor = true;
            this.buttonVerify.Click += new System.EventHandler(this.buttonVerify_Click);
            // 
            // textBoxVerifyFile
            // 
            this.textBoxVerifyFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVerifyFile.Location = new System.Drawing.Point(44, 32);
            this.textBoxVerifyFile.Name = "textBoxVerifyFile";
            this.textBoxVerifyFile.Size = new System.Drawing.Size(367, 20);
            this.textBoxVerifyFile.TabIndex = 37;
            // 
            // buttonVerifySignedFile
            // 
            this.buttonVerifySignedFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonVerifySignedFile.Location = new System.Drawing.Point(18, 259);
            this.buttonVerifySignedFile.Name = "buttonVerifySignedFile";
            this.buttonVerifySignedFile.Size = new System.Drawing.Size(100, 23);
            this.buttonVerifySignedFile.TabIndex = 5;
            this.buttonVerifySignedFile.Text = "Verify Signed File";
            this.buttonVerifySignedFile.UseVisualStyleBackColor = true;
            this.buttonVerifySignedFile.Click += new System.EventHandler(this.buttonVerifySignedFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxVerifyFile);
            this.groupBox1.Controls.Add(this.buttonVerify);
            this.groupBox1.Location = new System.Drawing.Point(12, 192);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 61);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Verify";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxSignatureInfo);
            this.groupBox2.Location = new System.Drawing.Point(12, 288);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 194);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Signature Information";
            // 
            // textBoxSignatureInfo
            // 
            this.textBoxSignatureInfo.Location = new System.Drawing.Point(9, 19);
            this.textBoxSignatureInfo.Multiline = true;
            this.textBoxSignatureInfo.Name = "textBoxSignatureInfo";
            this.textBoxSignatureInfo.ReadOnly = true;
            this.textBoxSignatureInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSignatureInfo.Size = new System.Drawing.Size(402, 169);
            this.textBoxSignatureInfo.TabIndex = 0;
            // 
            // buttonUnsignedFile
            // 
            this.buttonUnsignedFile.Enabled = false;
            this.buttonUnsignedFile.Location = new System.Drawing.Point(124, 259);
            this.buttonUnsignedFile.Name = "buttonUnsignedFile";
            this.buttonUnsignedFile.Size = new System.Drawing.Size(116, 23);
            this.buttonUnsignedFile.TabIndex = 41;
            this.buttonUnsignedFile.Text = "Open unsigned file";
            this.buttonUnsignedFile.UseVisualStyleBackColor = true;
            this.buttonUnsignedFile.Click += new System.EventHandler(this.buttonUnsignedFile_Click);
            // 
            // FileSigner
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(445, 520);
            this.Controls.Add(this.buttonUnsignedFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.buttonVerifySignedFile);
            this.Controls.Add(this.buttonSign);
            this.Controls.Add(this.buttonQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FileSigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Signer";
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button buttonSelectSource;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button buttonSelectDestination;
        //private System.Windows.Forms.TextBox reasonText;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.TextBox textBoxVerifyFile;
        private System.Windows.Forms.Button buttonVerifySignedFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxTimeStamp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxSignatureInfo;
        private System.Windows.Forms.Button buttonUnsignedFile;
    }
}

