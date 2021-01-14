/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGeneratorTests.Repositories
{
    using System;
    using System.Collections.Generic;
    using DicewareGenerator.Repositories;
    
    /// <summary>
    /// Stub implementation of the <see cref="IDicewareRepository"/> interface.
    /// </summary>
    public class StubDicewareRepository : IPhraseRepository
    {
        /// <summary>
        /// The word to use when generating a word list.
        /// </summary>
        private const string Word = "foo";
        
        /// <summary>
        /// Initializes a new instance of <see cref="StubDicewareRepository"/> class.
        /// </summary>
        public StubDicewareRepository()
        {
        }
        
        /// <summary>
        /// Get the filetype of the repository.
        /// </summary>
        /// <returns>Returns the filetype of the repository.</returns>
        public DicewareFileType GetFileType()
        {
            return DicewareFileType.Short;
        }
        
        /// <summary>
        /// Get <paramref name="count"/> random entries from the repository.
        /// </summary>
        /// <param name="count">The number of random references to return.</param>
        /// <returns>A list of random entries.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if count is less than or equal to zero.</exception>
        public List<string> GetRandom(int count)
        {
            if (count <= 0) 
            {
                throw new ArgumentOutOfRangeException("count", "Count must be greater than zero");
            }
            
            var result = new List<string>();
            
            for (int i = 0; i < count; i++)
            {
                result.Add(Word);
            }
            
            return result;
        }
    }
}
