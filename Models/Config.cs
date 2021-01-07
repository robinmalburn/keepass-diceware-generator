/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using DicewareGenerator.Repositories;

namespace DicewareGenerator.Models
{
    /// <summary>
    /// Config Model.
    /// </summary>
    public class Config
    {
        [XmlAttribute("space", Namespace = "http://www.w3.org/XML/1998/namespace")]  
        public string Space="preserve";
     
        public decimal NumberOfWords = 6;
        
        public bool StudlyCaps = false;
        
        public DicewareFileType Wordlist = DicewareFileType.Short;
        
        public string Separator = " ";
        
        public bool SpecialChars = false;
        
        public Config()
        {
            
        }
                
        static public string serialize(Config config)
        {   
            XmlSerializer serializer = new XmlSerializer(config.GetType());
            
            using (MemoryStream stream = new MemoryStream()) {
                
                using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings() {
                    Encoding = new UTF8Encoding(false),
                    Indent = false,
                    NewLineOnAttributes = false}
                   )
                ) {
                    serializer.Serialize(writer, config);
                    return Encoding.UTF8.GetString(stream.ToArray());
                }
            }
        }
        
        static public Config deserialize(string raw)
        {
            Config config = new Config();
            
            if (string.IsNullOrEmpty(raw)) {
                return config;
            }
            
            XmlSerializer serializer = new XmlSerializer(config.GetType());
            
            using (StringReader reader = new StringReader(raw)) {
                try {
                return (Config)serializer.Deserialize(reader);
                } catch (InvalidOperationException) {
                    return config;
                }
            }
        }
    }
}
