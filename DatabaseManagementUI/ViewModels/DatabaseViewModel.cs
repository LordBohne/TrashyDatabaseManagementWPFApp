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
        Models.DatabaseConnector Connector { get; set; }

        object RemodeltDataTableItem
        {
            get
            {
                return this;
            }
            set
            {
                if (value == RemodeltDataTableItem)
                {
                    return;
                }
                RemodeltDataTableItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(RemodeltDataTableItem)));
            }
        }

        public DatabaseViewModel(string Servername, string Username, string Database=null, string Password=null)
        {
            Connector = new Models.DatabaseConnector(Models.DatabaseConnector.GenerateMySQLConnectionString(Servername, Username, Database, Password));
        }
        public object ExecuteAndRemodelQuery(string SQL)
        {
            var DataTable = Connector.Query(SQL).Result.AsEnumerable().ToList();
            return "";
        }
    }
}
