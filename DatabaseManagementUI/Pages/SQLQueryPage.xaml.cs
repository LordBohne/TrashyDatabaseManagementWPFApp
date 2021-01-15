using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using DatabaseManagementUI.Properties;

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
            //https://www.google.com/search?client=firefox-b-d&q=datagrid+bind+to+datatable
            ViewModels.SQLQueryViewModel sQLQueryViewModel = new ViewModels.SQLQueryViewModel(Settings.Default.ServerLocation, Settings.Default.Username, $"{ViewModels.SQLQueryViewModel.CurrentDatabase}", Settings.Default.Password);
            this.DataContext = sQLQueryViewModel;
            sQLQueryViewModel.ExecuteAndSetQuery(SQLInput.Text);
        }
            
        }
    }
