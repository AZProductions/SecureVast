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
using System.Threading;

namespace SecureVast.Dialogs
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : HandyControl.Controls.Window
    {
        public int STAGE = 0;
        public int MAX_STAGE;
        public string[] CONTENT_LABEL = { "Exit", "Back", "Back", "Back" };

        public Setup()
        {
            InitializeComponent();
        }

        private void stepBar_StepChanged(object sender, HandyControl.Data.FunctionEventArgs<int> e)
        {
            STAGE++;
            if (STAGE >= 1) 
            {
                STAGE = stepBar.StepIndex;
                actionBack.Content = CONTENT_LABEL[STAGE];
            }
        }

        private void ShowDialog(string input)
        {
            HandyControl.Controls.MessageBox.Show(input, "Debug");
        }

        private void actionBack_Click(object sender, RoutedEventArgs e)
        {
            if (stepBar.StepIndex+1 == 1)
                this.Close();
            else
                stepBar.Prev();
        }

        private void actionNext_Click(object sender, RoutedEventArgs e)
        {
            stepBar.Next();
        }
    }
}
