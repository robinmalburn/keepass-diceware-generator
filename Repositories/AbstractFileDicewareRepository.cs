/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.IO;

namespace DicewareGenerator.Repositories
{ 
    /// <summary>
    /// Abstract file based Diceware Repository.
    /// </summary>
    abstract public class AbstractFileDicewareRepository : IDicewareRepository
    {
        protected readonly string[] m_filenames = new string[] { 
            "eff_short_wordlist.txt",
            "eff_large_wordlist.txt"
        };
        protected readonly List<string>  m_indices = new List<string>();
        protected readonly Dictionary<string, string> m_data = new Dictionary<string, string>();

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
        
        /// <summary>
        /// Add search criteria for an index.
        /// </summary>
        /// <param name="index">The diceware index to search for</param>
        public void SearchByIndices(string index)
        {
            m_indices.Add(index);
        }
        
        /// <summary>
        /// Add search criteria for one or more indices.
        /// </summary>
        /// <param name="indices">The diceware index or indices to search for</param>
        public void SearchByIndices(string[] indices)
        {
            m_indices.AddRange(indices);
        }
        
        /// <summary>
        /// Clear existing criteria.
        /// </summary>
        public void Clear()
        {
            m_indices.Clear();
        }
        
        /// <summary>
        /// Get the results for any existing criteria.
        /// </summary>
        public List<String> Get()
        {
            List<string> result = new List<string>();
            
            foreach (string index in m_indices)
            {
                result.Add(m_data[index]);
            }
            
            Clear();
            
            return result;
        }
    }
}
