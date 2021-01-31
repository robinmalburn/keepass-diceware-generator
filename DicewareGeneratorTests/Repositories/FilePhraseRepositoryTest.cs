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

    [TestFixture]
    public class FilePhraseRepositoryTest
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
        /// Tests that an invalid range passed to Get Random results in the expected exception.
        /// </summary>
        /// <param name="fileType">A <see cref="DicewareFileType"/></param>
        /// <param name="index">A <see cref="DicewareIndexLength"/></param>
        [Test]
        [TestCase(DicewareFileType.Short, DicewareIndexLength.Short)]
        [TestCase(DicewareFileType.Long, DicewareIndexLength.Long)]
        public void TestInvalidRange(DicewareFileType fileType, DicewareIndexLength index)
        {
            var repo = new FilePhraseRepository(this.sysConfig.GetPathForFileType(fileType), index, this.util);
            
            Assert.Throws<ArgumentOutOfRangeException>(() => repo.GetRandom(0), "Assert that the count value must be greater than zero.");   
        }
        
        /// <summary>
        /// Test that the correct number of items is returned when getting a random selection.
        /// </summary>
        /// <param name="fileType">A <see cref="DicewareFileType"/></param>
        /// <param name="index">A <see cref="DicewareIndexLength"/></param>
        /// <param name="count">The number of items to retrieve.</param>
        [Test]
        [TestCase(DicewareFileType.Short, DicewareIndexLength.Short, 3)]
        [TestCase(DicewareFileType.Long, DicewareIndexLength.Long, 2)]
        public void TestGetRandom(DicewareFileType fileType, DicewareIndexLength index, int count)
        {
            var repo = new FilePhraseRepository(this.sysConfig.GetPathForFileType(fileType), index, this.util);
            
            var result = repo.GetRandom(count);
            
            Assert.AreEqual(count, result.Count, "Assert that the returned number of items matches expectations.");
        }
    }
}
