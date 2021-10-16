using HandyControl.Data;
using HandyControl.Themes;
using HandyControl.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SecureVast
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        internal void UpdateSkin(SkinType skin)
        {
            SharedResourceDictionary.SharedDictionaries.Clear();
            Resources.MergedDictionaries.Add(ResourceHelper.GetSkin(skin));
            Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/HandyControl;component/Themes/Theme.xaml")
            });
            Current.MainWindow?.OnApplyTemplate();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                
            }
        }
    }
}
