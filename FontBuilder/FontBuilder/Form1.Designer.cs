namespace FontBuilder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.selectTTFButton = new System.Windows.Forms.Button();
            this.buildButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.outputPanel = new System.Windows.Forms.Panel();
            this.atlasPicBox = new System.Windows.Forms.PictureBox();
            this.saveGlyphsButton = new System.Windows.Forms.Button();
            this.glyphsTextBox = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.saveTextureButton = new System.Windows.Forms.Button();
            this.saveTextureDialog = new System.Windows.Forms.SaveFileDialog();
            this.openTTFDialog = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.TextBox();
            this.saveGlyphsDialog = new System.Windows.Forms.SaveFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.chkLatinBasic = new System.Windows.Forms.CheckBox();
            this.chkChineseCommon = new System.Windows.Forms.CheckBox();
            this.chkJapaneseCommon = new System.Windows.Forms.CheckBox();
            this.chkChineseFull = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomRange = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkJapaneseFull = new System.Windows.Forms.CheckBox();
            this.chkLatinExtended = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.outputPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atlasPicBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TTF File";
            // 
            // selectTTFButton
            // 
            this.selectTTFButton.Location = new System.Drawing.Point(90, 36);
            this.selectTTFButton.Name = "selectTTFButton";
            this.selectTTFButton.Size = new System.Drawing.Size(75, 23);
            this.selectTTFButton.TabIndex = 1;
            this.selectTTFButton.Text = "Select";
            this.selectTTFButton.UseVisualStyleBackColor = true;
            this.selectTTFButton.Click += new System.EventHandler(this.selectTTFButton_Click);
            // 
            // buildButton
            // 
            this.buildButton.Enabled = false;
            this.buildButton.Location = new System.Drawing.Point(24, 139);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(322, 34);
            this.buildButton.TabIndex = 2;
            this.buildButton.Text = "3.Build";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "File:";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(3, 9);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(59, 12);
            this.fileNameLabel.TabIndex = 4;
            this.fileNameLabel.Text = "No Select";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Output";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "1.Texture";
            // 
            // outputPanel
            // 
            this.outputPanel.Controls.Add(this.atlasPicBox);
            this.outputPanel.Controls.Add(this.saveGlyphsButton);
            this.outputPanel.Controls.Add(this.glyphsTextBox);
            this.outputPanel.Controls.Add(this.label6);
            this.outputPanel.Controls.Add(this.saveTextureButton);
            this.outputPanel.Controls.Add(this.label4);
            this.outputPanel.Controls.Add(this.label5);
            this.outputPanel.Enabled = false;
            this.outputPanel.Location = new System.Drawing.Point(24, 179);
            this.outputPanel.Name = "outputPanel";
            this.outputPanel.Size = new System.Drawing.Size(320, 215);
            this.outputPanel.TabIndex = 7;
            // 
            // atlasPicBox
            // 
            this.atlasPicBox.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.atlasPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.atlasPicBox.Location = new System.Drawing.Point(19, 51);
            this.atlasPicBox.Name = "atlasPicBox";
            this.atlasPicBox.Size = new System.Drawing.Size(120, 118);
            this.atlasPicBox.TabIndex = 11;
            this.atlasPicBox.TabStop = false;
            // 
            // saveGlyphsButton
            // 
            this.saveGlyphsButton.Location = new System.Drawing.Point(179, 174);
            this.saveGlyphsButton.Name = "saveGlyphsButton";
            this.saveGlyphsButton.Size = new System.Drawing.Size(120, 24);
            this.saveGlyphsButton.TabIndex = 10;
            this.saveGlyphsButton.Text = "Save";
            this.saveGlyphsButton.UseVisualStyleBackColor = true;
            this.saveGlyphsButton.Click += new System.EventHandler(this.saveGlyphsButton_Click);
            // 
            // glyphsTextBox
            // 
            this.glyphsTextBox.Location = new System.Drawing.Point(179, 50);
            this.glyphsTextBox.Name = "glyphsTextBox";
            this.glyphsTextBox.Size = new System.Drawing.Size(120, 118);
            this.glyphsTextBox.TabIndex = 9;
            this.glyphsTextBox.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "2.Glyphs";
            // 
            // saveTextureButton
            // 
            this.saveTextureButton.Location = new System.Drawing.Point(19, 175);
            this.saveTextureButton.Name = "saveTextureButton";
            this.saveTextureButton.Size = new System.Drawing.Size(120, 24);
            this.saveTextureButton.TabIndex = 7;
            this.saveTextureButton.Text = "Save";
            this.saveTextureButton.UseVisualStyleBackColor = true;
            this.saveTextureButton.Click += new System.EventHandler(this.saveTextureButton_Click);
            // 
            // saveTextureDialog
            // 
            this.saveTextureDialog.Filter = "PNG|*.png";
            // 
            // openTTFDialog
            // 
            this.openTTFDialog.Filter = "Font File|*.ttf";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Size:";
            // 
            // SizeBox
            // 
            this.SizeBox.Location = new System.Drawing.Point(63, 100);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(100, 21);
            this.SizeBox.TabIndex = 9;
            this.SizeBox.Text = "20";
            // 
            // saveGlyphsDialog
            // 
            this.saveGlyphsDialog.Filter = "Glyphs Data|*.glyphs";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "2. Select Range";
            // 
            // chkLatinBasic
            // 
            this.chkLatinBasic.AutoSize = true;
            this.chkLatinBasic.Checked = true;
            this.chkLatinBasic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLatinBasic.Location = new System.Drawing.Point(3, 12);
            this.chkLatinBasic.Name = "chkLatinBasic";
            this.chkLatinBasic.Size = new System.Drawing.Size(90, 16);
            this.chkLatinBasic.TabIndex = 11;
            this.chkLatinBasic.Text = "Latin Basic";
            this.chkLatinBasic.UseVisualStyleBackColor = true;
            // 
            // chkChineseCommon
            // 
            this.chkChineseCommon.AutoSize = true;
            this.chkChineseCommon.Location = new System.Drawing.Point(3, 42);
            this.chkChineseCommon.Name = "chkChineseCommon";
            this.chkChineseCommon.Size = new System.Drawing.Size(66, 16);
            this.chkChineseCommon.TabIndex = 12;
            this.chkChineseCommon.Text = "Chinese";
            this.chkChineseCommon.UseVisualStyleBackColor = true;
            // 
            // chkJapaneseCommon
            // 
            this.chkJapaneseCommon.AutoSize = true;
            this.chkJapaneseCommon.Location = new System.Drawing.Point(3, 64);
            this.chkJapaneseCommon.Name = "chkJapaneseCommon";
            this.chkJapaneseCommon.Size = new System.Drawing.Size(72, 16);
            this.chkJapaneseCommon.TabIndex = 13;
            this.chkJapaneseCommon.Text = "Japanese";
            this.chkJapaneseCommon.UseVisualStyleBackColor = true;
            // 
            // chkChineseFull
            // 
            this.chkChineseFull.AutoSize = true;
            this.chkChineseFull.Location = new System.Drawing.Point(75, 43);
            this.chkChineseFull.Name = "chkChineseFull";
            this.chkChineseFull.Size = new System.Drawing.Size(48, 16);
            this.chkChineseFull.TabIndex = 15;
            this.chkChineseFull.Text = "Full";
            this.chkChineseFull.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(362, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "++ Custom String";
            // 
            // txtCustomRange
            // 
            this.txtCustomRange.Location = new System.Drawing.Point(364, 246);
            this.txtCustomRange.Name = "txtCustomRange";
            this.txtCustomRange.Size = new System.Drawing.Size(200, 132);
            this.txtCustomRange.TabIndex = 17;
            this.txtCustomRange.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "1. Select Font";
            // 
            // chkJapaneseFull
            // 
            this.chkJapaneseFull.AutoSize = true;
            this.chkJapaneseFull.Location = new System.Drawing.Point(75, 64);
            this.chkJapaneseFull.Name = "chkJapaneseFull";
            this.chkJapaneseFull.Size = new System.Drawing.Size(48, 16);
            this.chkJapaneseFull.TabIndex = 19;
            this.chkJapaneseFull.Text = "Full";
            this.chkJapaneseFull.UseVisualStyleBackColor = true;
            // 
            // chkLatinExtended
            // 
            this.chkLatinExtended.AutoSize = true;
            this.chkLatinExtended.Location = new System.Drawing.Point(99, 12);
            this.chkLatinExtended.Name = "chkLatinExtended";
            this.chkLatinExtended.Size = new System.Drawing.Size(72, 16);
            this.chkLatinExtended.TabIndex = 20;
            this.chkLatinExtended.Text = "Extended";
            this.chkLatinExtended.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileNameLabel);
            this.panel1.Location = new System.Drawing.Point(65, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 29);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkLatinBasic);
            this.panel2.Controls.Add(this.chkChineseCommon);
            this.panel2.Controls.Add(this.chkLatinExtended);
            this.panel2.Controls.Add(this.chkJapaneseCommon);
            this.panel2.Controls.Add(this.chkJapaneseFull);
            this.panel2.Controls.Add(this.chkChineseFull);
            this.panel2.Location = new System.Drawing.Point(364, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(367, 65);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(209, 24);
            this.label10.TabIndex = 23;
            this.label10.Text = "WARNING: Larger font ranges will \r\nresult in more memory consumption!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 409);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCustomRange);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.SizeBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.outputPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.selectTTFButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Font Builder For SpriteFont";
            this.outputPanel.ResumeLayout(false);
            this.outputPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.atlasPicBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button selectTTFButton;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel outputPanel;
        private System.Windows.Forms.Button saveGlyphsButton;
        private System.Windows.Forms.RichTextBox glyphsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveTextureButton;
        private System.Windows.Forms.PictureBox atlasPicBox;
        private System.Windows.Forms.SaveFileDialog saveTextureDialog;
        private System.Windows.Forms.OpenFileDialog openTTFDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SizeBox;
        private System.Windows.Forms.SaveFileDialog saveGlyphsDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkLatinBasic;
        private System.Windows.Forms.CheckBox chkChineseCommon;
        private System.Windows.Forms.CheckBox chkJapaneseCommon;
        private System.Windows.Forms.CheckBox chkChineseFull;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox txtCustomRange;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkJapaneseFull;
        private System.Windows.Forms.CheckBox chkLatinExtended;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
    }
}

