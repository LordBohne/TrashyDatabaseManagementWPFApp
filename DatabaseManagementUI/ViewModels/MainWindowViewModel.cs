using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DatabaseManagementUI.Models.DatabaseStructure;
using DatabaseManagementUI.Properties;
namespace DatabaseManagementUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        private TreeView databaseStructureTreeView;
        public TreeView DatabaseStructureTreeView
        {
            get
            {
                return databaseStructureTreeView;
            }
            set
            {
                if (value == databaseStructureTreeView)
                    return;
                databaseStructureTreeView = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(DatabaseStructureTreeView)));
            }
        }
        private ObservableCollection<DatabaseModel> databaseStructuree;
        public ObservableCollection<DatabaseModel> DatabaseStructuree
        {
            get
            {
                return databaseStructuree;
            }
            set
            {
                if (value == databaseStructuree)
                    return;
                databaseStructuree = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(DatabaseStructuree)));
            }
        }

        public MainWindowViewModel()
        {
            Models.SQL.ProcessStart(@Settings.Default.MysqlServerExecutableLocation); // TODO: Add the ConfigHandler property responsible for this here / Make it dynamic
        }
        public void DatabaseModelConverter(string ConnectionStringToServer,int ServerType = 1)
        {
            var DatabaseStructure = new Models.DatabaseStructureMethods(ConnectionStringToServer, ServerType);
            var MySQLDatabases = DatabaseStructure.GetMySQLDatabases();
            ObservableCollection<DatabaseModel> databases = new ObservableCollection<DatabaseModel>();
            foreach (var Database in MySQLDatabases)
            {
                var DatabaseItem = new DatabaseModel
                {
                    DatabaseName = Database,
                    Tables = new List<DataTableModel>()
                };
                var MySQLTables = DatabaseStructure.GetMySQLTables(Database);
                foreach (string table in MySQLTables)
                {
                    var TableItem = new DataTableModel
                    {
                        TableName = table,
                        TableFields = new List<DataFieldModel>()
                    };

                    var TableFields = DatabaseStructure.GetTableFields(table, Database);
                    TableItem.TableFields = TableFields;
                    DatabaseItem.Tables.Add(TableItem);
                }
                databases.Add(DatabaseItem);
            }
            DatabaseStructuree = databases;
        }
    }
}
