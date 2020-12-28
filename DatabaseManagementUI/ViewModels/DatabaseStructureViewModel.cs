using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DatabaseManagementUI.Models.DatabaseStructure;
namespace DatabaseManagementUI.ViewModels
{
    public class DatabaseStructureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private List<DatabaseModel> databaseStructure;
        public List<DatabaseModel> DatabaseStructure
        {
            get
            {
                return databaseStructure;
            }
            set
            {
                if (databaseStructure == value)
                    return;
                databaseStructure = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(DatabaseStructure)));
            }
        }
        public TreeView DatabaseStructureTreeView { get; set; }
        public TreeView DatabaseTreeView(string ConnectionStringToServer,int ServerType=1)
        {
            var DatabaseStructure = new Models.DatabaseStructureMethods(ConnectionStringToServer, ServerType);
            var Databases = DatabaseStructure.GetMySQLDatabases();
            var DatabaseTreeView = new TreeView();
            var TreeViewItem = new TreeViewItem();
            foreach (var Database in Databases)
            {
                TreeViewItem.Header = Database;
                DatabaseTreeView.Items.Add(TreeViewItem); // DOESNT WORK THROWS ERROR
            }
            return DatabaseTreeView;
        }
    }
}
