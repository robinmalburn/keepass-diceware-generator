/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using DicewareGenerator.Models;
using DicewareGenerator.Repositories;

namespace DicewareGenerator.UI
{
    /// <summary>
    /// Description of Options.
    /// </summary>
    public partial class Options : Form
    {
        protected Config m_config;
        
        public Options()
        {
            InitializeComponent();
            uxWordlistComboBox.DataSource = Enum.GetValues(typeof(DicewareFileType));
        }
        
        protected string SeparatorExample {
            get {
                return string.Format("Example: foo{0}bar{0}baz", uxSeparatorText.Text);
            }
        }
        
        public Options(Config config) : this()
        {
            m_config = config;
            
            uxNumberOfWords.Value = config.NumberOfWords;
            uxStudlyCapsCheckBox.Checked = config.StudlyCaps;
            uxWordlistComboBox.SelectedItem = config.Wordlist;
            uxSeparatorText.Text = config.Separator;
            uxSeparatorExampleLabel.Text = SeparatorExample;
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
        
        void UxSeparatorTextTextChanged(object sender, EventArgs e)
        {
          uxSeparatorExampleLabel.Text = SeparatorExample;
        }
 

    }
}
