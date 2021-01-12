/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGenerator.Crypto
{
    using System;
    using KeePassLib.Cryptography;

    /// <summary>
    /// Cryptographically secure random utilities.
    /// </summary>
    public class RandomUtil
    {
        /// <summary>
        /// Cryptographic random source.
        /// </summary>
        protected readonly CryptoRandomStream CryptoRandom;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomUtil" /> class.
        /// </summary>
        /// <param name="randomSource">KeePass Cryptographic Random Source.</param>
        public RandomUtil(CryptoRandomStream randomSource)
        {
            this.CryptoRandom = randomSource;
        }
        
        /// <summary>
        /// Get a secure random number in the given range.
        /// </summary>
        /// <param name="max">Maximum value</param>
        /// <param name="min">Minimum value</param>
        /// <returns>The random number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If the minimum value is greater than or equal the maximum value.</exception>
        /// <exception cref="ArgumentOutOfRangeException">If the maximum value is less than or equal to zero.</exception>
        public ulong RandomRange(ulong max, ulong min = 0)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException("min", "Minimum value must be less than maximum value.");
            }
            
            if (max == 0) 
            {
                throw new ArgumentOutOfRangeException("max", "Maximum value must be greater than zero.");
            }

            ulong maxValid = ulong.MaxValue - (ulong.MaxValue % max);
            ulong val = this.CryptoRandom.GetRandomUInt64();
            
            while (val >= maxValid)
            {
                val = this.CryptoRandom.GetRandomUInt64();
            }
            
            ulong result = val % max;
            
            return result < min ? min : result;
        } 
    }
}
