using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using System.ComponentModel.Composition;


namespace Hermit.Plugin
{
    [Export(typeof(IShell))]
    public class Shell : Screen, IShell
    {
        public Shell()
        {
            DisplayName = "Shell";
        }
    }
}
