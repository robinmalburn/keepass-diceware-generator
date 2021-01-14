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
    using System.IO;
    using DicewareGenerator.Crypto;
    
    /// <summary>
    /// Abstract file based repository.
    /// </summary>
    abstract public class AbstractFileRepository
    {        
        /// <summary>
        /// Dictionary of words indexed by their dice-like index.
        /// </summary>
        protected Dictionary<string, string> Data = new Dictionary<string, string>();
       
        /// <summary>
        /// Gets or sets the cryptographic random utility.
        /// </summary>
        protected RandomUtil Random { get; set; }
        
        /// <summary>
        /// Gets the Path for the related file.
        /// </summary>
        protected string Path { get; set; }
        
        /// <summary>
        /// The index length for the repository.
        /// </summary>
        protected DicewareIndexLength IndexLength { get; set; }

        /// <summary>
        /// Load the repository's file source.
        /// </summary>
        /// <param name="type">The type of Diceware file to load.</param>
        protected void PopulateData(DicewareFileType type)
        {
            if (this.Data.Count > 0) 
            {
                return;
            }
            
            foreach (string line in File.ReadLines(this.Path))
            {
                string[] parts = line.Split('\t');
                this.Data.Add(parts[0], parts[1]);
            }
        }
        
        /// <summary>
        /// Get a Diceware index string of the desired length.
        /// </summary>
        /// <returns>A Diceware string index</returns>
        protected string GetIndexString()
        {
            int len = (int)this.IndexLength;
            var indices = new ulong[len];
            
            for (int i = 0; i < len; i++)
            {
                indices[i] = this.Random.RandomRange(7, 1);
            }
            
            return string.Join(string.Empty, indices);
        }
    }
}
