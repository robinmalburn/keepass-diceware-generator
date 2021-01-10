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
    /// IDicewareRepositoryFactory Interface.
    /// </summary>
    public interface IDicewareRepositoryFactory
    {
        /// <summary>
        /// Make an instance of the Diceware Repository.
        /// </summary>
        /// <param name="random">Cryptographic Random Utility instance.</param>
        /// <returns>Returns an instance of the Diceware Repository.</returns>
        IDicewareRepository Make(RandomUtil random);
        
        /// <summary>
        /// Make an instance of the Special Chars Diceware Repository.
        /// </summary>
        /// <param name="random">Cryptographic Random Utility instance.</param>
        /// <returns>Returns an instance of the Diceware Special Chars Repository.</returns>
        IDicewareSpecialCharsRepository MakeSpecialChars(RandomUtil random);
    }
}
