/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGenerator.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// Presentation Special Chars Repository.
    /// </summary>
    public class PresentationSpecialCharsRepository : ISpecialCharsRepository
    {
        /// <summary>
        /// The special characters to use.
        /// </summary>
        private static readonly ReadOnlyCollection<char> SpecialChars = Array.AsReadOnly("~!#$%^&*()-=+[]\\{}:;\"'<>?/022345678".ToCharArray());
        
        /// <summary>
        /// Random number generator to use.
        /// </summary>
        private static readonly Random Random = new Random();
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationSpecialCharsRepository"/> class.
        /// </summary>
        public PresentationSpecialCharsRepository()
        {
        }
        
        /// <summary>
        /// Apply random transformations to the given input string.
        /// </summary>
        /// <param name="input">The string to transform</param>
        /// <returns>The transformed string</returns>
        public string Transform(string input)
        {
            int idx = Random.Next(input.Length);
            
            char[] result = input.ToCharArray();
            result[idx] = this.GetRandom();
            
            return new string(result);
        }
        
        /// <summary>
        /// Get a random char from the repository.
        /// </summary>
        /// <returns>A random character from the repository.</returns>
        private char GetRandom()
        {
            return SpecialChars[Random.Next(SpecialChars.Count)];
        }
    }
}
