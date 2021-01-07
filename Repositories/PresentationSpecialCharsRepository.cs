/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;

namespace DicewareGenerator.Repositories
{
    /// <summary>
    /// Description of PresentationSpecialCharsRepository.
    /// </summary>
    public class PresentationSpecialCharsRepository : IDicewareSpecialCharsRepository
    {
        protected static string m_specialChars = "~!#$%^&*()-=+[]\\{}:;\"'<>?/022345678";
        protected static Random m_rnd = new Random();
            
        public PresentationSpecialCharsRepository()
        {
        }
        
        public DicewareFileType GetFileType()
        {
            return DicewareFileType.Special;
        }
        
        public List<string> GetRandom(int count)
        {
            List<string> result = new List<string>();
            
            for (int i = 0; i < count; i++) {
                result.Add(m_specialChars[m_rnd.Next(m_specialChars.Length)].ToString());
            }
            
            return result;
        }
        
        public string Transform(string input)
        {
            int idx = m_rnd.Next(input.Length);
            
            char[] result = input.ToCharArray();
            result[idx] = GetRandom(1)[0].ToCharArray()[0];
            
            return new string(result);
        }
    }
}
