using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Botler.Plugin.Core;
using System.ComponentModel.Composition;

namespace Botler.Commands.Math
{
    [Export(typeof(IPlugin))]
    class Info : IPlugin
    {
        public string Name
        {
            get { return "Commands.Math"; }
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
            get { return "Basic math commands to test functionality of external DLL files"; }
        }
    }
}
