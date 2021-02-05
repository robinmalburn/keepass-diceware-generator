/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGeneratorTests.Repositories
{
    using System;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="PresentationPhraseRepository"/>.
    /// </summary>
    [TestFixture]
    public class PresentationPhraseRepositoryTest
    {
            /// <summary>
        /// Short words to be used by the repository.
        /// </summary>
        private static string[] shortWords = new string[] { "foo", "bar", "baz" };
        
        /// <summary>
        /// Long words to be used by the repository.
        /// </summary>
        private static string[] longWords = new string[] { "epiphany", "season", "richochet" };
        
        /// <summary>
        /// Instance of <see cref="UserConfig"/>.
        /// </summary>
        private UserConfig config;
        
        /// <summary>
        /// Instance of <see cref="PresentationPhraseRepository"/>.
        /// </summary>
        private IPhraseRepository repo;
    
        /// <summary>
        /// Set up the test case.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.config = new UserConfig();
            this.repo = new PresentationPhraseRepository(this.config);
        }
        
        /// <summary>
        /// Tests that an invalid range passed to Get Random results in the expected exception.
        /// </summary>
        [Test]
        public void TestInvalidRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.repo.GetRandom(0), "Assert that the count value must be greater than zero.");   
        }
        
        /// <summary>
        /// Test that the correct number of items is returned when getting a random selection.
        /// </summary>
        [Test]
        public void TestGetRandom()
        {
            const int Count = 4;
            
            var result = this.repo.GetRandom(Count);
            
            Assert.AreEqual(Count, result.Count, "Assert that the returned number of items matches expectations.");
        }
        
        /// <summary>
        /// Tests that the repository implements the expected interface.
        /// </summary>
        [Test]
        public void TestInterface()
        {
            Assert.IsInstanceOf(typeof(IPhraseRepository), this.repo, "Assert that the repository implements the expected interface.");
        }
        
        /// <summary>
        /// Tests that the repository honours the user configuration.
        /// </summary>
        /// <param name="fileType">A <see cref="DicewareFileType"/></param>
        [Test]
        [TestCase(DicewareFileType.Short)]
        [TestCase(DicewareFileType.Long)]
        public void TestUserConfig(DicewareFileType fileType)
        {
            this.config.Wordlist = fileType;
            
            var result = this.repo.GetRandom(1);
            
            var wordPool = PresentationPhraseRepositoryTest.shortWords;
            
            if (fileType == DicewareFileType.Long) {
                wordPool = PresentationPhraseRepositoryTest.longWords;
            }
            
            Assert.Contains(result[0], wordPool, "Assert that the returned result is contained in the expected word pool.");
        }
    }
}
