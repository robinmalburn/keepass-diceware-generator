/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGenerator.UI
{
    partial class Options
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NumericUpDown uxNumberOfWords;
        private System.Windows.Forms.Label uxNumberOfWordsLabel;
        private System.Windows.Forms.Button uxOkBtn;
        private System.Windows.Forms.Button uxCancelBtn;
        private System.Windows.Forms.Panel uxFieldsPanel;
        private System.Windows.Forms.Panel uxControlsPanel;
        private System.Windows.Forms.CheckBox uxStudlyCapsCheckBox;
        private System.Windows.Forms.Label uxWordListLabel;
        private System.Windows.Forms.ComboBox uxWordlistComboBox;
        private System.Windows.Forms.Label uxSeparatorLabel;
        private System.Windows.Forms.TextBox uxSeparatorText;
        private System.Windows.Forms.Label uxExamplePhraseLabel;
        private System.Windows.Forms.Label uxExampleLabel;
        private System.Windows.Forms.CheckBox uxSpecialCharsCheckBox;
        private System.Windows.Forms.Panel uxExamplePanel;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.uxNumberOfWords = new System.Windows.Forms.NumericUpDown();
            this.uxNumberOfWordsLabel = new System.Windows.Forms.Label();
            this.uxOkBtn = new System.Windows.Forms.Button();
            this.uxCancelBtn = new System.Windows.Forms.Button();
            this.uxControlsPanel = new System.Windows.Forms.Panel();
            this.uxFieldsPanel = new System.Windows.Forms.Panel();
            this.uxSpecialCharsCheckBox = new System.Windows.Forms.CheckBox();
            this.uxSeparatorLabel = new System.Windows.Forms.Label();
            this.uxSeparatorText = new System.Windows.Forms.TextBox();
            this.uxWordListLabel = new System.Windows.Forms.Label();
            this.uxWordlistComboBox = new System.Windows.Forms.ComboBox();
            this.uxStudlyCapsCheckBox = new System.Windows.Forms.CheckBox();
            this.uxExampleLabel = new System.Windows.Forms.Label();
            this.uxExamplePhraseLabel = new System.Windows.Forms.Label();
            this.uxExamplePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).BeginInit();
            this.uxControlsPanel.SuspendLayout();
            this.uxFieldsPanel.SuspendLayout();
            this.uxExamplePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxNumberOfWords
            // 
            this.uxNumberOfWords.Location = new System.Drawing.Point(272, 8);
            this.uxNumberOfWords.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.uxNumberOfWords.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.uxNumberOfWords.Name = "uxNumberOfWords";
            this.uxNumberOfWords.Size = new System.Drawing.Size(48, 20);
            this.uxNumberOfWords.TabIndex = 0;
            this.uxNumberOfWords.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.uxNumberOfWords.ValueChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // uxNumberOfWordsLabel
            // 
            this.uxNumberOfWordsLabel.Location = new System.Drawing.Point(24, 8);
            this.uxNumberOfWordsLabel.Name = "uxNumberOfWordsLabel";
            this.uxNumberOfWordsLabel.Size = new System.Drawing.Size(240, 24);
            this.uxNumberOfWordsLabel.TabIndex = 1;
            this.uxNumberOfWordsLabel.Text = "How many words should the phrase consist of?";
            // 
            // uxOkBtn
            // 
            this.uxOkBtn.Location = new System.Drawing.Point(168, 8);
            this.uxOkBtn.Name = "uxOkBtn";
            this.uxOkBtn.Size = new System.Drawing.Size(75, 23);
            this.uxOkBtn.TabIndex = 2;
            this.uxOkBtn.Text = "OK";
            this.uxOkBtn.UseVisualStyleBackColor = true;
            this.uxOkBtn.Click += new System.EventHandler(this.UxOKBtnClick);
            // 
            // uxCancelBtn
            // 
            this.uxCancelBtn.Location = new System.Drawing.Point(248, 8);
            this.uxCancelBtn.Name = "uxCancelBtn";
            this.uxCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.uxCancelBtn.TabIndex = 3;
            this.uxCancelBtn.Text = "Cancel";
            this.uxCancelBtn.UseVisualStyleBackColor = true;
            this.uxCancelBtn.Click += new System.EventHandler(this.UxCancelBtnClick);
            // 
            // uxControlsPanel
            // 
            this.uxControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxControlsPanel.Controls.Add(this.uxOkBtn);
            this.uxControlsPanel.Controls.Add(this.uxCancelBtn);
            this.uxControlsPanel.Location = new System.Drawing.Point(0, 247);
            this.uxControlsPanel.Name = "uxControlsPanel";
            this.uxControlsPanel.Size = new System.Drawing.Size(336, 42);
            this.uxControlsPanel.TabIndex = 4;
            // 
            // uxFieldsPanel
            // 
            this.uxFieldsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxFieldsPanel.Controls.Add(this.uxSpecialCharsCheckBox);
            this.uxFieldsPanel.Controls.Add(this.uxSeparatorLabel);
            this.uxFieldsPanel.Controls.Add(this.uxSeparatorText);
            this.uxFieldsPanel.Controls.Add(this.uxWordListLabel);
            this.uxFieldsPanel.Controls.Add(this.uxWordlistComboBox);
            this.uxFieldsPanel.Controls.Add(this.uxStudlyCapsCheckBox);
            this.uxFieldsPanel.Controls.Add(this.uxNumberOfWordsLabel);
            this.uxFieldsPanel.Controls.Add(this.uxNumberOfWords);
            this.uxFieldsPanel.Location = new System.Drawing.Point(0, 0);
            this.uxFieldsPanel.Name = "uxFieldsPanel";
            this.uxFieldsPanel.Size = new System.Drawing.Size(336, 170);
            this.uxFieldsPanel.TabIndex = 5;
            // 
            // uxSpecialCharsCheckBox
            // 
            this.uxSpecialCharsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxSpecialCharsCheckBox.Location = new System.Drawing.Point(24, 136);
            this.uxSpecialCharsCheckBox.Name = "uxSpecialCharsCheckBox";
            this.uxSpecialCharsCheckBox.Size = new System.Drawing.Size(296, 24);
            this.uxSpecialCharsCheckBox.TabIndex = 7;
            this.uxSpecialCharsCheckBox.Text = "Include randomised special characters?";
            this.uxSpecialCharsCheckBox.UseVisualStyleBackColor = true;
            this.uxSpecialCharsCheckBox.CheckedChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // uxSeparatorLabel
            // 
            this.uxSeparatorLabel.Location = new System.Drawing.Point(24, 104);
            this.uxSeparatorLabel.Name = "uxSeparatorLabel";
            this.uxSeparatorLabel.Size = new System.Drawing.Size(152, 23);
            this.uxSeparatorLabel.TabIndex = 6;
            this.uxSeparatorLabel.Text = "Customise the word separator? (Defaults to an empty space)";
            // 
            // uxSeparatorText
            // 
            this.uxSeparatorText.Location = new System.Drawing.Point(248, 104);
            this.uxSeparatorText.MaxLength = 5;
            this.uxSeparatorText.Name = "uxSeparatorText";
            this.uxSeparatorText.Size = new System.Drawing.Size(72, 20);
            this.uxSeparatorText.TabIndex = 5;
            this.uxSeparatorText.TextChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // uxWordListLabel
            // 
            this.uxWordListLabel.Location = new System.Drawing.Point(24, 72);
            this.uxWordListLabel.Name = "uxWordListLabel";
            this.uxWordListLabel.Size = new System.Drawing.Size(144, 23);
            this.uxWordListLabel.TabIndex = 4;
            this.uxWordListLabel.Text = "Choose a preferred wordlist?";
            // 
            // uxWordlistComboBox
            // 
            this.uxWordlistComboBox.FormattingEnabled = true;
            this.uxWordlistComboBox.Items.AddRange(new object[] {
            "Short (Avg word length ~4 characters)",
            "Long (Avg word legnth ~7 characters)"});
            this.uxWordlistComboBox.Location = new System.Drawing.Point(176, 72);
            this.uxWordlistComboBox.Name = "uxWordlistComboBox";
            this.uxWordlistComboBox.Size = new System.Drawing.Size(144, 21);
            this.uxWordlistComboBox.TabIndex = 3;
            this.uxWordlistComboBox.SelectedValueChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // uxStudlyCapsCheckBox
            // 
            this.uxStudlyCapsCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.uxStudlyCapsCheckBox.Location = new System.Drawing.Point(24, 40);
            this.uxStudlyCapsCheckBox.Name = "uxStudlyCapsCheckBox";
            this.uxStudlyCapsCheckBox.Size = new System.Drawing.Size(296, 24);
            this.uxStudlyCapsCheckBox.TabIndex = 2;
            this.uxStudlyCapsCheckBox.Text = "Use an upper case letter for the first letter of each word?";
            this.uxStudlyCapsCheckBox.UseVisualStyleBackColor = true;
            this.uxStudlyCapsCheckBox.CheckedChanged += new System.EventHandler(this.OptionsChanged);
            // 
            // uxExampleLabel
            // 
            this.uxExampleLabel.Location = new System.Drawing.Point(8, 8);
            this.uxExampleLabel.Name = "uxExampleLabel";
            this.uxExampleLabel.Size = new System.Drawing.Size(100, 23);
            this.uxExampleLabel.TabIndex = 8;
            this.uxExampleLabel.Text = "Example Phrase:";
            // 
            // uxExamplePhraseLabel
            // 
            this.uxExamplePhraseLabel.AutoEllipsis = true;
            this.uxExamplePhraseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxExamplePhraseLabel.Location = new System.Drawing.Point(8, 40);
            this.uxExamplePhraseLabel.Name = "uxExamplePhraseLabel";
            this.uxExamplePhraseLabel.Size = new System.Drawing.Size(320, 23);
            this.uxExamplePhraseLabel.TabIndex = 7;
            // 
            // uxExamplePanel
            // 
            this.uxExamplePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxExamplePanel.Controls.Add(this.uxExamplePhraseLabel);
            this.uxExamplePanel.Controls.Add(this.uxExampleLabel);
            this.uxExamplePanel.Location = new System.Drawing.Point(0, 170);
            this.uxExamplePanel.Name = "uxExamplePanel";
            this.uxExamplePanel.Size = new System.Drawing.Size(336, 76);
            this.uxExamplePanel.TabIndex = 9;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 286);
            this.Controls.Add(this.uxExamplePanel);
            this.Controls.Add(this.uxFieldsPanel);
            this.Controls.Add(this.uxControlsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diceware Generator Options";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).EndInit();
            this.uxControlsPanel.ResumeLayout(false);
            this.uxFieldsPanel.ResumeLayout(false);
            this.uxFieldsPanel.PerformLayout();
            this.uxExamplePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
