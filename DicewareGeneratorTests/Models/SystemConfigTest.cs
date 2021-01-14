/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGeneratorTests.Models
{
    using System;
    using System.IO;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using NUnit.Framework;

    [TestFixture]
    public class SystemConfigTest
    {
        /// <summary>
        /// Test that default values are set as expected.
        /// </summary>
        [Test]
        public void TestDefaultValues()
        {
            var sysConfig = new SystemConfig();
            var expected = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            
            Assert.AreEqual(expected, sysConfig.Basepath, "Assert that the basepath defaults to the assembly codebase.");
        }
        
        /// <summary>
        /// Tests getting the path for a given filetype.
        /// </summary>
        [Test]
        public void TestGetPathForFileType()
        {
            var sysConfig = new SystemConfig();
            sysConfig.Basepath = "../../../Resources";
            var expected = Path.GetFullPath("../../../Resources/special_chars.txt");
            
            Assert.AreEqual(expected, sysConfig.GetPathForFileType(DicewareFileType.Special), "Assert that the expected path for a given filetype is returned.");
        }
    }
}
