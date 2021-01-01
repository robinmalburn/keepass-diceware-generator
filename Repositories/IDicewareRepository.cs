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
    /// Interface for retrieving values from a diceware based word/character list.
    /// </summary>
    public interface IDicewareRepository
    {      
        /// <summary>
        /// Add search criteria for an index.
        /// </summary>
        /// <param name="index">The diceware index to search for</param>
        void SearchByIndices(string index);

        /// <summary>
        /// Add search criteria for one or more indices.
        /// </summary>
        /// <param name="indices">The diceware index or indices to search for</param>
        void SearchByIndices(string[] indices);
        
        /// <summary>
        /// Clear existing criteria.
        /// </summary>
        void Clear();
        
        /// <summary>
        /// Get the results for any existing criteria.
        /// </summary>
        List<String> Get();
    }
}
