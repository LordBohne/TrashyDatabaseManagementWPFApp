using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            var tes2t = new Models.DatabaseConnector("server=127.0.0.1;uid=root;pwd=;database=northwind");
        }

        private void test_KeyUp(object sender, KeyEventArgs e)
        {
            string test = ((TextBox)sender).Text;
            var tes2t = new Models.DatabaseConnector("server=127.0.0.1;uid=root;pwd=;database=northwind");
            tes2t.Query(test);
        }
    }
}
