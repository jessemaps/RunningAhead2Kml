namespace RunningAhead2Kml
{
    partial class RA2KmlForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.outputMessages = new System.Windows.Forms.Label();
            this.convertButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.selectFilePanel = new System.Windows.Forms.Panel();
            this.selectFileNext = new System.Windows.Forms.Button();
            this.openFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.selectDataFile = new System.Windows.Forms.Button();
            this.previous = new System.Windows.Forms.Button();
            this.chooseColorsPanel = new System.Windows.Forms.Panel();
            this.saveKmlAsButton = new System.Windows.Forms.Button();
            this.saveKmlLocation = new System.Windows.Forms.TextBox();
            this.exportThisGroup = new System.Windows.Forms.CheckBox();
            this.lineWidth = new System.Windows.Forms.NumericUpDown();
            this.combosPanel = new System.Windows.Forms.Panel();
            this.opacityLabelLow = new System.Windows.Forms.Label();
            this.opacityLabelHigh = new System.Windows.Forms.Label();
            this.opacityValue = new System.Windows.Forms.TextBox();
            this.opacitySlider = new System.Windows.Forms.TrackBar();
            this.colorPreview = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveKmlFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            this.selectFilePanel.SuspendLayout();
            this.chooseColorsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.label2.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(164, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "RunningAhead 2 KML";
            // 
            // logoPicture
            // 
            this.logoPicture.Image = global::RunningAhead2Kml.Properties.Resources.runningahead_2_kml_1;
            this.logoPicture.Location = new System.Drawing.Point(124, 29);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(386, 120);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.logoPicture.TabIndex = 9;
            this.logoPicture.TabStop = false;
            // 
            // outputMessages
            // 
            this.outputMessages.AutoSize = true;
            this.outputMessages.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputMessages.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.outputMessages.Location = new System.Drawing.Point(43, 473);
            this.outputMessages.MaximumSize = new System.Drawing.Size(400, 30);
            this.outputMessages.Name = "outputMessages";
            this.outputMessages.Size = new System.Drawing.Size(0, 15);
            this.outputMessages.TabIndex = 7;
            // 
            // convertButton
            // 
            this.convertButton.Enabled = false;
            this.convertButton.Location = new System.Drawing.Point(475, 331);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(75, 23);
            this.convertButton.TabIndex = 10;
            this.convertButton.Text = "Convert File";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "XML files|*.xml";
            // 
            // selectFilePanel
            // 
            this.selectFilePanel.Controls.Add(this.selectFileNext);
            this.selectFilePanel.Controls.Add(this.openFileName);
            this.selectFilePanel.Controls.Add(this.label1);
            this.selectFilePanel.Controls.Add(this.selectDataFile);
            this.selectFilePanel.Location = new System.Drawing.Point(24, 131);
            this.selectFilePanel.Name = "selectFilePanel";
            this.selectFilePanel.Size = new System.Drawing.Size(580, 357);
            this.selectFilePanel.TabIndex = 15;
            // 
            // selectFileNext
            // 
            this.selectFileNext.Enabled = false;
            this.selectFileNext.Location = new System.Drawing.Point(461, 244);
            this.selectFileNext.Name = "selectFileNext";
            this.selectFileNext.Size = new System.Drawing.Size(75, 23);
            this.selectFileNext.TabIndex = 12;
            this.selectFileNext.Text = "Next";
            this.selectFileNext.UseVisualStyleBackColor = true;
            this.selectFileNext.Click += new System.EventHandler(this.selectFileNext_Click);
            // 
            // openFileName
            // 
            this.openFileName.AllowDrop = true;
            this.openFileName.Location = new System.Drawing.Point(22, 45);
            this.openFileName.Name = "openFileName";
            this.openFileName.Size = new System.Drawing.Size(411, 20);
            this.openFileName.TabIndex = 11;
            this.openFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(19, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Select RunningAhead.com log archive XML file";
            // 
            // selectDataFile
            // 
            this.selectDataFile.Location = new System.Drawing.Point(439, 43);
            this.selectDataFile.Name = "selectDataFile";
            this.selectDataFile.Size = new System.Drawing.Size(97, 23);
            this.selectDataFile.TabIndex = 9;
            this.selectDataFile.Text = "Select data file";
            this.selectDataFile.UseVisualStyleBackColor = true;
            this.selectDataFile.Click += new System.EventHandler(this.selectDataFile_Click);
            // 
            // previous
            // 
            this.previous.Location = new System.Drawing.Point(22, 331);
            this.previous.Name = "previous";
            this.previous.Size = new System.Drawing.Size(75, 23);
            this.previous.TabIndex = 0;
            this.previous.Text = "Previous";
            this.previous.UseVisualStyleBackColor = true;
            this.previous.Click += new System.EventHandler(this.previous_Click);
            // 
            // chooseColorsPanel
            // 
            this.chooseColorsPanel.Controls.Add(this.saveKmlAsButton);
            this.chooseColorsPanel.Controls.Add(this.saveKmlLocation);
            this.chooseColorsPanel.Controls.Add(this.exportThisGroup);
            this.chooseColorsPanel.Controls.Add(this.lineWidth);
            this.chooseColorsPanel.Controls.Add(this.combosPanel);
            this.chooseColorsPanel.Controls.Add(this.opacityLabelLow);
            this.chooseColorsPanel.Controls.Add(this.previous);
            this.chooseColorsPanel.Controls.Add(this.convertButton);
            this.chooseColorsPanel.Controls.Add(this.opacityLabelHigh);
            this.chooseColorsPanel.Controls.Add(this.opacityValue);
            this.chooseColorsPanel.Controls.Add(this.opacitySlider);
            this.chooseColorsPanel.Controls.Add(this.colorPreview);
            this.chooseColorsPanel.Controls.Add(this.label5);
            this.chooseColorsPanel.Controls.Add(this.label3);
            this.chooseColorsPanel.Controls.Add(this.label4);
            this.chooseColorsPanel.Location = new System.Drawing.Point(24, 131);
            this.chooseColorsPanel.Name = "chooseColorsPanel";
            this.chooseColorsPanel.Size = new System.Drawing.Size(580, 357);
            this.chooseColorsPanel.TabIndex = 17;
            // 
            // saveKmlAsButton
            // 
            this.saveKmlAsButton.Location = new System.Drawing.Point(426, 273);
            this.saveKmlAsButton.Name = "saveKmlAsButton";
            this.saveKmlAsButton.Size = new System.Drawing.Size(75, 23);
            this.saveKmlAsButton.TabIndex = 31;
            this.saveKmlAsButton.Text = "Save As";
            this.saveKmlAsButton.UseVisualStyleBackColor = true;
            this.saveKmlAsButton.Click += new System.EventHandler(this.saveKmlAsButton_Click);
            // 
            // saveKmlLocation
            // 
            this.saveKmlLocation.Location = new System.Drawing.Point(22, 275);
            this.saveKmlLocation.Name = "saveKmlLocation";
            this.saveKmlLocation.Size = new System.Drawing.Size(396, 20);
            this.saveKmlLocation.TabIndex = 30;
            this.saveKmlLocation.WordWrap = false;
            // 
            // exportThisGroup
            // 
            this.exportThisGroup.AutoSize = true;
            this.exportThisGroup.Checked = true;
            this.exportThisGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exportThisGroup.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportThisGroup.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.exportThisGroup.Location = new System.Drawing.Point(327, 28);
            this.exportThisGroup.Name = "exportThisGroup";
            this.exportThisGroup.Size = new System.Drawing.Size(198, 19);
            this.exportThisGroup.TabIndex = 29;
            this.exportThisGroup.Text = "Export this category to KML";
            this.exportThisGroup.UseVisualStyleBackColor = true;
            // 
            // lineWidth
            // 
            this.lineWidth.Location = new System.Drawing.Point(439, 200);
            this.lineWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.lineWidth.Name = "lineWidth";
            this.lineWidth.Size = new System.Drawing.Size(62, 20);
            this.lineWidth.TabIndex = 28;
            this.lineWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // combosPanel
            // 
            this.combosPanel.AutoScroll = true;
            this.combosPanel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.combosPanel.Location = new System.Drawing.Point(22, 24);
            this.combosPanel.Name = "combosPanel";
            this.combosPanel.Size = new System.Drawing.Size(259, 214);
            this.combosPanel.TabIndex = 26;
            // 
            // opacityLabelLow
            // 
            this.opacityLabelLow.AutoSize = true;
            this.opacityLabelLow.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opacityLabelLow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.opacityLabelLow.Location = new System.Drawing.Point(522, 154);
            this.opacityLabelLow.Name = "opacityLabelLow";
            this.opacityLabelLow.Size = new System.Drawing.Size(28, 15);
            this.opacityLabelLow.TabIndex = 15;
            this.opacityLabelLow.Text = "100";
            // 
            // opacityLabelHigh
            // 
            this.opacityLabelHigh.AutoSize = true;
            this.opacityLabelHigh.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opacityLabelHigh.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.opacityLabelHigh.Location = new System.Drawing.Point(366, 154);
            this.opacityLabelHigh.Name = "opacityLabelHigh";
            this.opacityLabelHigh.Size = new System.Drawing.Size(14, 15);
            this.opacityLabelHigh.TabIndex = 16;
            this.opacityLabelHigh.Text = "0";
            // 
            // opacityValue
            // 
            this.opacityValue.Location = new System.Drawing.Point(436, 118);
            this.opacityValue.MaxLength = 3;
            this.opacityValue.Name = "opacityValue";
            this.opacityValue.Size = new System.Drawing.Size(32, 20);
            this.opacityValue.TabIndex = 21;
            // 
            // opacitySlider
            // 
            this.opacitySlider.Location = new System.Drawing.Point(378, 149);
            this.opacitySlider.Maximum = 100;
            this.opacitySlider.Name = "opacitySlider";
            this.opacitySlider.Size = new System.Drawing.Size(147, 45);
            this.opacitySlider.TabIndex = 20;
            this.opacitySlider.Value = 50;
            // 
            // colorPreview
            // 
            this.colorPreview.BackColor = System.Drawing.Color.Red;
            this.colorPreview.Location = new System.Drawing.Point(436, 67);
            this.colorPreview.Name = "colorPreview";
            this.colorPreview.Size = new System.Drawing.Size(32, 32);
            this.colorPreview.TabIndex = 19;
            this.colorPreview.TabStop = false;
            this.colorPreview.Click += new System.EventHandler(this.colorPreview_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(327, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Select line width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(324, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Select opacity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("HelveticaNeue LT 65 Medium", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(324, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 18;
            this.label4.Text = "Select line color";
            // 
            // saveKmlFileDialog
            // 
            this.saveKmlFileDialog.Filter = "KML files (*.kml)|*.kml";
            // 
            // RA2KmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(103)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(634, 512);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputMessages);
            this.Controls.Add(this.selectFilePanel);
            this.Controls.Add(this.chooseColorsPanel);
            this.Controls.Add(this.logoPicture);
            this.Name = "RA2KmlForm";
            this.Text = "RunningAhead2Kml";
            this.Load += new System.EventHandler(this.RA2KmlForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            this.selectFilePanel.ResumeLayout(false);
            this.selectFilePanel.PerformLayout();
            this.chooseColorsPanel.ResumeLayout(false);
            this.chooseColorsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opacitySlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.Label outputMessages;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Panel selectFilePanel;
        private System.Windows.Forms.Button previous;
        private System.Windows.Forms.TextBox openFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectDataFile;
        private System.Windows.Forms.Panel chooseColorsPanel;
        private System.Windows.Forms.Label opacityLabelLow;
        private System.Windows.Forms.Label opacityLabelHigh;
        private System.Windows.Forms.TextBox opacityValue;
        private System.Windows.Forms.TrackBar opacitySlider;
        private System.Windows.Forms.PictureBox colorPreview;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button selectFileNext;
        private System.Windows.Forms.Panel combosPanel;
        private System.Windows.Forms.CheckBox exportThisGroup;
        private System.Windows.Forms.NumericUpDown lineWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveKmlAsButton;
        private System.Windows.Forms.TextBox saveKmlLocation;
        private System.Windows.Forms.SaveFileDialog saveKmlFileDialog;
    }
}

