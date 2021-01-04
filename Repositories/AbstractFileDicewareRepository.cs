/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.IO;
using KeePassLib.Cryptography;

namespace DicewareGenerator.Repositories
{ 
    /// <summary>
    /// Abstract file based Diceware Repository.
    /// </summary>
    abstract public class AbstractFileDicewareRepository : IDicewareRepository
    {
        protected static readonly string[] m_filenames = new string[] { 
            "eff_short_wordlist.txt",
            "eff_large_wordlist.txt"
        };
        protected readonly Dictionary<string, string> m_data = new Dictionary<string, string>();
        protected CryptoRandomStream m_cryptoRandom;
        protected static ulong DiceSize {
            get {
                return 6;
            }
        }
        protected static ulong MaxValidRandRange {
            get {
                return UInt64.MaxValue - (UInt64.MaxValue % DiceSize);
            }
        }

        /// <summary>
        /// Returns the path for given Diceware filetype.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected string GetFileTypePath(DicewareFileType type)
        {
            string filename = m_filenames[(int)type];
            
            string basepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            
            return  new Uri(Path.Combine(basepath, filename)).LocalPath;
        }
        
        /// <summary>
        /// Load the repository's file source.
        /// </summary>
        /// <param name="type">The type of diceware file to load.</param>
        protected void PopulateData(DicewareFileType type)
        {
            if (m_data.Count > 0) 
            {
                return;
            }
            
            string path = GetFileTypePath(type);
            
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split('\t');
                m_data.Add(parts[0], parts[1]);
            }
        }
        
        /// <summary>
        /// Get the index length for the given repository type.
        /// </summary>
        /// <returns>The require length of the repository's index.</returns>
        abstract public DicewareIndexLength GetIndexLength();
        
        abstract public DicewareFileType GetFileType();
        
        public List<string> GetRandom(int count)
        {
            if (count <= 0) {
                throw new ArgumentOutOfRangeException("count");
            }
            
            List<string> result = new List<string>();
            
            for (int i = 0; i < count; i++) {
                result.Add(m_data[GetIndexString()]);
            }
            
            return result;
            
        }
        
        /// <summary>
        /// Get a random index for the wordlist.
        /// </summary>
        /// <returns>Returns a random number between 1 and the max dice size (inclusive)</returns>
        protected ulong GetRandomIndex()
        {
            ulong idx = m_cryptoRandom.GetRandomUInt64();
            
            while (idx >= MaxValidRandRange) {
                idx = m_cryptoRandom.GetRandomUInt64();
            }
            
            return (idx % DiceSize) + 1;
        }
        
        /// <summary>
        /// Get a Diceware index string of the desired length.
        /// </summary>
        /// <returns>A diceware string index</returns>
        protected string GetIndexString()
        {
            int len = (int)GetIndexLength();
            ulong[] indices = new ulong[len];
            
            for (int i = 0; i < len; i++) {
                indices[i] = GetRandomIndex();
            }
            
            return string.Join("", indices);
        }
    }
}
