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
        AggregateCatalog catalog;
        CompositionContainer container;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.Run();
        }

        [ImportMany(typeof(IPlugin), AllowRecomposition = true)]
        public IEnumerable<IPlugin> plugins { get; set; }

        [ImportMany(typeof(ICommand), AllowRecomposition = true)]
        public IEnumerable<ICommand> commands { get; set; }

        void Run()
        {
            Compose();

            Console.WriteLine("Plugins currently loaded:");
            //cycle through all the loaded IPlugin objects and display their data
            foreach (IPlugin p in plugins)
            {
                Console.WriteLine("===");
                Console.WriteLine("Plugin Name: \n\t" + p.Name);
                Console.WriteLine("Plugin Author: \n\t" + p.Author);
                Console.WriteLine("Plugin Version: \n\t" + p.Version);
                Console.WriteLine("Plugin Description: \n\t" + p.Description);
                Console.WriteLine("===\n");
            }

            Console.WriteLine("Enter a command: ");
            while (true)
            {
                string input = Console.ReadLine();
                string[] data = input.Split(' ');

                try
                {
                    //LINQ query to find the proper ICommand object
                    ICommand comm = (from c in commands
                                     where c.Command.Contains(data[0])
                                     select c).First();

                    string output = comm.DoWork(data);
                    Console.WriteLine("Help data for " + data[0] + ":\n\t" + comm.HelpText);
                    Console.WriteLine("Output: " + output);
                }
                catch (InvalidOperationException)
                {
                    //can handle rems here
                    if (input == "exit")
                    {
                        Environment.Exit(0);
                    }
                    //reload plugins. could make it automatic, but I'd rather leave reloading up to the user
                    //Note, removing a DLL file from the plugins folder and not reloading will keep the data in memory (i.e the commands the DLL provides will still be usable)
                    else if (input == "reload")
                    {
                        Reload();
                    }
                    //no valid command found
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
            catalog = new AggregateCatalog(new DirectoryCatalog(path + "/Plugins"), new AssemblyCatalog(Assembly.GetExecutingAssembly()));
            container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        void Reload()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            try
            {
                catalog.Catalogs.Clear();
                catalog.Catalogs.Add(new DirectoryCatalog(path + "/Plugins"));
                catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
                container.ComposeParts(this);

                Console.WriteLine("Reload Complete!");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
    }
}
