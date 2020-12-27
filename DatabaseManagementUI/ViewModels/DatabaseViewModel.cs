using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManagementUI;
namespace DatabaseManagementUI.ViewModels
{
    public class DatabaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public Models.DatabaseConnector Connector { get; set; }

        private DataView dataTableView;
        public DataView DataTableView
        {
            get
            {
                return dataTableView;
            }
            set
            {
                if (value == dataTableView)
                {
                    return;
                }
                dataTableView = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(DataTableView)));
            }
        }

        public DatabaseViewModel(string Servername, string Username, string Database=null, string Password=null)
        {
            Connector = new Models.DatabaseConnector(Models.DatabaseConnector.GenerateMySQLConnectionString(Servername, Username, Database, Password));
        }
        public void ExecuteAndSetQuery(string SQL)
        {
            DataTableView = Connector.Query(SQL).Result.DefaultView;
        }
    }
}
