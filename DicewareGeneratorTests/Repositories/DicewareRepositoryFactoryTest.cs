/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGeneratorTests.Repositories
{
    using System;
    using DicewareGenerator.Crypto;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using KeePassLib.Cryptography;
    using NUnit.Framework;

    [TestFixture]
    public class DicewareRepositoryFactoryTest
    {
        /// <summary>
        /// Instance of <see cref="RandomUtil"/>
        /// </summary>
        private RandomUtil util;
        
        /// <summary>
        /// Instance of <see cref="IDicewareRepositoryFactory"/> to test.
        /// </summary>
        private IDicewareRepositoryFactory factory;
        
        /// <summary>
        /// Instance of <see cref="UserConfig"/> to pass to factory.
        /// </summary>
        private UserConfig userConfig;
        
        [SetUp]
        public void SetUp()
        {
            var bytes = new byte[32];
            var rnd = new Random();
            rnd.NextBytes(bytes);
            var stream = new CryptoRandomStream(CrsAlgorithm.ChaCha20, bytes);
            
            this.util = new RandomUtil(stream);
            
            var sysConfig = new SystemConfig();
            sysConfig.Basepath = "../../../Resources";
            
            this.userConfig = new UserConfig();
            this.factory = new DicewareRepositoryFactory(userConfig, sysConfig);
        }
        
        /// <summary>
        /// Test making a special chars repository.
        /// </summary>
        [Test]
        public void TestMakeSpecialChars()
        {
            Assert.IsInstanceOf(typeof(IDicewareSpecialCharsRepository), this.factory.MakeSpecialChars(this.util), "Assert that an instance of the special chars repo can be made.");
        }
        
        [Test]
        [TestCase(DicewareFileType.Short, typeof(FileShortDicewareRepository))]
        [TestCase(DicewareFileType.Long, typeof(FileLongDicewareRepository))]
        public void TestMake(DicewareFileType filetype, Type repoType)
        {
            this.userConfig.Wordlist = filetype;
            var result = this.factory.Make(this.util);
            
            Assert.IsInstanceOf(repoType, result, "Assert the returned repository type matches expectations.");
        }
    }
}
