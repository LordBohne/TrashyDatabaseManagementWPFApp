using System;
using System.Collections.Generic;
using System.Data;
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
            ViewModels.DatabaseViewModel databaseViewModel = new ViewModels.DatabaseViewModel("localhost", "root", "nordwind");
            this.DataContext = databaseViewModel;
            databaseViewModel.ExecuteAndSetQuery(SQLInput.Text);
        }
            
        }
    }
