using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Controls;
using DatabaseManagementUI.Models.DatabaseStructure;
namespace DatabaseManagementUI.ViewModels
{
    public class DatabaseStructureViewModel : INotifyPropertyChanged
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
        public void DatabaseTreeView(string ConnectionStringToServer,int ServerType=1)
        {
            var DatabaseStructure = new Models.DatabaseStructureMethods(ConnectionStringToServer, ServerType);
            var Databases = DatabaseStructure.GetMySQLDatabases();
            var DatabaseTreeView = new TreeView();
            foreach (var Database in Databases)
            {
                var DatabaseItem = new TreeViewItem();
                DatabaseItem.Header = Database;
                var MySQLTables = DatabaseStructure.GetMySQLTables(Database);
                foreach (string table in MySQLTables)
                {
                    var TableItem = new TreeViewItem();
                    TableItem.Header = table;
                    
                    var TableFields = DatabaseStructure.GetTableFields(table, Database);
                    foreach (var Field in TableFields)
                    {
                        var FieldItem = new TreeViewItem();
                        FieldItem.Header = Field.FieldName;
                        TableItem.Items.Add(FieldItem);
                    }
                    DatabaseItem.Items.Add(TableItem);
                }
                DatabaseTreeView.Items.Add(DatabaseItem);
            }
            DatabaseStructureTreeView = DatabaseTreeView;
        }
    }
}
