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
    using DicewareGenerator.Models;

    /// <summary>
    /// Simple presentation repository for returning dummy values.
    /// </summary>
    public class PresentationDicewareRepository : IDicewareRepository
    {
        /// <summary>
        /// Short words to be used by the repository.
        /// </summary>
        private static readonly ReadOnlyCollection<string> ShortWords = Array.AsReadOnly(new string[] { "foo", "bar", "baz" });
        
        /// <summary>
        /// Long words to be used by the repository.
        /// </summary>
        private static readonly ReadOnlyCollection<string> LongWords = Array.AsReadOnly(new string[] { "epiphany", "season", "richochet" });
        
        /// <summary>
        /// The configuration to be used.
        /// </summary>
        private readonly Config config;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationDicewareRepository"/> class.
        /// </summary>
        /// <param name="config">The configuration</param>
        public PresentationDicewareRepository(Config config) 
        {
            this.config = config;
        }
        
        /// <summary>
        /// Gets the file type the repository relates to.
        /// </summary>
        /// <returns>The repository's related <see cref="DicewareFileType"/></returns>
        public DicewareFileType GetFileType()
        {
            return this.config.Wordlist;
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
            
            var words = this.GetFileType() == DicewareFileType.Short ? ShortWords : LongWords;
            
            for (int i = 0;  i < count; i++)
            {
                result.Add(words[i % 3]);
            }
            
            return result;
        }
    }
}
