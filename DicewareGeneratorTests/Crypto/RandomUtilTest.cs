/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGeneratorTests.Crypto
{
    using System;
    using DicewareGenerator.Crypto;
    using KeePassLib.Cryptography;
    using NUnit.Framework;

    /// <summary>
    /// Test for the <see cref="RandomUtil" /> class.
    /// </summary>
    [TestFixture]
    public class RandomUtilTest
    {
        /// <summary>
        /// Instance of <see cref="RandomUtil"/> to test.
        /// </summary>
        private RandomUtil util;
        
        /// <summary>
        /// Sets up the test case.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            var bytes = new byte[32];
            var rnd = new Random();
            rnd.NextBytes(bytes);
            var stream = new CryptoRandomStream(CrsAlgorithm.ChaCha20, bytes);
            
            this.util = new RandomUtil(stream);
        }
        
        /// <summary>
        /// Tests that the minimum value must be greater than or equal to the maximum value.
        /// </summary>
        [Test]
        public void TestMinGreaterThanOrEqualToMaxException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.util.RandomRange(1, 1), "Assert that the minimum value must be less than the maximum.");
        }
        
        /// <summary>
        /// Tests that the maximum values must be greater than zero.
        /// </summary>
        [Test]
        public void TestMaxGreaterThanZeroException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.util.RandomRange(0), "Assert that the maximum value must be greater than zero.");
        }
        
        /// <summary>
        /// Tests that the result is within the given range.
        /// </summary>
        [Test]
        public void TestWithinRange()
        {
            const ulong Min = 0;
            const ulong Max = 2;
            
            // Take 10 samples to test that our result is within expected bounds.
            for (int i = 0; i < 10; i++)
            {
                ulong rand = this.util.RandomRange(Max, Min);
            
                Assert.GreaterOrEqual(rand, Min, "Assert that result is greater than or equal to min");
                Assert.Less(rand, Max, "Assert that result is less than max.");
            }
        }
    }
}
