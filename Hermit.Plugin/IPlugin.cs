using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace Hermit.Plugin
{
    /// <summary>
    /// Interface for plugin
    /// </summary>
    [InheritedExport]
    public interface IPlugin
    {
        /// <summary>
        /// Name of plugin
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of plugin
        /// </summary>
        string Description { get; }
        
        /// <summary>
        /// Creator of plugin
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Version of plugin
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Related settings for plugin
        /// </summary>
        ISettingsItem Settings { get; }

        /// <summary>
        /// Save changes to settings
        /// </summary>
        void SaveSettings();
    }
}
