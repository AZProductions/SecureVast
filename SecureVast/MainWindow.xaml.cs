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
using System.Windows.Shell;
using WSH = IWshRuntimeLibrary;
using System.Diagnostics;
//using HandyControl.Properties.Langs;
using Lang = SecureVast.Translation;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using MessageBox = HandyControl.Controls.MessageBox;

namespace SecureVast
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : HandyControl.Controls.Window
    {
        public static string LocalURI = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"/SecureVast/";
        public static string LocalURI_JMP = LocalURI + "JMP.dll";
        public static string Env_StartMenu = Environment.GetFolderPath(Environment.SpecialFolder.StartMenu);

        public MainWindow()
        {
            InitializeComponent();
            InitializeLocalURI();
            InitializeJumpList();
            menuVersionString.Header = "V" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            SDM_Custom.Focus();
            DetectAndConvertFR();
        }

        private void DetectAndConvertFR() 
        {
            if (Properties.Settings.Default.FR)
            {
                Properties.Settings.Default.FR = false;
                Dialogs.Setup win = new Dialogs.Setup();
                win.ShowDialog();
                Properties.Settings.Default.FR = false;
                Properties.Settings.Default.Save();
            }
        }

        private void InitializeLocalURI()
        {
            Directory.CreateDirectory(LocalURI);
            if (!File.Exists(LocalURI_JMP))
            {
                File.WriteAllBytes(LocalURI_JMP, Properties.Resources.JumpList); 
            }
        }

        private void InitializeJumpList() 
        {
            JumpList jumpList = new JumpList();
            jumpList.ShowRecentCategory = true;
            jumpList.ShowFrequentCategory = true;
            ApplyJMPTasks("Hashing", "Get the hashes from files in a matter of seconds.", 3, LocalURI_JMP, "Tasks", "", "");
            ApplyJMPTasks("QR Codes", "Generate QR Codes with custom data, design and more.", 2, LocalURI_JMP, "Tasks", "", "");
            ApplyJMPTasks("Passwords", "Generate secure passwords using the SecureVast SDK.", 5, LocalURI_JMP, "Tasks", "", "");
            ApplyJMPTasks("Preferences", "Open settings.", 4, LocalURI_JMP, "Tasks", "", "");
            ApplyJMPTasks("Scan (VT)", "Scans file using VirusTotal.", 0, LocalURI_JMP, "Actions", "", "");
            ApplyJMPTasks("Scan (SV)", "Scans file using 'SecureVast Analytics and Diagnostics'.", 0, LocalURI_JMP, "Actions", "", "");
            ApplyJMPTasks("Help", "Opens the Help webiste.", 1, LocalURI_JMP, "Actions", "", "");
            void ApplyJMPTasks(string name, string description, int index, string resx, string category, string path, string args) 
            {
                JumpTask jumpTask = new JumpTask();
                jumpTask.IconResourcePath = resx;
                jumpTask.Title = name;
                jumpTask.IconResourceIndex = index;
                jumpTask.Description = description;
                jumpTask.Arguments = args;
                jumpTask.ApplicationPath = path;
                jumpTask.CustomCategory = category;
                jumpList.JumpItems.Add(jumpTask);
            }
            jumpList.Apply();
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
            HandyControl.Controls.MessageBox.Show(Properties.Lang.about); //Testing Localization features.
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
            /*WSH.WshShell wsh = new WSH.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = wsh.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\SecureVast.lnk") as IWshRuntimeLibrary.IWshShortcut;
            shortcut.Arguments = "";
            shortcut.TargetPath = Process.GetCurrentProcess().MainModule.FileName;
            // not sure about what this is for
            shortcut.WindowStyle = 1;
            shortcut.Description = "Hashing, Encryption, Password Generation tool.";
            shortcut.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            shortcut.IconLocation = LocalURI_JMP;
            shortcut.Save();*/ //Creates shortcut on desktop.
            Dialogs.Compare compare = new Dialogs.Compare();
            compare.ShowDialog();
        }

        private void lvdock_Drop(object sender, DragEventArgs e)
        {
            List<string> HandledFilesInDrop = new List<string>();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                PlaceHolder.Visibility = Visibility.Hidden;
                lv.Visibility = Visibility.Visible;
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files) 
                {
                    if (!HandledFilesInDrop.Contains(file))
                    {
                        FileInfo fi = new FileInfo(file);
                        HandledFilesInDrop.Add(file);
                        FileDropInfo fileDrop = new FileDropInfo() { Name = fi.Name, Extension = fi.Extension, Path = fi.FullName };
                        lv.Items.Add(fileDrop);
                    }
                }
            }
        }

        private void lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                List<FileDropInfo> fileDropInfos = new List<FileDropInfo>();
                FileDropInfo file = (FileDropInfo)lv.SelectedItem;
                if (file == null) { }
                else
                    testlabel.Content = "Name: " + file.Name;
            }
            catch { /*null*/ }
        }

        private void lvdock_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }

        private void cmsRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lv.Items.Remove(lv.SelectedItem); //Remove Selected Item.
            try
            {
                MenuItem mi = (MenuItem)this.FindResource("cmsRemoveItem"); //Reference cmsRemoveItem.
                if (lv.Items.Count == 1)
                    mi.IsEnabled = false;
                else
                    mi.IsEnabled = true;
            }
            catch { /*null*/ }
        }

        private void cmsAddItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Add Files - SecureVast";
            if (openFileDialog.ShowDialog() == true) 
            {
                foreach (string file in openFileDialog.FileNames) 
                {
                    FileInfo fi = new FileInfo(file);
                    FileDropInfo fileDrop = new FileDropInfo() { Name = fi.Name, Extension = fi.Extension, Path = fi.FullName };
                    lv.Items.Add(fileDrop);
                }
            }
        }

        private void cmsImportFolderItem_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == true) 
            {
                string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                foreach (string file in files) 
                {
                    FileInfo fi = new FileInfo(file);
                    FileDropInfo fileDrop = new FileDropInfo() { Name = fi.Name, Extension = fi.Extension, Path = fi.FullName };
                    lv.Items.Add(fileDrop);
                }
            }
        }

        private void cmsRemoveItems_Click(object sender, RoutedEventArgs e)
        {
            lv.Items.Clear();
        }

        private void NotifyGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //NotifyIcon is Loaded.
        }
    }

    public class FileDropInfo
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public string Path { get; set; }
    }
}
