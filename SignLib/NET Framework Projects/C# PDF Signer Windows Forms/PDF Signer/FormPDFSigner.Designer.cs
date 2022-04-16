namespace PDFSigner
{
    partial class FormPDFSigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPDFSigner));
            this.inputBox = new System.Windows.Forms.TextBox();
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.buttonSelectDestination = new System.Windows.Forms.Button();
            this.labelSigningReason = new System.Windows.Forms.Label();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.checkBoxShowSignature = new System.Windows.Forms.CheckBox();
            this.comboBoxBasicSignaturePage = new System.Windows.Forms.ComboBox();
            this.comboBoxBasicSignaturePosition = new System.Windows.Forms.ComboBox();
            this.labelDestination = new System.Windows.Forms.Label();
            this.labelSource = new System.Windows.Forms.Label();
            this.locationText = new System.Windows.Forms.TextBox();
            this.labelSigningLocation = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.labelTimestampingServer = new System.Windows.Forms.Label();
            this.comboBoxTimestampingServer = new System.Windows.Forms.ComboBox();
            this.checkBoxTimestampDocument = new System.Windows.Forms.CheckBox();
            this.reasonText = new System.Windows.Forms.ComboBox();
            this.groupBoxPath = new System.Windows.Forms.GroupBox();
            this.buttonSign = new System.Windows.Forms.Button();
            this.groupBoxSignaturePosition = new System.Windows.Forms.GroupBox();
            this.textBoxAdvancedHeight = new System.Windows.Forms.TextBox();
            this.textBoxAdvancedWidth = new System.Windows.Forms.TextBox();
            this.textBoxAdvancedYCoord = new System.Windows.Forms.TextBox();
            this.labelAdvancedHeight = new System.Windows.Forms.Label();
            this.textBoxAdvancedXCoord = new System.Windows.Forms.TextBox();
            this.labelAdvancedWidth = new System.Windows.Forms.Label();
            this.labelAdvancedTopRight = new System.Windows.Forms.Label();
            this.labelAdvancedTopLeft = new System.Windows.Forms.Label();
            this.radioButtonAdvancedSignature = new System.Windows.Forms.RadioButton();
            this.radioButtonBasicSignature = new System.Windows.Forms.RadioButton();
            this.labelBasicPage = new System.Windows.Forms.Label();
            this.groupBoxSignatureOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxIncludeImage = new System.Windows.Forms.CheckBox();
            this.groupBoxSignatureImage = new System.Windows.Forms.GroupBox();
            this.radioButtonImageNoText = new System.Windows.Forms.RadioButton();
            this.radioButtonImageAndText = new System.Windows.Forms.RadioButton();
            this.radioButtonImageAsBackgorund = new System.Windows.Forms.RadioButton();
            this.textBoxImageFile = new System.Windows.Forms.TextBox();
            this.buttonSelectImage = new System.Windows.Forms.Button();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxPath.SuspendLayout();
            this.groupBoxSignaturePosition.SuspendLayout();
            this.groupBoxSignatureOptions.SuspendLayout();
            this.groupBoxSignatureImage.SuspendLayout();
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
            // labelSigningReason
            // 
            this.labelSigningReason.AutoSize = true;
            this.labelSigningReason.Location = new System.Drawing.Point(6, 22);
            this.labelSigningReason.Name = "labelSigningReason";
            this.labelSigningReason.Size = new System.Drawing.Size(80, 13);
            this.labelSigningReason.TabIndex = 29;
            this.labelSigningReason.Text = "Signing reason:";
            // 
            // buttonQuit
            // 
            this.buttonQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonQuit.Location = new System.Drawing.Point(353, 443);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(75, 23);
            this.buttonQuit.TabIndex = 7;
            this.buttonQuit.Text = "&Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // checkBoxShowSignature
            // 
            this.checkBoxShowSignature.AutoSize = true;
            this.checkBoxShowSignature.Checked = true;
            this.checkBoxShowSignature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowSignature.Location = new System.Drawing.Point(9, 119);
            this.checkBoxShowSignature.Name = "checkBoxShowSignature";
            this.checkBoxShowSignature.Size = new System.Drawing.Size(182, 17);
            this.checkBoxShowSignature.TabIndex = 0;
            this.checkBoxShowSignature.Text = "Show signature on the document";
            this.checkBoxShowSignature.UseVisualStyleBackColor = true;
            this.checkBoxShowSignature.CheckedChanged += new System.EventHandler(this.checkBoxVisible_CheckedChanged);
            // 
            // comboBoxBasicSignaturePage
            // 
            this.comboBoxBasicSignaturePage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBasicSignaturePage.FormattingEnabled = true;
            this.comboBoxBasicSignaturePage.Items.AddRange(new object[] {
            "First Page",
            "Last Page"});
            this.comboBoxBasicSignaturePage.Location = new System.Drawing.Point(63, 21);
            this.comboBoxBasicSignaturePage.Name = "comboBoxBasicSignaturePage";
            this.comboBoxBasicSignaturePage.Size = new System.Drawing.Size(94, 21);
            this.comboBoxBasicSignaturePage.TabIndex = 0;
            // 
            // comboBoxBasicSignaturePosition
            // 
            this.comboBoxBasicSignaturePosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBasicSignaturePosition.FormattingEnabled = true;
            this.comboBoxBasicSignaturePosition.Items.AddRange(new object[] {
            "Top Right",
            "Top Left",
            "Bottom Right",
            "Bottom Left"});
            this.comboBoxBasicSignaturePosition.Location = new System.Drawing.Point(63, 53);
            this.comboBoxBasicSignaturePosition.Name = "comboBoxBasicSignaturePosition";
            this.comboBoxBasicSignaturePosition.Size = new System.Drawing.Size(94, 21);
            this.comboBoxBasicSignaturePosition.TabIndex = 3;
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
            // locationText
            // 
            this.locationText.Location = new System.Drawing.Point(9, 83);
            this.locationText.Name = "locationText";
            this.locationText.Size = new System.Drawing.Size(223, 20);
            this.locationText.TabIndex = 1;
            // 
            // labelSigningLocation
            // 
            this.labelSigningLocation.AutoSize = true;
            this.labelSigningLocation.Location = new System.Drawing.Point(6, 67);
            this.labelSigningLocation.Name = "labelSigningLocation";
            this.labelSigningLocation.Size = new System.Drawing.Size(85, 13);
            this.labelSigningLocation.TabIndex = 29;
            this.labelSigningLocation.Text = "Signing location:";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.labelTimestampingServer);
            this.groupBoxOptions.Controls.Add(this.comboBoxTimestampingServer);
            this.groupBoxOptions.Controls.Add(this.checkBoxTimestampDocument);
            this.groupBoxOptions.Location = new System.Drawing.Point(12, 386);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(423, 51);
            this.groupBoxOptions.TabIndex = 4;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Time stamping options";
            // 
            // labelTimestampingServer
            // 
            this.labelTimestampingServer.AutoSize = true;
            this.labelTimestampingServer.Location = new System.Drawing.Point(152, 23);
            this.labelTimestampingServer.Name = "labelTimestampingServer";
            this.labelTimestampingServer.Size = new System.Drawing.Size(65, 13);
            this.labelTimestampingServer.TabIndex = 1;
            this.labelTimestampingServer.Text = "Time server:";
            // 
            // comboBoxTimestampingServer
            // 
            this.comboBoxTimestampingServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTimestampingServer.Enabled = false;
            this.comboBoxTimestampingServer.FormattingEnabled = true;
            this.comboBoxTimestampingServer.Items.AddRange(new object[] {
            "http://ca.signfiles.com/TSAServer.aspx"});
            this.comboBoxTimestampingServer.Location = new System.Drawing.Point(223, 19);
            this.comboBoxTimestampingServer.Name = "comboBoxTimestampingServer";
            this.comboBoxTimestampingServer.Size = new System.Drawing.Size(194, 21);
            this.comboBoxTimestampingServer.TabIndex = 2;
            // 
            // checkBoxTimestampDocument
            // 
            this.checkBoxTimestampDocument.AutoSize = true;
            this.checkBoxTimestampDocument.Location = new System.Drawing.Point(13, 22);
            this.checkBoxTimestampDocument.Name = "checkBoxTimestampDocument";
            this.checkBoxTimestampDocument.Size = new System.Drawing.Size(130, 17);
            this.checkBoxTimestampDocument.TabIndex = 0;
            this.checkBoxTimestampDocument.Text = "Time stamp document";
            this.checkBoxTimestampDocument.UseVisualStyleBackColor = true;
            this.checkBoxTimestampDocument.CheckedChanged += new System.EventHandler(this.checkBoxTSA_CheckedChanged);
            // 
            // reasonText
            // 
            this.reasonText.FormattingEnabled = true;
            this.reasonText.Items.AddRange(new object[] {
            "I am the author of this document",
            "I have reviewed this document",
            "I am approving this document",
            "I agree to specified portions of this document"});
            this.reasonText.Location = new System.Drawing.Point(9, 39);
            this.reasonText.Name = "reasonText";
            this.reasonText.Size = new System.Drawing.Size(223, 21);
            this.reasonText.TabIndex = 0;
            // 
            // groupBoxPath
            // 
            this.groupBoxPath.Controls.Add(this.buttonSelectDestination);
            this.groupBoxPath.Controls.Add(this.labelDestination);
            this.groupBoxPath.Controls.Add(this.outputBox);
            this.groupBoxPath.Controls.Add(this.labelSource);
            this.groupBoxPath.Controls.Add(this.buttonSelectSource);
            this.groupBoxPath.Controls.Add(this.inputBox);
            this.groupBoxPath.Location = new System.Drawing.Point(12, 8);
            this.groupBoxPath.Name = "groupBoxPath";
            this.groupBoxPath.Size = new System.Drawing.Size(423, 108);
            this.groupBoxPath.TabIndex = 0;
            this.groupBoxPath.TabStop = false;
            this.groupBoxPath.Text = "Path";
            // 
            // buttonSign
            // 
            this.buttonSign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSign.Location = new System.Drawing.Point(21, 443);
            this.buttonSign.Name = "buttonSign";
            this.buttonSign.Size = new System.Drawing.Size(134, 23);
            this.buttonSign.TabIndex = 5;
            this.buttonSign.Text = "Apply Digital Signature";
            this.buttonSign.UseVisualStyleBackColor = true;
            this.buttonSign.Click += new System.EventHandler(this.buttonSign_Click);
            // 
            // groupBoxSignaturePosition
            // 
            this.groupBoxSignaturePosition.Controls.Add(this.textBoxAdvancedHeight);
            this.groupBoxSignaturePosition.Controls.Add(this.textBoxAdvancedWidth);
            this.groupBoxSignaturePosition.Controls.Add(this.textBoxAdvancedYCoord);
            this.groupBoxSignaturePosition.Controls.Add(this.labelAdvancedHeight);
            this.groupBoxSignaturePosition.Controls.Add(this.textBoxAdvancedXCoord);
            this.groupBoxSignaturePosition.Controls.Add(this.labelAdvancedWidth);
            this.groupBoxSignaturePosition.Controls.Add(this.labelAdvancedTopRight);
            this.groupBoxSignaturePosition.Controls.Add(this.labelAdvancedTopLeft);
            this.groupBoxSignaturePosition.Controls.Add(this.radioButtonAdvancedSignature);
            this.groupBoxSignaturePosition.Controls.Add(this.comboBoxBasicSignaturePage);
            this.groupBoxSignaturePosition.Controls.Add(this.radioButtonBasicSignature);
            this.groupBoxSignaturePosition.Controls.Add(this.comboBoxBasicSignaturePosition);
            this.groupBoxSignaturePosition.Controls.Add(this.labelBasicPage);
            this.groupBoxSignaturePosition.Location = new System.Drawing.Point(262, 122);
            this.groupBoxSignaturePosition.Name = "groupBoxSignaturePosition";
            this.groupBoxSignaturePosition.Size = new System.Drawing.Size(173, 177);
            this.groupBoxSignaturePosition.TabIndex = 3;
            this.groupBoxSignaturePosition.TabStop = false;
            this.groupBoxSignaturePosition.Text = "Signature position";
            // 
            // textBoxAdvancedHeight
            // 
            this.textBoxAdvancedHeight.Enabled = false;
            this.textBoxAdvancedHeight.Location = new System.Drawing.Point(134, 146);
            this.textBoxAdvancedHeight.MaxLength = 4;
            this.textBoxAdvancedHeight.Name = "textBoxAdvancedHeight";
            this.textBoxAdvancedHeight.Size = new System.Drawing.Size(32, 20);
            this.textBoxAdvancedHeight.TabIndex = 7;
            // 
            // textBoxAdvancedWidth
            // 
            this.textBoxAdvancedWidth.Enabled = false;
            this.textBoxAdvancedWidth.Location = new System.Drawing.Point(134, 118);
            this.textBoxAdvancedWidth.MaxLength = 4;
            this.textBoxAdvancedWidth.Name = "textBoxAdvancedWidth";
            this.textBoxAdvancedWidth.Size = new System.Drawing.Size(32, 20);
            this.textBoxAdvancedWidth.TabIndex = 6;
            // 
            // textBoxAdvancedYCoord
            // 
            this.textBoxAdvancedYCoord.Enabled = false;
            this.textBoxAdvancedYCoord.Location = new System.Drawing.Point(45, 146);
            this.textBoxAdvancedYCoord.MaxLength = 4;
            this.textBoxAdvancedYCoord.Name = "textBoxAdvancedYCoord";
            this.textBoxAdvancedYCoord.Size = new System.Drawing.Size(32, 20);
            this.textBoxAdvancedYCoord.TabIndex = 5;
            // 
            // labelAdvancedHeight
            // 
            this.labelAdvancedHeight.AutoSize = true;
            this.labelAdvancedHeight.Enabled = false;
            this.labelAdvancedHeight.Location = new System.Drawing.Point(87, 149);
            this.labelAdvancedHeight.Name = "labelAdvancedHeight";
            this.labelAdvancedHeight.Size = new System.Drawing.Size(41, 13);
            this.labelAdvancedHeight.TabIndex = 11;
            this.labelAdvancedHeight.Text = "Height:";
            // 
            // textBoxAdvancedXCoord
            // 
            this.textBoxAdvancedXCoord.Enabled = false;
            this.textBoxAdvancedXCoord.Location = new System.Drawing.Point(45, 118);
            this.textBoxAdvancedXCoord.MaxLength = 4;
            this.textBoxAdvancedXCoord.Name = "textBoxAdvancedXCoord";
            this.textBoxAdvancedXCoord.Size = new System.Drawing.Size(32, 20);
            this.textBoxAdvancedXCoord.TabIndex = 4;
            // 
            // labelAdvancedWidth
            // 
            this.labelAdvancedWidth.AutoSize = true;
            this.labelAdvancedWidth.Enabled = false;
            this.labelAdvancedWidth.Location = new System.Drawing.Point(90, 121);
            this.labelAdvancedWidth.Name = "labelAdvancedWidth";
            this.labelAdvancedWidth.Size = new System.Drawing.Size(38, 13);
            this.labelAdvancedWidth.TabIndex = 9;
            this.labelAdvancedWidth.Text = "Width:";
            // 
            // labelAdvancedTopRight
            // 
            this.labelAdvancedTopRight.AutoSize = true;
            this.labelAdvancedTopRight.Enabled = false;
            this.labelAdvancedTopRight.Location = new System.Drawing.Point(6, 149);
            this.labelAdvancedTopRight.Name = "labelAdvancedTopRight";
            this.labelAdvancedTopRight.Size = new System.Drawing.Size(38, 13);
            this.labelAdvancedTopRight.TabIndex = 7;
            this.labelAdvancedTopRight.Text = "Y-axis:";
            // 
            // labelAdvancedTopLeft
            // 
            this.labelAdvancedTopLeft.AutoSize = true;
            this.labelAdvancedTopLeft.Enabled = false;
            this.labelAdvancedTopLeft.Location = new System.Drawing.Point(6, 121);
            this.labelAdvancedTopLeft.Name = "labelAdvancedTopLeft";
            this.labelAdvancedTopLeft.Size = new System.Drawing.Size(38, 13);
            this.labelAdvancedTopLeft.TabIndex = 5;
            this.labelAdvancedTopLeft.Text = "X-axis:";
            // 
            // radioButtonAdvancedSignature
            // 
            this.radioButtonAdvancedSignature.AutoSize = true;
            this.radioButtonAdvancedSignature.Location = new System.Drawing.Point(6, 90);
            this.radioButtonAdvancedSignature.Name = "radioButtonAdvancedSignature";
            this.radioButtonAdvancedSignature.Size = new System.Drawing.Size(74, 17);
            this.radioButtonAdvancedSignature.TabIndex = 2;
            this.radioButtonAdvancedSignature.TabStop = true;
            this.radioButtonAdvancedSignature.Text = "Advanced";
            this.radioButtonAdvancedSignature.UseVisualStyleBackColor = true;
            this.radioButtonAdvancedSignature.CheckedChanged += new System.EventHandler(this.radioButtonAdvancedSignature_CheckedChanged);
            // 
            // radioButtonBasicSignature
            // 
            this.radioButtonBasicSignature.AutoSize = true;
            this.radioButtonBasicSignature.Checked = true;
            this.radioButtonBasicSignature.Location = new System.Drawing.Point(6, 54);
            this.radioButtonBasicSignature.Name = "radioButtonBasicSignature";
            this.radioButtonBasicSignature.Size = new System.Drawing.Size(51, 17);
            this.radioButtonBasicSignature.TabIndex = 1;
            this.radioButtonBasicSignature.TabStop = true;
            this.radioButtonBasicSignature.Text = "Basic";
            this.radioButtonBasicSignature.UseVisualStyleBackColor = true;
            this.radioButtonBasicSignature.CheckedChanged += new System.EventHandler(this.radioButtonBasicSignature_CheckedChanged);
            // 
            // labelBasicPage
            // 
            this.labelBasicPage.AutoSize = true;
            this.labelBasicPage.Location = new System.Drawing.Point(20, 25);
            this.labelBasicPage.Name = "labelBasicPage";
            this.labelBasicPage.Size = new System.Drawing.Size(35, 13);
            this.labelBasicPage.TabIndex = 0;
            this.labelBasicPage.Text = "Page:";
            // 
            // groupBoxSignatureOptions
            // 
            this.groupBoxSignatureOptions.Controls.Add(this.checkBoxIncludeImage);
            this.groupBoxSignatureOptions.Controls.Add(this.checkBoxShowSignature);
            this.groupBoxSignatureOptions.Controls.Add(this.labelSigningReason);
            this.groupBoxSignatureOptions.Controls.Add(this.reasonText);
            this.groupBoxSignatureOptions.Controls.Add(this.labelSigningLocation);
            this.groupBoxSignatureOptions.Controls.Add(this.locationText);
            this.groupBoxSignatureOptions.Location = new System.Drawing.Point(12, 122);
            this.groupBoxSignatureOptions.Name = "groupBoxSignatureOptions";
            this.groupBoxSignatureOptions.Size = new System.Drawing.Size(244, 177);
            this.groupBoxSignatureOptions.TabIndex = 1;
            this.groupBoxSignatureOptions.TabStop = false;
            this.groupBoxSignatureOptions.Text = "Signature options";
            // 
            // checkBoxIncludeImage
            // 
            this.checkBoxIncludeImage.AutoSize = true;
            this.checkBoxIncludeImage.Location = new System.Drawing.Point(9, 146);
            this.checkBoxIncludeImage.Name = "checkBoxIncludeImage";
            this.checkBoxIncludeImage.Size = new System.Drawing.Size(186, 17);
            this.checkBoxIncludeImage.TabIndex = 0;
            this.checkBoxIncludeImage.Text = "Include an image on the signature";
            this.checkBoxIncludeImage.UseVisualStyleBackColor = true;
            this.checkBoxIncludeImage.CheckedChanged += new System.EventHandler(this.checkBoxIncludeImage_CheckedChanged);
            // 
            // groupBoxSignatureImage
            // 
            this.groupBoxSignatureImage.Controls.Add(this.radioButtonImageNoText);
            this.groupBoxSignatureImage.Controls.Add(this.radioButtonImageAndText);
            this.groupBoxSignatureImage.Controls.Add(this.radioButtonImageAsBackgorund);
            this.groupBoxSignatureImage.Controls.Add(this.textBoxImageFile);
            this.groupBoxSignatureImage.Controls.Add(this.buttonSelectImage);
            this.groupBoxSignatureImage.Enabled = false;
            this.groupBoxSignatureImage.Location = new System.Drawing.Point(12, 305);
            this.groupBoxSignatureImage.Name = "groupBoxSignatureImage";
            this.groupBoxSignatureImage.Size = new System.Drawing.Size(423, 75);
            this.groupBoxSignatureImage.TabIndex = 10;
            this.groupBoxSignatureImage.TabStop = false;
            this.groupBoxSignatureImage.Text = "Signature image";
            // 
            // radioButtonImageNoText
            // 
            this.radioButtonImageNoText.AutoSize = true;
            this.radioButtonImageNoText.Location = new System.Drawing.Point(298, 49);
            this.radioButtonImageNoText.Name = "radioButtonImageNoText";
            this.radioButtonImageNoText.Size = new System.Drawing.Size(111, 17);
            this.radioButtonImageNoText.TabIndex = 4;
            this.radioButtonImageNoText.Text = "Image with no text";
            this.radioButtonImageNoText.UseVisualStyleBackColor = true;
            // 
            // radioButtonImageAndText
            // 
            this.radioButtonImageAndText.AutoSize = true;
            this.radioButtonImageAndText.Checked = true;
            this.radioButtonImageAndText.Location = new System.Drawing.Point(9, 49);
            this.radioButtonImageAndText.Name = "radioButtonImageAndText";
            this.radioButtonImageAndText.Size = new System.Drawing.Size(95, 17);
            this.radioButtonImageAndText.TabIndex = 4;
            this.radioButtonImageAndText.TabStop = true;
            this.radioButtonImageAndText.Text = "Image and text";
            this.radioButtonImageAndText.UseVisualStyleBackColor = true;
            // 
            // radioButtonImageAsBackgorund
            // 
            this.radioButtonImageAsBackgorund.AutoSize = true;
            this.radioButtonImageAsBackgorund.Location = new System.Drawing.Point(136, 49);
            this.radioButtonImageAsBackgorund.Name = "radioButtonImageAsBackgorund";
            this.radioButtonImageAsBackgorund.Size = new System.Drawing.Size(128, 17);
            this.radioButtonImageAsBackgorund.TabIndex = 4;
            this.radioButtonImageAsBackgorund.Text = "Image as background";
            this.radioButtonImageAsBackgorund.UseVisualStyleBackColor = true;
            // 
            // textBoxImageFile
            // 
            this.textBoxImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxImageFile.Location = new System.Drawing.Point(44, 21);
            this.textBoxImageFile.Name = "textBoxImageFile";
            this.textBoxImageFile.Size = new System.Drawing.Size(367, 20);
            this.textBoxImageFile.TabIndex = 3;
            // 
            // buttonSelectImage
            // 
            this.buttonSelectImage.Location = new System.Drawing.Point(6, 21);
            this.buttonSelectImage.Name = "buttonSelectImage";
            this.buttonSelectImage.Size = new System.Drawing.Size(32, 20);
            this.buttonSelectImage.TabIndex = 2;
            this.buttonSelectImage.Text = "...";
            this.buttonSelectImage.UseVisualStyleBackColor = true;
            this.buttonSelectImage.Click += new System.EventHandler(this.buttonSelectImage_Click);
            // 
            // FormPDFSigner
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonQuit;
            this.ClientSize = new System.Drawing.Size(446, 481);
            this.Controls.Add(this.groupBoxSignatureImage);
            this.Controls.Add(this.groupBoxSignatureOptions);
            this.Controls.Add(this.groupBoxSignaturePosition);
            this.Controls.Add(this.groupBoxPath);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.buttonSign);
            this.Controls.Add(this.buttonQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPDFSigner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDF Signer";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormPDFSigner_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormPDFSigner_DragEnter);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPDFSigner_FormClosing);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxPath.ResumeLayout(false);
            this.groupBoxPath.PerformLayout();
            this.groupBoxSignaturePosition.ResumeLayout(false);
            this.groupBoxSignaturePosition.PerformLayout();
            this.groupBoxSignatureOptions.ResumeLayout(false);
            this.groupBoxSignatureOptions.PerformLayout();
            this.groupBoxSignatureImage.ResumeLayout(false);
            this.groupBoxSignatureImage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button buttonSelectSource;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button buttonSelectDestination;
        private System.Windows.Forms.Label labelSigningReason;
        //private System.Windows.Forms.TextBox reasonText;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Button buttonSign;
        private System.Windows.Forms.Label labelSource;
        private System.Windows.Forms.Label labelDestination;
        private System.Windows.Forms.ComboBox comboBoxBasicSignaturePosition;
        private System.Windows.Forms.ComboBox comboBoxBasicSignaturePage;
        private System.Windows.Forms.CheckBox checkBoxShowSignature;
        private System.Windows.Forms.Label labelSigningLocation;
        private System.Windows.Forms.TextBox locationText;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.GroupBox groupBoxPath;
        private System.Windows.Forms.ComboBox comboBoxTimestampingServer;
        private System.Windows.Forms.CheckBox checkBoxTimestampDocument;
        private System.Windows.Forms.ComboBox reasonText;
        private System.Windows.Forms.Label labelTimestampingServer;
        private System.Windows.Forms.GroupBox groupBoxSignaturePosition;
        private System.Windows.Forms.Label labelBasicPage;
        private System.Windows.Forms.GroupBox groupBoxSignatureOptions;
        private System.Windows.Forms.GroupBox groupBoxSignatureImage;
        private System.Windows.Forms.RadioButton radioButtonImageAndText;
        private System.Windows.Forms.TextBox textBoxImageFile;
        private System.Windows.Forms.Button buttonSelectImage;
        private System.Windows.Forms.RadioButton radioButtonImageNoText;
        private System.Windows.Forms.CheckBox checkBoxIncludeImage;
        private System.Windows.Forms.RadioButton radioButtonImageAsBackgorund;
        private System.Windows.Forms.TextBox textBoxAdvancedHeight;
        private System.Windows.Forms.TextBox textBoxAdvancedWidth;
        private System.Windows.Forms.TextBox textBoxAdvancedYCoord;
        private System.Windows.Forms.Label labelAdvancedHeight;
        private System.Windows.Forms.TextBox textBoxAdvancedXCoord;
        private System.Windows.Forms.Label labelAdvancedWidth;
        private System.Windows.Forms.Label labelAdvancedTopRight;
        private System.Windows.Forms.Label labelAdvancedTopLeft;
        private System.Windows.Forms.RadioButton radioButtonAdvancedSignature;
        private System.Windows.Forms.RadioButton radioButtonBasicSignature;
    }
}

