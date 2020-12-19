using System.Data;
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
            var tes2t = new Models.DatabaseConnector("server=127.0.0.1;uid=root;pwd=;database=nordwind");
            var test = tes2t.Query("SELECT * FROM Artikel").Result;
            tes2t.GetMySQLDatabases();
        }
    }
}
