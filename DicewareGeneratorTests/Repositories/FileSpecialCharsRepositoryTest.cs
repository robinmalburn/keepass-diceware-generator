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
    using DicewareGeneratorTests.Crypto;
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="FileSpecialCharsRepository"/>.
    /// </summary>
    [TestFixture]
    public class FileSpecialCharsRepositoryTest
    {
        /// <summary>
        /// Instance of <see cref="RandomUtil"/>
        /// </summary>
        private RandomUtil util;
        
        /// <summary>
        /// Instance of <see cref="SystemConfig"/>.
        /// </summary>
        private SystemConfig sysConfig;
    
        /// <summary>
        /// Set up the test case.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.util = RandomUtilFactory.Make();
            this.sysConfig = new SystemConfig();
            this.sysConfig.Basepath = "../../../Resources";
        }
        
        /// <summary>
        /// Tests that the repository implements the expected interface.
        /// </summary>
        [Test]
        public void TestInterface()
        {
            var repo = new FileSpecialCharsRepository(this.sysConfig.GetPathForFileType(DicewareFileType.Special), DicewareIndexLength.Special, this.util);
            
            Assert.IsInstanceOf(typeof(ISpecialCharsRepository), repo, "Assert that the repository implements the expected interface.");
        }
        
        /// <summary>
        /// Test that the a given input is transformed.
        /// </summary>
        [Test]
        public void TestTransform()
        {
            const string Input = "Test";
            
            var repo = new FileSpecialCharsRepository(this.sysConfig.GetPathForFileType(DicewareFileType.Special), DicewareIndexLength.Special, this.util);
            
            var result = repo.Transform(Input);
            
            Assert.AreNotEqual(Input, result, "Assert that the result of transformation differs to the input.");
        }
    }
}
