using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using Botler.Plugin.Core;
using System.IO;

namespace BotlerPluginTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        [ImportMany(typeof(IPlugin))]
        public IEnumerable<IPlugin> plugins { get; set; }

        [ImportMany(typeof(ICommand))]
        public IEnumerable<ICommand> commands { get; set; }

        void Run()
        {
            Compose();

            Console.WriteLine("Enter a command: ");
            while (true)
            {
                string input = Console.ReadLine();

                string[] data = input.Split(' ');

                try
                {
                    ICommand comm = (from c in commands
                                     where c.Command.Contains(data[0])
                                     select c).First();

                    string output = comm.DoWork(data);
                    Console.WriteLine("Help data for " + data[0] + ":\n\t\t" + comm.HelpText);
                    Console.WriteLine("Output: " + output);
                }
                catch (InvalidOperationException)
                {
                    //can handle rems here
                    if (input == "exit")
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("It was empty");
                    }
                }
                catch (Exception fail) { Console.WriteLine(fail.Message); }
            }
        }

        void Compose()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var catalog = new AggregateCatalog(new DirectoryCatalog(path + "/Plugins"), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }
    }
}
