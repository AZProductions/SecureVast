using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Controls;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl;
using QRCoder;
using System.Drawing;
using System.IO;

namespace SecureVast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            menuVersionString.Header = "V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void resetThemeSkin() 
        {
            if (Theme.GetSkin(this) == HandyControl.Data.SkinType.Dark)
                ((App)App.Current).UpdateSkin(HandyControl.Data.SkinType.Dark);
            else
                ((App)App.Current).UpdateSkin(HandyControl.Data.SkinType.Default);
        }

        private void menuThemeLight_Checked(object sender, RoutedEventArgs e)
        {
            menuThemeDark.IsChecked = false;
            Theme.SetSkin(this, HandyControl.Data.SkinType.Violet);
            resetThemeSkin();
        }

        private void menuThemeDark_Checked(object sender, RoutedEventArgs e)
        {
            menuThemeLight.IsChecked = false;
            Theme.SetSkin(this, HandyControl.Data.SkinType.Dark);
            resetThemeSkin();
        }

        private void menuThemeLight_Unchecked(object sender, RoutedEventArgs e)
        {
            menuThemeDark.IsChecked = true;
        }

        private void menuThemeDark_Unchecked(object sender, RoutedEventArgs e)
        {
            menuThemeLight.IsChecked = true;
        }

        private void menuCompare_Click(object sender, RoutedEventArgs e)
        {
            HandyControl.Controls.MessageBox.Show("A new version has been detected! Do you want to update?", "Test", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }

        private void tb_TextChanged(object sender, TextChangedEventArgs e)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(tb.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            img.Source = BitmapToImageSource(qrCodeImage);
            
        }
        private BitmapImage BitmapToImageSource(System.Drawing.Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            Dialogs.Setup win = new Dialogs.Setup();
            win.ShowDialog();
        }
    }
}
