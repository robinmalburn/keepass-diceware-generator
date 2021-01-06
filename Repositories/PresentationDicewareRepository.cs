/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using DicewareGenerator.Models;

namespace DicewareGenerator.Repositories
{
    /// <summary>
    /// Simple presentation repository for returning dummy values.
    /// </summary>
    public class PresentationDicewareRepository : IDicewareRepository
    {
        protected static readonly string[] m_shortWords = { "foo", "bar", "baz" };
        protected static readonly string[] m_longWords = { "epiphany", "season", "richochet" };
        
        protected readonly Config m_config;
        
        public PresentationDicewareRepository(Config config) 
        {
            m_config = config;
        }
        
        public DicewareFileType GetFileType()
        {
            return m_config.Wordlist;
        }
        
        public DicewareIndexLength GetIndexLength()
        {
            return (DicewareIndexLength)GetFileType();
        }
        
        public List<string> GetRandom(int count)
        {
            List<string> result = new List<string>();
            
            string[] words = GetFileType() == DicewareFileType.Short ? m_shortWords : m_longWords;
            
            for (int i = 0;  i < count; i++) {
                result.Add(words[i % 3]);
            }
            
            return result;
        }
    }
}
