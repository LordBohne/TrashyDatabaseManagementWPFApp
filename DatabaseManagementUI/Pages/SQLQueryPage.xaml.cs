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
            Models.DatabaseConnector databaseConnector = new Models.DatabaseConnector(Models.DatabaseConnector.GenerateMySQLConnectionString("localhost", "root", "nordwind"));
            //ViewModels.DatabaseViewModel databaseViewModel = new ViewModels.DatabaseViewModel("localhost", "root", "nordwind");
            //databaseViewModel.ExecuteAndRemodelQuery("SELECT * FROM ARTIKEL");

            DataGridTextColumn textColumn = new DataGridTextColumn();
            textColumn.Header = "First Name";
            ReturnedData.Columns.Add(textColumn);
            ReturnedData.Items.Add("test");
            ReturnedData.Items.Insert(1, "test");
            //ReturnedData.Items.Add(new MyClass { test = databaseConnector.Query(SQLInput.Text).Result.AsEnumerable() });
            //MessageBox.Show("yay");
        }
        class MyClass
        {
            public IEnumerable<object> test { get; set; }
        }
    }
}
