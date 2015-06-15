using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using FTPUtil;
using System.Collections.ObjectModel;

namespace FTPConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigModel _config = new ConfigModel();
        ObservableCollection<string> dirPath = null;
        public ObservableCollection<string> Path
        {
            get
            {
                return dirPath;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine(_config);

            this.DataContext = _config;


        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> param = new Dictionary<string, string>();
            param.Add("url", _config.FTPServerUrl);
            param.Add("username", _config.UserName);
            param.Add("password", _config.Password);
            param.Add("proxy", _config.ProxyUrl);
            param.Add("uploadInt", Convert.ToString(_config.UploadInterval));
            Config.saveSettings(param, _config.DirectoryPath);
        }

        private void upload_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
