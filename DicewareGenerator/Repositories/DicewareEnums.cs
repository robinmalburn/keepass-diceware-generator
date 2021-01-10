/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGenerator.Repositories
{
    /// <summary>
    /// Filetype enums.
    /// </summary>
    public enum DicewareFileType : int
    {
        /// <summary>
        /// Represents a short filetype.
        /// </summary>
        Short,
        
        /// <summary>
        /// Represents a long or large filetype.
        /// </summary>
        Long,
        
        /// <summary>
        /// Represents a special characters filetype.
        /// </summary>
        Special,
    }
    
    /// <summary>
    /// Index length enums.
    /// </summary>
    public enum DicewareIndexLength : int
    {
        /// <summary>
        /// Represents a short, 4 digit index.
        /// </summary>
        Short = 4,
        
        /// <summary>
        /// Represents a long or large, 5 digit index.
        /// </summary>
        Long = 5,
        
        /// <summary>
        /// Represents a special character, 2 digit index.
        /// </summary>
        Special = 2,
    }
}