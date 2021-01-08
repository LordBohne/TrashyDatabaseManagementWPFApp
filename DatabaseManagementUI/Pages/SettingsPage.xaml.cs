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

namespace DatabaseManagementUI.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            if (MysqlExePathTextBox.Text != "" || MysqlExePathTextBox.Text != string.Empty || MysqlExePathTextBox != null)
            {
                Properties.Settings.Default.MysqlServerExecutableLocation = MysqlExePathTextBox.Text;
            }

            Properties.Settings.Default.Save();
        }
    }
}
