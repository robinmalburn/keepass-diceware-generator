/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using DicewareGenerator.Models;
using DicewareGenerator.Repositories;
using DicewareGenerator.Generators;

namespace DicewareGenerator.UI
{
    /// <summary>
    /// Description of Options.
    /// </summary>
    public partial class Options : Form
    {
        protected readonly Config m_config;
        protected readonly Config m_presentationConfig;
        protected readonly IPhraseGenerator m_generator;
        
        public Options()
        {
            InitializeComponent();
            
            uxWordlistComboBox.DataSource = Enum.GetValues(typeof(DicewareFileType));
            m_presentationConfig = new Config();
            m_generator = new PhraseGenerator(m_presentationConfig, new PresentationDicewareRepository(m_presentationConfig));
        }
        
        public Options(Config config) : this()
        {
            m_config = config;
            
            uxNumberOfWords.Value = config.NumberOfWords;
            uxStudlyCapsCheckBox.Checked = config.StudlyCaps;
            uxWordlistComboBox.SelectedItem = config.Wordlist;
            uxSeparatorText.Text = config.Separator;
            
            OptionsChanged();
        }
        
        void UxCancelBtnClick(object sender, EventArgs e)
        {
            Close();
        }
        
        void UxOKBtnClick(object sender, EventArgs e)
        {
            m_config.NumberOfWords = uxNumberOfWords.Value;
            m_config.StudlyCaps = uxStudlyCapsCheckBox.Checked;
            m_config.Wordlist = (DicewareFileType)uxWordlistComboBox.SelectedItem;
            m_config.Separator = uxSeparatorText.Text;
            
            Close();
        }
        
        protected void OptionsChanged()
        {
            m_presentationConfig.NumberOfWords = uxNumberOfWords.Value;
            m_presentationConfig.StudlyCaps = uxStudlyCapsCheckBox.Checked;
            m_presentationConfig.Wordlist = (DicewareFileType)uxWordlistComboBox.SelectedItem;
            m_presentationConfig.Separator = uxSeparatorText.Text;
            
            uxExamplePhraseLabel.Text = m_generator.Generate().ReadString();
        }
        
        protected void OptionsChanged(object sender, EventArgs e)
        {
            OptionsChanged();
        }

    }
}
