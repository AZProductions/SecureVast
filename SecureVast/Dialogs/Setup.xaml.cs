using System.Windows;

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
            if (stepBar.StepIndex + 1 == 1)
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
