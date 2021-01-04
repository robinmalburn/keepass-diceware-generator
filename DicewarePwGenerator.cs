﻿/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using DicewareGenerator.Generators;
using DicewareGenerator.UI;
using DicewareGenerator.Repositories;
using DicewareGenerator.Models;
using KeePassLib;
using KeePassLib.Cryptography;
using KeePassLib.Cryptography.PasswordGenerator;
using KeePassLib.Security;

namespace DicewareGenerator
{
    /// <summary>
    /// Diceware based password generator class.
    /// </summary>
    public class DicewarePwGenerator: CustomPwGenerator
    {
        const ulong DICE_SIZE = 6;
        
        private static readonly PwUuid m_uuid = new PwUuid(
            new Byte[] {
                0x1D, 0xE9, 0x81, 0x24, 0xD9, 0x4C, 0x61, 0x41,
                0x8F, 0xE3, 0x9D, 0x94, 0xC7, 0xBE, 0x25, 0xDF
            }
           );
        
        protected static IDicewareRepository m_repository;
        
        public override string Name
        {
            get { return "Diceware Generator"; }
        }
        
        public override PwUuid Uuid
        {
            get { return m_uuid; }
        }
        
        public override bool SupportsOptions
        {
            get { return true; }
        }
        
        public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
        {
            Config config = Config.deserialize(prf.CustomAlgorithmOptions);
            
            IDicewareRepository repo = GetRepository(config, crsRandomSource);
            IPhraseGenerator generator = new PhraseGenerator(config, repo);

            return generator.Generate();
        }
        
        public override string GetOptions(string strCurrentOptions)
        {
            Config config = Config.deserialize(strCurrentOptions);
            Options options = new Options(config);
            options.ShowDialog();
            
            return Config.serialize(config);
        }
        
        /// <summary>
        /// Get the Diceware Repository instance.
        /// </summary>
        /// <param name="config">The plugin configuration.</param>
        /// <param name="cryptoRandom">Cryptographic random range.</param>
        /// <returns>Returns an instance of the Diceware repository.</returns>
        protected IDicewareRepository GetRepository(Config config, CryptoRandomStream cryptoRandom)
        {
            IDicewareRepositoryFactory repo = new DicewareRepositoryFactory(config);
                
            m_repository = repo.Make(cryptoRandom);
            
            return m_repository;
        }

      
    }
}