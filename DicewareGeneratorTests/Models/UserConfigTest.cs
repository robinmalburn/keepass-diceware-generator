/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGeneratorTests.Models
{
    using System;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using NUnit.Framework;
    
    /// <summary>
    /// Tests for the <see cref="UserConfig"/> class.
    /// </summary>
    [TestFixture]
    public class UserConfigTest
    {
        /// <summary>
        /// The default serialized representation of the config.
        /// </summary>
        private const string DefaultSerializedConfig = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Config xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><NumberOfWords>6</NumberOfWords><StudlyCaps>false</StudlyCaps><Wordlist>Short</Wordlist><Separator> </Separator><SpecialChars>false</SpecialChars></Config>";
        
        /// <summary>
        /// Test the default values set upon constructing a new instance.
        /// </summary>
        [Test]
        public void TestDefaultConstructorValues()
        {
            var config = new UserConfig();
            
            Assert.AreEqual(6, config.NumberOfWords, "Assert that the default NumberOfWords matches expectations.");
            Assert.AreEqual(false, config.StudlyCaps, "Assert that StudlyCaps are disabled by default.");
            Assert.AreEqual(DicewareFileType.Short, config.Wordlist, "Assert that the short filetype is used by default.");
            Assert.AreEqual(" ", config.Separator, "Assert that the default Separator matches expectations.");
            Assert.AreEqual(false, config.SpecialChars, "Assert that SpecialChars are disabled by default");
        }
        
        /// <summary>
        /// Test serialization a default configuration.
        /// </summary>
        [Test]
        public void TestSerializeDefaultConfig()
        {
            var config = new UserConfig();
            Assert.AreEqual(DefaultSerializedConfig, UserConfig.Serialize(config), "Assert that serializing the given config produces the expected XML.");
        }
        
        /// <summary>
        /// Test serialization a modified configuration.
        /// </summary>
        [Test]
        public void TestSerialize()
        {
            var config = new UserConfig();
            config.NumberOfWords = 3;
            config.StudlyCaps = true;
            config.Wordlist = DicewareFileType.Long;
            config.Separator = string.Empty;
            
            const string Expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Config xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><NumberOfWords>3</NumberOfWords><StudlyCaps>true</StudlyCaps><Wordlist>Long</Wordlist><Separator /><SpecialChars>false</SpecialChars></Config>";
            Assert.AreEqual(Expected, UserConfig.Serialize(config), "Assert that serializing the given config produces the expected XML.");
        }
        
        /// <summary>
        /// Test that deserialization from an invalid source results in a default config.
        /// </summary>
        [Test]
        public void TestDeserializeInvalidSource()
        {
            var config = UserConfig.Deserialize(string.Empty);
            
            Assert.IsInstanceOf(typeof(UserConfig), config, "Assert that providing an invalid string results in a valid, default configuration.");
        }
        
        /// <summary>
        /// Test the default values set when when create an instance from an invalid deserialization source.
        /// </summary>
        [Test]
        public void TestDefaultDeserializedValues()
        {
            var config = UserConfig.Deserialize(string.Empty);
            
            Assert.AreEqual(6, config.NumberOfWords, "Assert that the default NumberOfWords matches expectations.");
            Assert.AreEqual(false, config.StudlyCaps, "Assert that StudlyCaps are disabled by default.");
            Assert.AreEqual(DicewareFileType.Short, config.Wordlist, "Assert that the short filetype is used by default.");
            Assert.AreEqual(" ", config.Separator, "Assert that the default Separator matches expectations.");
            Assert.AreEqual(false, config.SpecialChars, "Assert that SpecialChars are disabled by default");
        }
        
        /// <summary>
        /// Test that a valid XML string is deserialized to match expectations.
        /// </summary>
        [Test]
        public void TestDeserialize()
        {
            const string RawXml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><Config xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><NumberOfWords>3</NumberOfWords><StudlyCaps>true</StudlyCaps><Wordlist>Long</Wordlist><Separator /><SpecialChars>false</SpecialChars></Config>";
            var config = UserConfig.Deserialize(RawXml);
            
            Assert.IsInstanceOf(typeof(UserConfig), config, "Assert that a valid config is returned.");
            Assert.AreEqual(3, config.NumberOfWords, "Assert that the NumberOfWords matches expectations.");
            Assert.AreEqual(true, config.StudlyCaps, "Assert that StudlyCaps setting is restored as expected.");
            Assert.AreEqual(DicewareFileType.Long, config.Wordlist, "Assert that the filetype is restored as expected.");
            Assert.AreEqual(string.Empty, config.Separator, "Assert that the default Separator matches expectations.");
            Assert.AreEqual(false, config.SpecialChars, "Assert that SpecialChars retains default configration.");
        }
    }
}
