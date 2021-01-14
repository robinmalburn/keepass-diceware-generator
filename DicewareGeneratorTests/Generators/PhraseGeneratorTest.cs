/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGeneratorTests.Generators
{
    using System;
    using DicewareGenerator.Generators;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using DicewareGeneratorTests.Repositories;
    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="PhraseGenerator"/> class.
    /// </summary>
    [TestFixture]
    public class PhraseGeneratorTest
    {
        /// <summary>
        /// <see cref="Config"/> model instance.
        /// </summary>
        private UserConfig config;
        
        /// <summary>
        /// Stub special character repository.
        /// </summary>
        private ISpecialCharsRepository specialCharsRepo;

        /// <summary>
        /// Stub phrase repository.
        /// </summary>
        private IPhraseRepository repo;
        
        /// <summary>
        /// Sets up the test case.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.config = new UserConfig();
            this.repo = new StubDicewareRepository();
            this.specialCharsRepo = new StubSpecialCharsRepository();
        }
        
        /// <summary>
        /// Tests generating a pass phrase.
        /// </summary>
        [Test]
        public void TestGenerate()
        {
            var generator = new PhraseGenerator(this.config, this.repo, this.specialCharsRepo);
            
            Assert.AreEqual("foo foo foo foo foo foo", generator.Generate().ReadString(), "Assert that the generated password matches expectations.");
        }
    }
}
