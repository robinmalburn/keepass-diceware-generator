/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGenerator.Models
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using DicewareGenerator.Repositories;
    
    /// <summary>
    /// User Config Model.
    /// </summary>
    [XmlRoot("Config")]
    public class UserConfig
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserConfig"/> class.
        /// </summary>
        public UserConfig()
        {
            this.NumberOfWords = 6;
            this.StudlyCaps = false;
            this.Wordlist = DicewareFileType.Short;
            this.Separator = " ";
            this.SpecialChars = false;
        }
        
        /// <summary>
        /// Gets the <code>space</code> attribute setting for XML serialization.
        /// </summary>
        [XmlAttribute("space", Namespace = "http://www.w3.org/XML/1998/namespace")]  
        public string Space = "preserve";
        
        /// <summary>
        /// Gets or sets the number of words to be generated.
        /// </summary>
        public decimal NumberOfWords { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to upper case the first letter of each word.
        /// </summary>
        public bool StudlyCaps { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating which <see cref="DicewareFileType"/> to use.
        /// </summary>
        public DicewareFileType Wordlist { get; set; }
        
        /// <summary>
        /// Gets or sets the separator string to use.
        /// </summary>
        public string Separator { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether to mix in special characters.
        /// </summary>
        public bool SpecialChars { get; set; }
                
        /// <summary>
        /// Serialize the given <see cref="UserConfig"/>
        /// </summary>
        /// <param name="config">The Config instance.</param>
        /// <returns>A string of serialized XML.</returns>
        public static string Serialize(UserConfig config)
        {   
            var serializer = new XmlSerializer(config.GetType());
            
            using (var stream = new MemoryStream())
            {
                var settings = new XmlWriterSettings() 
                {
                    Encoding = new UTF8Encoding(false),
                    Indent = false,
                    NewLineOnAttributes = false
                };
                
                using (XmlWriter writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, config);
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }
        
        /// <summary>
        /// Deserialize an XML string into a <see cref="UserConfig"/> model
        /// </summary>
        /// <param name="raw">An XML string.</param>
        /// <returns><see cref="UserConfig"/> Model</returns>
        public static UserConfig Deserialize(string raw)
        {
            var config = new UserConfig();
            
            if (string.IsNullOrEmpty(raw))
            {
                return config;
            }
            
            var serializer = new XmlSerializer(config.GetType());
            
            using (var reader = new StringReader(raw))
            {
                try 
                {
                    return (UserConfig)serializer.Deserialize(reader);
                } 
                catch (InvalidOperationException)
                {
                    return config;
                }
            }
        }
    }
}
