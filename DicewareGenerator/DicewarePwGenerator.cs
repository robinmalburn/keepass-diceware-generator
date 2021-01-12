/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGenerator
{
    using System;
    using DicewareGenerator.Crypto;
    using DicewareGenerator.Generators;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using DicewareGenerator.UI;
    using KeePassLib;
    using KeePassLib.Cryptography;
    using KeePassLib.Cryptography.PasswordGenerator;
    using KeePassLib.Security;
    
    /// <summary>
    /// Diceware based password generator class.
    /// </summary>
    public class DicewarePwGenerator : CustomPwGenerator
    {
        /// <summary>
        /// The static UUID for the generator.
        /// </summary>
        private static readonly PwUuid StaticUuid = new PwUuid(
            new byte[] 
            {
                0x1D, 0xE9, 0x81, 0x24, 0xD9, 0x4C, 0x61, 0x41,
                0x8F, 0xE3, 0x9D, 0x94, 0xC7, 0xBE, 0x25, 0xDF
            });
        
        /// <summary>
        /// Gets the name of the generator.
        /// </summary>
        public override string Name
        {
            get { return "Diceware Generator"; }
        }
        
        /// <summary>
        /// Gets the UUID for the generator.
        /// </summary>
        public override PwUuid Uuid
        {
            get { return StaticUuid; }
        }
        
        /// <summary>
        /// Gets a value determining whether the generator supports options.
        /// </summary>
        public override bool SupportsOptions
        {
            get { return true; }
        }
        
        /// <summary>
        /// Generates and returns a password as a protected string.
        /// </summary>
        /// <param name="prf">Password profile.</param>
        /// <param name="crsRandomSource">Cryptographic random source.</param>
        /// <returns>The generated password.</returns>
        public override ProtectedString Generate(PwProfile prf, CryptoRandomStream crsRandomSource)
        {
            UserConfig config = UserConfig.Deserialize(prf.CustomAlgorithmOptions);
            SystemConfig sysConfig = new SystemConfig();
            RandomUtil random = new RandomUtil(crsRandomSource);
            IDicewareRepositoryFactory factory = new DicewareRepositoryFactory(config, sysConfig);
            IDicewareRepository repo = factory.Make(random);
            IDicewareSpecialCharsRepository specialCharsRepo = factory.MakeSpecialChars(random);
            
            IPhraseGenerator generator = new PhraseGenerator(config, repo, specialCharsRepo);

            return generator.Generate();
        }
        
        /// <summary>
        /// Returns the users configured options for the plugin.
        /// </summary>
        /// <param name="strCurrentOptions">A string of previously set options.</param>
        /// <returns>A string of configured options.</returns>
        public override string GetOptions(string strCurrentOptions)
        {
            UserConfig config = UserConfig.Deserialize(strCurrentOptions);
            Options options = new Options(config);
            options.ShowDialog();
            
            return UserConfig.Serialize(config);
        }
    }
}
