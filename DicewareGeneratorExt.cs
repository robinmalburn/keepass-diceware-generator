/*
 Copyright 2021 Robin Malburn

 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace DicewareGenerator
{
    using System;
    using KeePass.Plugins;

    /// <summary>
    /// Plugin entry point class.
    /// </summary>
    public class DicewareGeneratorExt: Plugin
    {
        /// <summary>
        /// Plugin host container.
        /// </summary>
        private IPluginHost host = null;
        
        /// <summary>
        /// Password generator instance.
        /// </summary>
        private DicewarePwGenerator generator = null;

        /// <summary>
        /// The <c>Initialize</c> method is called by KeePass when
        /// you should initialize your plugin.
        /// </summary>
        /// <param name="host">Plugin host interface. Through this
        /// interface you can access the KeePass main window, the
        /// currently open database, etc.</param>
        /// <returns>You must return <c>true</c> in order to signal
        /// successful initialization. If you return <c>false</c>,
        /// KeePass unloads your plugin (without calling the
        /// <c>Terminate</c> method of your plugin).</returns>
        public override bool Initialize(IPluginHost host)
        {
            if (host == null) 
            {
                return false;
            }
            
            this.host = host;
            this.generator = new DicewarePwGenerator();
            this.host.PwGeneratorPool.Add(this.generator);
            
            return true;
        }
        
         /// <summary>
        /// The <c>Terminate</c> method is called by KeePass when
        /// you should free all resources, close files/streams,
        /// remove event handlers, etc.
        /// </summary>
        public override void Terminate()
        {
            if (this.host != null)
            {
                this.host.PwGeneratorPool.Remove(this.generator.Uuid);
                this.generator = null;
                this.host = null;
            }
        }
    }
}