/*
 Copyright 2021 Robin Malburn

 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
using System;
using KeePass.Plugins;

namespace DicewareGenerator
{
    /// <summary>
    /// Plugin entry point class.
    /// </summary>
    public class DicewareGeneratorExt: Plugin
    {
        private IPluginHost m_host = null;
        private DicewareGenerator m_generator = null;

        public override bool Initialize(IPluginHost host)
        {
            if(host == null) 
            {
                return false;
            }
            
            m_host = host;
            m_generator = new DicewareGenerator();
            m_host.PwGeneratorPool.Add(m_generator);
            
            return true;
        }
        
        public override void Terminate()
        {
            if (m_host != null)
            {
                m_host.PwGeneratorPool.Remove(m_generator.Uuid);
                m_generator = null;
                m_host = null;
            }
        }
    }
}