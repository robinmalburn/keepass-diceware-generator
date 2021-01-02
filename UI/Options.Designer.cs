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
        private System.Windows.Forms.Button uxSaveBtn;
        private System.Windows.Forms.Button uxCancelBtn;
        
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
            this.uxSaveBtn = new System.Windows.Forms.Button();
            this.uxCancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).BeginInit();
            this.SuspendLayout();
            // 
            // uxNumberOfWords
            // 
            this.uxNumberOfWords.Location = new System.Drawing.Point(256, 8);
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
            // 
            // uxNumberOfWordsLabel
            // 
            this.uxNumberOfWordsLabel.Location = new System.Drawing.Point(8, 8);
            this.uxNumberOfWordsLabel.Name = "uxNumberOfWordsLabel";
            this.uxNumberOfWordsLabel.Size = new System.Drawing.Size(240, 24);
            this.uxNumberOfWordsLabel.TabIndex = 1;
            this.uxNumberOfWordsLabel.Text = "How many words should the phrase consist of?";
            // 
            // uxSaveBtn
            // 
            this.uxSaveBtn.Location = new System.Drawing.Point(248, 48);
            this.uxSaveBtn.Name = "uxSaveBtn";
            this.uxSaveBtn.Size = new System.Drawing.Size(75, 23);
            this.uxSaveBtn.TabIndex = 2;
            this.uxSaveBtn.Text = "Save";
            this.uxSaveBtn.UseVisualStyleBackColor = true;
            this.uxSaveBtn.Click += new System.EventHandler(this.UxSaveBtnClick);
            // 
            // uxCancelBtn
            // 
            this.uxCancelBtn.Location = new System.Drawing.Point(168, 48);
            this.uxCancelBtn.Name = "uxCancelBtn";
            this.uxCancelBtn.Size = new System.Drawing.Size(75, 23);
            this.uxCancelBtn.TabIndex = 3;
            this.uxCancelBtn.Text = "Cancel";
            this.uxCancelBtn.UseVisualStyleBackColor = true;
            this.uxCancelBtn.Click += new System.EventHandler(this.UxCancelBtnClick);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 81);
            this.Controls.Add(this.uxCancelBtn);
            this.Controls.Add(this.uxSaveBtn);
            this.Controls.Add(this.uxNumberOfWordsLabel);
            this.Controls.Add(this.uxNumberOfWords);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Diceware Generator Options";
            ((System.ComponentModel.ISupportInitialize)(this.uxNumberOfWords)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
