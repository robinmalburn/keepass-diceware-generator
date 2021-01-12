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
    /// Short file based diceware repository implementation.
    /// </summary>
    public class FileShortDicewareRepository : AbstractFileDicewareRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileShortDicewareRepository"/> class.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="random">The cryptographic random utility.</param>
        public FileShortDicewareRepository(string path, RandomUtil random)
        {
           this.Path = path;
           this.Random = random;
           this.PopulateData(DicewareFileType.Short);
        }
        
        /// <summary>
        /// Get the index length for the given repository type.
        /// </summary>
        /// <returns>The require length of the repository's index.</returns>
        public override DicewareIndexLength GetIndexLength()
        {
            return DicewareIndexLength.Short;
        }
        
        /// <summary>
        /// Gets the file type the repository relates to.
        /// </summary>
        /// <returns>The repository's related <see cref="DicewareFileType"/></returns>
        public override DicewareFileType GetFileType() 
        {
            return DicewareFileType.Short;
        }
    }
}
