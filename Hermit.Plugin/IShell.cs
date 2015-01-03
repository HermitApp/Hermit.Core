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
    /// Interface for a Shell
    /// </summary>
    [InheritedExport]
    public interface IShell : IHaveDisplayName
    {
        /// <summary>
        /// Startup task for all shells
        /// </summary>
        /// <param name="args"></param>
        void Startup(string[] args);
    }
}
