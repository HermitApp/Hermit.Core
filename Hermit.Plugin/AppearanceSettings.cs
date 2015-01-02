using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro;
using System.Windows.Input;
using System.Windows.Media;
using Hermit.Plugin.Commands;
using System.ComponentModel.Composition;
using System.Windows;
using Caliburn.Micro;

namespace Hermit.Plugin
{
    /// <summary>
    /// Gives user access to the window appearance
    /// </summary>
    public class AppearanceSettings : PropertyChangedBase
    {
        private List<AccentColorData> _AccentColors;

        private List<ThemeColorData> _ThemeColors;

        /// <summary>
        /// List of all accent colors supported by MahApps.Metro
        /// </summary>
        public List<AccentColorData> AccentColors
        {
            get { return _AccentColors; }
            set
            {
                if (value != _AccentColors)
                {
                    _AccentColors = value;
                    NotifyOfPropertyChange(() => AccentColors);
                }
            }
        }

        /// <summary>
        /// Theme options for window
        /// </summary>
        public List<ThemeColorData> ThemeColors
        {
            get { return _ThemeColors; }
            set
            {
                if (value != _ThemeColors)
                {
                    _ThemeColors = value;
                    NotifyOfPropertyChange(() => ThemeColors);
                }
            }
        }

        /// <summary>
        /// Change the theme to the Dark Theme
        /// </summary>
        public void SetThemeDark()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, theme.Item1);
        }

        /// <summary>
        /// Change the theme to the Light Theme
        /// </summary>
        public void SetThemeLight()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, theme.Item1);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class ColorData
    {
        /// <summary>
        /// Name of color
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Color of border
        /// </summary>
        public Brush BorderColorBrush { get; set; }

        /// <summary>
        /// Color of color...
        /// </summary>
        public Brush ColorBrush { get; set; }

        private ICommand _ChangeColorCommand;

        /// <summary>
        /// Command to change color
        /// </summary>
        public ICommand ChangeColorCommand
        {
            get
            {
                return this._ChangeColorCommand ?? (_ChangeColorCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.DoChangeColor(x) });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        public virtual void DoChangeColor(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }

        
    }

    /// <summary>
    /// 
    /// </summary>
    public class AccentColorData : ColorData
    {

    }

    /// <summary>
    /// 
    /// </summary>
    public class ThemeColorData : ColorData
    {
        public override void DoChangeColor(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }
}
