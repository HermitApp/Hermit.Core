﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace Hermit.Plugin
{
    /// <summary>
    /// Settings window
    /// </summary>
    [InheritedExport]
    public interface ISettingsItem
    {
        /// <summary>
        /// Name of item for Settings
        /// </summary>
        string Name { get; }
    }
}
