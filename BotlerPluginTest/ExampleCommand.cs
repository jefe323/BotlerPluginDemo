using System.Collections.Generic;
using Botler.Plugin.Core;
using System.ComponentModel.Composition;

namespace BotlerPluginTest
{
    [Export(typeof(ICommand))]
    class ExampleCommand : ICommand
    {
        public List<string> Command
        {
            get { return new List<string>() { "test" }; }
        }
        public string HelpText
        {
            get { return "This is a sample help doc for the Example Command"; }
        }

        public string DoWork(string[] data)
        {
            return "Returned some work, fill in later";
        }
    }
}
