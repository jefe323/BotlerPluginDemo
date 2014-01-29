
namespace Botler.Plugin.Core
{
    public interface IPlugin
    {
        /// <summary>
        /// Name of the plugin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Author of the plugin
        /// </summary>
        string Author { get;  }

        /// <summary>
        /// Plugin version
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Description of the plugin
        /// </summary>
        string Description { get; }
    }
}
