/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGenerator.UI
{
    using System;
    using System.Windows.Forms;
    using DicewareGenerator.Generators;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;

    /// <summary>
    /// Options configuration form.
    /// </summary>
    public partial class Options : Form
    {
        /// <summary>
        /// Shared configuration object with calling window.
        /// </summary>
        private UserConfig config;
        
        /// <summary>
        /// Configuration object used for presentation preview. 
        /// </summary>
        private UserConfig presentationConfig;
        
        /// <summary>
        /// Phrase generator used for presentation preview.
        /// </summary>
        private IPhraseGenerator generator;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        public Options()
        {
            this.InitializeComponent();
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Options"/> class.
        /// </summary>
        /// <param name="config">The shared configuration object to be updated.</param>
        public Options(UserConfig config) : this()
        {
            this.config = config;
            
            this.presentationConfig = new UserConfig();
            this.generator = new PhraseGenerator(
                this.presentationConfig, 
                new PresentationPhraseRepository(this.presentationConfig), 
                new PresentationSpecialCharsRepository());
            
            DicewareFileType[] wordLists = { DicewareFileType.Short, DicewareFileType.Long };
            this.uxWordlistComboBox.DataSource = wordLists;
            
            this.uxNumberOfWords.Value = config.NumberOfWords;
            this.uxStudlyCapsCheckBox.Checked = config.StudlyCaps;
            this.uxWordlistComboBox.SelectedItem = config.Wordlist;
            this.uxSeparatorText.Text = config.Separator;
            this.uxSpecialCharsCheckBox.Checked = config.SpecialChars;
            
            this.UpdatePreview();
        }
        
        /// <summary>
        /// Handles updating the preview with the latest user selected options.
        /// </summary>
        private void UpdatePreview()
        {
            this.presentationConfig.NumberOfWords = this.uxNumberOfWords.Value;
            this.presentationConfig.StudlyCaps = this.uxStudlyCapsCheckBox.Checked;
            this.presentationConfig.Wordlist = (DicewareFileType)this.uxWordlistComboBox.SelectedItem;
            this.presentationConfig.Separator = this.uxSeparatorText.Text;
            this.presentationConfig.SpecialChars = this.uxSpecialCharsCheckBox.Checked;
            
            this.uxExamplePhraseLabel.Text = this.generator.Generate().ReadString();
        }
        
        /// <summary>
        /// Cancel button click event handler.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void UxCancelBtnClick(object sender, EventArgs e)
        {
            this.Close();
        }
        
        /// <summary>
        /// OK button click event handler.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void UxOKBtnClick(object sender, EventArgs e)
        {
            this.config.NumberOfWords = this.uxNumberOfWords.Value;
            this.config.StudlyCaps = this.uxStudlyCapsCheckBox.Checked;
            this.config.Wordlist = (DicewareFileType)this.uxWordlistComboBox.SelectedItem;
            this.config.Separator = this.uxSeparatorText.Text;
            this.config.SpecialChars = this.uxSpecialCharsCheckBox.Checked;
            
            this.Close();
        }
        
        /// <summary>
        /// Generic options changed event handler.
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void OptionsChanged(object sender, EventArgs e)
        {
            this.UpdatePreview();
        }
    }
}
