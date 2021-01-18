using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DatabaseManagementUI.Properties;
using DatabaseManagementUI.Models.DatabaseStructure;
using Microsoft.Win32;
using System.IO;

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

        //private void ImportButton_Click(object sender, RoutedEventArgs e)
        //{
        //    var FileDialog = new OpenFileDialog();
        //    FileDialog.Filter = "sql files (*.sql)|*.sql";
        //    FileDialog.ShowDialog();
        //    var Connector = new Models.DatabaseConnector(Models.DatabaseConnector.GenerateMySQLConnectionString(Settings.Default.ServerLocation, Settings.Default.Username,ViewModels.SQLQueryViewModel.CurrentDatabase));
        //    var Script = File.ReadAllText(FileDialog.FileName);
        //    Connector.CreateTable(Script,";");
        //}

    }
}
