﻿/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using DicewareGenerator.Repositories;
using KeePassLib;
using KeePassLib.Cryptography;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePassLib.Security;

namespace DicewareGenerator
{
    /// <summary>
    /// Diceware based password generator class.
    /// </summary>
    public class DicewareGenerator: CustomPwGenerator
    {
        const ulong DICE_SIZE = 6;
        
        private static readonly PwUuid m_uuid = new PwUuid(
            new Byte[] {
                0x1D, 0xE9, 0x81, 0x24, 0xD9, 0x4C, 0x61, 0x41,
                0x8F, 0xE3, 0x9D, 0x94, 0xC7, 0xBE, 0x25, 0xDF
            }
           );
        
        public override string Name
        {
            get { return "Diceware Generator"; }
        }
        
        public override PwUuid Uuid
        {
            get { return m_uuid; }
        }
        
        public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
        {
            FileShortDicewareRepository repo = new FileShortDicewareRepository();
            
            for (int i = 0 ; i < 6; i++)
            {
                repo.SearchByIndices(GetIndexString(crsRandomSource, 4));
            }
            
            string pwd = string.Join(" ", repo.Get());
            
            return new ProtectedString(false, pwd);
        }

        /// <summary>
        /// Get a random index for the wordlist.
        /// </summary>
        /// <param name="crsRandomSource">KeePass cryptographic random number generator.</param>
        /// <param name="max">Max valid random number (inclusive)</param>
        /// <returns>Returns a random number between 1 and <paramref name="max"/> (inclusive)</returns>
        protected ulong GetRandomIndex(CryptoRandomStream crsRandomSource, ulong max)
        {
            ulong maxValid = UInt64.MaxValue - (UInt64.MaxValue % max);
            
            ulong idx = crsRandomSource.GetRandomUInt64();
            
            while (idx >= maxValid) {
                idx = crsRandomSource.GetRandomUInt64();
            }
            
            return (idx % max) + 1;
        }
        
        /// <summary>
        /// Get a Diceware index string of the desired length.
        /// </summary>
        /// <param name="crsRandomSource">KeePass cryptographic random number generator.</param>
        /// <param name="len">The legnth of the string to generate</param>
        /// <returns></returns>
        protected string GetIndexString(CryptoRandomStream crsRandomSource, ulong len)
        {
            ulong[] indices = new ulong[len];
            
            for (ulong i = 0; i < len; i++) 
            {
                indices[i] = GetRandomIndex(crsRandomSource, DICE_SIZE);
            }
            
            return string.Join("", indices);
        }
    }
}
