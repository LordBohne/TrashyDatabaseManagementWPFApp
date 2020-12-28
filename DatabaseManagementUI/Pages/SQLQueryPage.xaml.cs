using System.Windows;
using System.Windows.Controls;


namespace DatabaseManagementUI.Pages
{
    /// <summary>
    /// Interaktionslogik für SQLQueryPage.xaml
    /// </summary>
    public partial class SQLQueryPage : Page
    {
        public SQLQueryPage()
        {
            InitializeComponent();
        }

        private void SendSQLButton_Click(object sender, RoutedEventArgs e)
        {
            //Models.DatabaseConnector databaseConnector = new Models.DatabaseConnector(Models.DatabaseConnector.GenerateMySQLConnectionString("localhost", "root", "nordwind"));
            //var test = databaseConnector.Query("SELECT * FROM ARTIKEL").Result;
            //ReturnedData.ItemsSource = test.DefaultView;

            //https://www.google.com/search?client=firefox-b-d&q=datagrid+bind+to+datatable
            ViewModels.SQLQueryViewModel sQLQueryViewModel = new ViewModels.SQLQueryViewModel("localhost", "root", "nordwind");
            this.DataContext = sQLQueryViewModel;
            sQLQueryViewModel.ExecuteAndSetQuery(SQLInput.Text);
        }
            
        }
    }
