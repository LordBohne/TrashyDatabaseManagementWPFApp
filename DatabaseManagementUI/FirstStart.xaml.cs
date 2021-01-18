using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using DatabaseManagementUI.Properties;
using Microsoft.Win32;

namespace DatabaseManagementUI
{
    /// <summary>
    /// Interaction logic for FirstStart.xaml
    /// </summary>
    public partial class FirstStart : Window
    {
        public FirstStart()
        {
            InitializeComponent();
        }

        private void FirstStartSaveButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.ServerLocation = ServerLocationTextBox.Text;
            Settings.Default.Password = PasswordTextBox.Text;
            Settings.Default.Username = UsernameTextBox.Text;
            Settings.Default.Save();
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Settings.Default.ServerLocation != "" && Settings.Default.Username != "")
            {
                MainWindow main = new MainWindow();
                App.Current.MainWindow = main;
                this.Close();
                main.Show();
            }
        }
        private void MysqlExePathButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            Settings.Default.MysqlServerExecutableLocation = openFileDialog.FileName;
        }
    }
}
