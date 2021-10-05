using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using HandyControl.Controls;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl;
using QRCoder;
using System.Drawing;
using System.IO;

namespace SecureVast.Dialogs
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : HandyControl.Controls.Window
    {
        public bool BACKBTN = false;

        public Setup()
        {
            InitializeComponent();
        }

        private void Button_Prev(object sender, RoutedEventArgs e)
        {
            if (BACKBTN == false)
                this.Close();
            else
                step.Prev();
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            BACKBTN = true;
            Prev.Content = "Back";
            step.Next();
        }

        private void step_StepChanged(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            
        }
    }
}
