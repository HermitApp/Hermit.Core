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
    /// 
    /// </summary>
    [Export(typeof(ISettingsItem))]    
    public abstract class SettingsItem : PropertyChangedBase, ISettingsItem
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public SettingsItem()
        {
            _DisplayName = "Settings Item";
        }

        private string _DisplayName;

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            get
            {
                return _DisplayName;
            }
            set
            {
                if(value != _DisplayName)
                {
                    _DisplayName = value;
                    NotifyOfPropertyChange(() => DisplayName);
                }
            }
        }
    }
}
