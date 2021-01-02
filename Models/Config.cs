/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using System.IO;
using System.Collections.Generic;

namespace DicewareGenerator.Models
{
    /// <summary>
    /// Config Model.
    /// </summary>
    public class Config
    {
        const string SIGNATURE = "diceware_config_format:0.2.0";
        
        public decimal NumberOfWords = 6;
        
        public bool StudlyCaps = false;
        
        public Config()
        {
            
        }
                
        static public string serialize(Config config)
        {   
            string[] values = {
                Config.SIGNATURE,
                string.Format("NumberOfWords:{0}", config.NumberOfWords),
                string.Format("StudlyCaps:{0}", config.StudlyCaps ? "1" : "0")
            };
            
            return string.Join(Environment.NewLine, values);
        }
        
        static public Config deserialize(string raw)
        {
            Config config = new Config();
            
            if (string.IsNullOrEmpty(raw) || raw.StartsWith(Config.SIGNATURE, StringComparison.Ordinal) == false) {
                return config;
            }
            
            using(StringReader reader = new StringReader(raw)) {
                string line;
                char[] separator = { ':' };
                Dictionary<string, string> values = new Dictionary<string, string>();
                
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = line.Split(separator, 2);
                    values.Add(parts[0], parts[1]);
                }
                
                foreach (string key in values.Keys) {
                    switch (key) {
                        case "NumberOfWords":
                            decimal.TryParse(values[key], out config.NumberOfWords);
                            break;
                        case "StudlyCaps":
                            config.StudlyCaps = values[key] == "1";
                            break;
                    }
                }
            }
            
            return config;
        }
    }
}
