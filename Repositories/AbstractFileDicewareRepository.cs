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
    using System.IO;
    using DicewareGenerator.Crypto;
    
    /// <summary>
    /// Abstract file based Diceware Repository.
    /// </summary>
    abstract public class AbstractFileDicewareRepository : IDicewareRepository
    {        
        /// <summary>
        /// Filenames of local Diceware files.
        /// </summary>
        private static readonly ReadOnlyCollection<string> filenames = Array.AsReadOnly(new string[] { 
            "eff_short_wordlist.txt",
            "eff_large_wordlist.txt",
            "special_chars.txt",
        });
        
        /// <summary>
        /// Dictionary of words indexed by their dice-like index.
        /// </summary>
        private Dictionary<string, string> data = new Dictionary<string, string>();
       
        /// <summary>
        /// Gets or sets the cryptographic random utility.
        /// </summary>
        protected RandomUtil Random { get; set; }

        /// <summary>
        /// Get the index length for the given repository type.
        /// </summary>
        /// <returns>The require length of the repository's index.</returns>
       public abstract DicewareIndexLength GetIndexLength();
        
        /// <summary>
        /// Gets the file type the repository relates to.
        /// </summary>
        /// <returns>The repository's related <see cref="DicewareFileType"/></returns>
        public abstract DicewareFileType GetFileType();
        
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
                throw new ArgumentOutOfRangeException("count");
            }
            
            var result = new List<string>();
            
            for (int i = 0; i < count; i++)
            {
                result.Add(this.data[this.GetIndexString()]);
            }
            
            return result;
        }

        /// <summary>
        /// Returns the path for given Diceware filetype.
        /// </summary>
        /// <param name="type">The type of file.</param>
        /// <returns>Returns the path of the file for this repository.</returns>
        protected string GetFileTypePath(DicewareFileType type)
        {
            string filename = filenames[(int)type];
            
            string basepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            
            string path = Path.Combine(basepath, filename);

            /* The default path should return a URI style file://c/foo path,
             * check for that, and if not, fall back to to regular path handling.
             */
            if (path.StartsWith("file:", StringComparison.Ordinal))
            {
                try {
                    return new Uri(path).LocalPath;
                } catch (UriFormatException) {
                    /* Neither windows nor Linux provide "well formed" URIs
                     * as far as C# is concerned, but the Linux ones cause a
                     * format exception, so let's catch that and try to correct
                     * the formatting error.
                     */
                    path = path.Replace("file:", "file://");
                    return new Uri(path).LocalPath;
                }
            }
            
            return Path.GetFullPath(path);
        }
        
        /// <summary>
        /// Load the repository's file source.
        /// </summary>
        /// <param name="type">The type of Diceware file to load.</param>
        protected void PopulateData(DicewareFileType type)
        {
            if (this.data.Count > 0) 
            {
                return;
            }
            
            string path = this.GetFileTypePath(type);
            
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split('\t');
                this.data.Add(parts[0], parts[1]);
            }
        }
        
        /// <summary>
        /// Get a Diceware index string of the desired length.
        /// </summary>
        /// <returns>A Diceware string index</returns>
        protected string GetIndexString()
        {
            int len = (int)this.GetIndexLength();
            var indices = new ulong[len];
            
            for (int i = 0; i < len; i++)
            {
                indices[i] = this.Random.RandomRange(7, 1);
            }
            
            return string.Join(string.Empty, indices);
        }
    }
}
