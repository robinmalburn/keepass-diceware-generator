/*
Copyright 2021 Robin Malburn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
namespace DicewareGenerator.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DicewareGenerator.Models;
    using DicewareGenerator.Repositories;
    using KeePassLib.Security;
    
    /// <summary>
    /// Phrase generator; handles generating phrases based on the given configuration and pulled from the given repos.
    /// </summary>
    public class PhraseGenerator : IPhraseGenerator
    {
        /// <summary>
        /// Config instance.
        /// </summary>
        protected readonly Config Config;
        
        /// <summary>
        /// Diceware Repository Instance.
        /// </summary>
        protected readonly IDicewareRepository Repo;
        
        /// <summary>
        /// Diceware Special Chars Repository Instance.
        /// </summary>
        protected readonly IDicewareSpecialCharsRepository SpecialCharsRepo;
        
        /// <summary>
        /// Initializes a new instance of <see cref="PhraseGenerator"/> class.
        /// </summary>
        /// <param name="config">A config instance.</param>
        /// <param name="repository">A Diceware repository instance.</param>
        /// <param name="specialCharsRepo">A Diceware Special Chars repository instance.</param>
        public PhraseGenerator(Config config, IDicewareRepository repository, IDicewareSpecialCharsRepository specialCharsRepo)
        {
            this.Config = config;
            this.Repo = repository;
            this.SpecialCharsRepo = specialCharsRepo;
        }
        
        /// <summary>
        /// Generates a passphrase.
        /// </summary>
        /// <returns>Returns a protected string of the passphrase.</returns>
        public ProtectedString Generate()
        {
            List<string> words = this.Repo.GetRandom((int)this.Config.NumberOfWords);
            
            if (this.Config.StudlyCaps)
            {
                words = words.Select(word => word.First().ToString().ToUpper() + word.Substring(1)).ToList();
            }
            
            if (this.Config.SpecialChars)
            {
                words = words.Select(word => this.SpecialCharsRepo.Transform(word)).ToList();
            }
            
            string pwd = string.Join(this.Config.Separator, words);
            
            return new ProtectedString(false, pwd);
        }
    }
}
