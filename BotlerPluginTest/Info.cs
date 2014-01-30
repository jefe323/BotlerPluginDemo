using Botler.Plugin.Core;
using System.ComponentModel.Composition;

namespace BotlerPluginTest
{
    [Export(typeof(IPlugin))]
    class Info : IPlugin
    {
        public string Name
        {
            get { return "Plugins.Host"; }
        }

        public string Author
        {
            get { return "jefe323"; }
        }

        public string Version
        {
            get { return "1.0.0"; }
        }

        public string Description
        {
            get { return "The commands included with the base program"; }
        }
    }
}
