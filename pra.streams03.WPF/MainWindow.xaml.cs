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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace pra.streams03.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnKnownFolders_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            lstDisplay.Items.Add("Applicatiemap (1) = " + Environment.CurrentDirectory);
            lstDisplay.Items.Add("Applicatiemap (2) = " + System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            lstDisplay.Items.Add("Mijn documenten = " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            lstDisplay.Items.Add("Mijn bureaublad = " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            lstDisplay.Items.Add("Startmenu = " + Environment.GetFolderPath(Environment.SpecialFolder.StartMenu));
        }

        private void btnWindowsFolders_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();
            DirectoryInfo directoryInfo = new DirectoryInfo(@"c:\windows");
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                lstDisplay.Items.Add(dir.Name);
            }
        }

        private void btnCreateFolder_Click(object sender, RoutedEventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(folder + "\\nieuwemap"))
                Directory.CreateDirectory(folder + "\\nieuwemap");
        }

        private void btnWindowsFiles_Click(object sender, RoutedEventArgs e)
        {
            lstDisplay.Items.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"c:\windows");
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                lstDisplay.Items.Add(fileInfo.Name + " " + fileInfo.Length.ToString("#,##0") + " Byte");
            }
        }

        private void btnNewFile_Click(object sender, RoutedEventArgs e)
        {
            string map = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\nieuwemap";
            if (!Directory.Exists(map))
                Directory.CreateDirectory(map);
            if (!File.Exists(map + "\\test.txt"))
                File.Create(map + "\\test.txt");
        }
    }
}
