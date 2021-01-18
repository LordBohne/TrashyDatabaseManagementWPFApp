using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DatabaseManagementUI.Properties;
using DatabaseManagementUI.Models.DatabaseStructure;
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
            var TreeView = new ViewModels.MainWindowViewModel();
            TreeView.DatabaseModelConverter(Models.DatabaseConnector.GenerateMySQLConnectionString(Settings.Default.ServerLocation, Settings.Default.Username,Password:Settings.Default.Password));
            this.DataContext = TreeView;
            
        }

        private void SQLQueryPageButton_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Pages.SQLQueryPage();
        }

        private void DatabaseStructureTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var test = (TreeView)sender;
            if (test.SelectedItem is DatabaseModel)
            {
                var test2 = (Models.DatabaseStructure.DatabaseModel)test.SelectedItem;
                ViewModels.SQLQueryViewModel.CurrentDatabase = test2.DatabaseName;
            }
            else if (test.SelectedItem is TableModel)
            {
                var test2 = (Models.DatabaseStructure.TableModel)test.SelectedItem;
                ViewModels.SQLQueryViewModel.CurrentDatabase = test2.DatabaseName;
            }
            else if(test.SelectedItem is FieldModel)
            {
                var test2 = (Models.DatabaseStructure.FieldModel)test.SelectedItem;
                ViewModels.SQLQueryViewModel.CurrentDatabase = test2.DatabaseName;
            }
            
        }

        private void SettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            Page.Content = new Pages.SettingsPage();
        }

        private void SimpleDMSMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.WindowHeight = this.ActualHeight;
            Settings.Default.WindowWidth = this.ActualWidth;
        }

        //private void ExistingDatabase_Click(object sender, RoutedEventArgs e)
        //{
        //    SimpleDMSMainWindow.Content = new Page1();
        //    var tes2t = new Models.DatabaseConnector("server=127.0.0.1;uid=root;pwd=;database=nordwind");
        //    var test = tes2t.Query("SELECT * FROM Artikel WHERE `Artikel-Nr` = 1").Result;
        //    tes2t.GetMySQLDatabases();
        //}
    }
}
