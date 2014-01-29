using System.Collections.Generic;

namespace Botler.Plugin.Core
{
    public interface ICommand
    {
        /// <summary>
        /// List of commands that will work for the command
        /// </summary>
        List<string> Command { get; }

        /// <summary>
        /// Help documentation for the command
        /// </summary>
        string HelpText { get; }

        /// <summary>
        /// Entry point for the command
        /// </summary>
        /// <param name="data">Array containg the information recieved from the user</param>
        /// <returns>A string with the output for the user</returns>
        string DoWork(string[] data);
    }
}
