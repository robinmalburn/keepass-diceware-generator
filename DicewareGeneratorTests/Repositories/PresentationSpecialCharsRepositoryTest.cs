/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGeneratorTests.Repositories
{
    using System;
    using DicewareGenerator.Repositories;
    using NUnit.Framework;

    /// <summary>
    /// Tests the <see cref="PresentationSpecialCharsRepository"/>.
    /// </summary>
    [TestFixture]
    public class PresentationSpecialCharsRepositoryTest
    {
        /// <summary>
        /// The special characters to use.
        /// </summary>
        private static char[] specialChars = "~!#$%^&*()-=+[]\\{}:;\"'<>?/022345678".ToCharArray();
        
        /// <summary>
        /// Tests that the repository implements the expected interface.
        /// </summary>
        [Test]
        public void TestInterface()
        {
            var repo = new PresentationSpecialCharsRepository();
            
            Assert.IsInstanceOf(typeof(ISpecialCharsRepository), repo, "Assert that the repository implements the expected interface.");
        }
        
        /// <summary>
        /// Test that the a given input is transformed.
        /// </summary>
        [Test]
        public void TestTransform()
        {
            const string Input = "Test";
            
            var repo = new PresentationSpecialCharsRepository();
            
            var result = repo.Transform(Input);
            
            Assert.AreNotEqual(Input, result, "Assert that the result of transformation differs to the input.");
            
            Assert.Greater(result.IndexOfAny(PresentationSpecialCharsRepositoryTest.specialChars), -1, "Assert that any of the special characters can be found in the transformed string.");
        }
    }
}
