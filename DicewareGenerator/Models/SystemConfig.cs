/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGenerator.Models
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using DicewareGenerator.Repositories;
    
    /// <summary>
    /// System Configuration Model.
    /// </summary>
    public class SystemConfig
    {
        /// <summary>
        /// Filenames of local Diceware files.
        /// </summary>
        private static readonly ReadOnlyCollection<string> Filenames = Array.AsReadOnly(new string[] 
        {
            "eff_short_wordlist.txt",
            "eff_large_wordlist.txt",
            "special_chars.txt",
        });
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SystemConfig"/> class.
        /// </summary>
        public SystemConfig()
        {
            this.Basepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }
        
        /// <summary>
        /// Gets or sets the basepath.
        /// </summary>
        public string Basepath { get; set; }
        
        /// <summary>
        /// Returns the path for the given filetype.
        /// </summary>
        /// <param name="filetype">The <see cref="DicewareFileType"/> to get the path for.</param>
        /// <returns></returns>
        public string GetPathForFileType(DicewareFileType filetype)
        {
            string filename = Filenames[(int)filetype];
            
            string path = Path.Combine(this.Basepath, filename);
            
            /* The default path should return a URI style file:\c\foo path,
             * check for that, and if not, fall back to to regular path handling.
             */
            if (path.StartsWith("file:", StringComparison.Ordinal))
            {
                return new Uri(path).LocalPath;    
            }
            
            return Path.GetFullPath(path);
        }
    }
}
