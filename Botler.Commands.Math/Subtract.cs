using System.Collections.Generic;
using Botler.Plugin.Core;
using System.ComponentModel.Composition;
using System;

namespace Botler.Commands.Math
{
    [Export(typeof(ICommand))]
    class Subtract : ICommand
    {
        public List<string> Command
        {
            get { return new List<string>() { "sub", "s" }; }
        }
        public string HelpText
        {
            get { return "This is the help information for 'sub'"; }
        }

        public string DoWork(string[] data)
        {
            try
            {
                int a = Convert.ToInt32(data[1]);
                int b = Convert.ToInt32(data[2]);
                int result = a - b;
                return result.ToString();
            }
            catch { return "There was an error :("; }
        }
    }
}
