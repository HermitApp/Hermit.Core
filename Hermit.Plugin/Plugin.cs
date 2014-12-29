using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;

namespace Hermit.Plugin
{
    public class Plugin : PropertyChangedBase, IPlugin
    {
        private string _DisplayName;

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

        public Plugin()
        {
            DisplayName = "Plugin";
        }
    }
}
