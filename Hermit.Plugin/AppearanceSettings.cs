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
    public class AppearanceSettings : PropertyChangedBase
    {
        private List<AccentColorData> accentColors;

        private List<ThemeColorData> themeColors;

        /// <summary>
        /// List of all accent colors supported by MahApps.Metro
        /// </summary>
        public List<AccentColorData> AccentColors
        {
            get { return accentColors; }
            set
            {
                if (value != accentColors)
                {
                    accentColors = value;
                    NotifyOfPropertyChange(() => AccentColors);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ThemeColorData> ThemeColors
        {
            get { return themeColors; }
            set
            {
                if (value != themeColors)
                {
                    themeColors = value;
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

    public abstract class ColorData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeColorCommand;

        public ICommand ChangeColorCommand
        {
            get
            {
                return this.changeColorCommand ?? (changeColorCommand = new SimpleCommand { CanExecuteDelegate = x => true, ExecuteDelegate = x => this.DoChangeColor(x) });
            }
        }

        public virtual void DoChangeColor(object sender)
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }

        
    }

    public class AccentColorData : ColorData
    {

    }

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
