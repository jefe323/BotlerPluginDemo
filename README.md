BotlerPluginDemo
================

This is a demo of a potential plugin system for my C# IRC bot, Botler. This is more or less a proof of concept for learning MEF as an alternative to using basic Reflection to load DLLs dynamically at runtime.

This solution contains three projects:

### Botler.Plugin.Core

This project contains the 2 interfaces necessary for the plugin and the host to communicate effectively. The IPlugin interface isn't demo'd in the sample plugin file, but it is just used (currently) to display basic info about the plugin that the host program will display to the end user. The ICommand interface contains the necessary pieces for a command name/alias, a simple help string and a method that will allow the command to process inputted data and output a string for the IRC bot to display to the end user.

### BotlerPluginTest

This project is the host program. It finds all the necessary commands/plugins from it's own assembly and those located in the /Plugins folder. Once it has those in an IEnumerable object, it waits for commands. Once it recieves a command, the program performs a basic LINQ query to find the proper object to reference. The program then passes the user inputted data to that object and recieves the outputted string. The outputted information is then displayed to the user (along with a demo of the help information of the command).

This project also has a single internal command to test the import ability from within the assembly.

### Botler.Commands.Math

This project contains 4 sample math commands (Add, Subtract, Multiply and Divide). These commands are very basic and are used only to test that importing commands from an external DLL works. Currently this project does not have an IPlugin implementation, but I may include one later.



I wrote this while half asleep, so I apoligize if there are spelling/grammar mistakes. Feel free to look through the code and offer corrections on my first real forray into MEF and building an extensible program.


