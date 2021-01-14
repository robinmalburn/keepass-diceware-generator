/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGenerator.Repositories
{
    using System;
    using DicewareGenerator.Crypto;
    
    /// <summary>
    /// Special character file based repository.
    /// </summary>
    public class FileSpecialCharsRepository : AbstractFileRepository, ISpecialCharsRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileSpecialCharsRepository"/> class.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="indexLength">The repository's <see cref="DicewareIndexLength"/>.</param>
        /// <param name="cryptoRandom">The cryptographic random utility.</param>
        public FileSpecialCharsRepository(string path, DicewareIndexLength indexLength, RandomUtil cryptoRandom)
        {
            this.Path = path;
            this.IndexLength = indexLength;
            this.Random = cryptoRandom;
            this.PopulateData(DicewareFileType.Special);
        }
        
        /// <summary>
        /// Apply random transformations to the given input string.
        /// </summary>
        /// <param name="input">The string to transform</param>
        /// <returns>The transformed string</returns>
        public string Transform(string input)
        {
            int idx = (int)Random.RandomRange((ulong)input.Length);
            
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
            return this.Data[this.GetIndexString()][0];
        }
    }
}
