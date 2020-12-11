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

namespace DatabaseManagementUI
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

        private void ExistingDatabase_Click(object sender, RoutedEventArgs e)
        {
            SimpleDMSMainWindow.Content = new Page1();
            var tes2t = new Models.DatabaseConnector("server=127.0.0.1;uid=root;pwd=;database=northwind");;
        }

        private void test_KeyUp(object sender, KeyEventArgs e)
        {
            string test = ((TextBox)sender).Text;
            var tes2t = new Models.DatabaseConnector("server=127.0.0.1;uid=root;pwd=;database=northwind");
            tes2t.Query(test);
        }
    }
}
