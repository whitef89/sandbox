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

namespace FTPConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ConfigModel _config = new ConfigModel();
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = _config;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(_config);
        }
    }
}
