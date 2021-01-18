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
using Microsoft.Win32;

namespace DatabaseManagementUI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        
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
            try
            {
                if (Settings.Default.MysqlServerExecutableLocation != "")
                {
                    Models.ProcessUtil.ProcessStart(@Settings.Default.MysqlServerExecutableLocation);
                }
            }
            catch (Win32Exception e)
            {
                MessageBox.Show("The application couldn't start the mysql server. Please navigate to the executable of the mysql server");
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("The application couldn't start the mysql server. Please navigate to the executable of the mysql server");
            }
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
                    Tables = new List<TableModel>()
                };
                var MySQLTables = DatabaseStructure.GetMySQLTables(Database);
                foreach (string table in MySQLTables)
                {
                    var TableItem = new TableModel(DatabaseItem)
                    {
                        TableName = table,
                        TableFields = new List<FieldModel>()
                    };

                    var TableFields = DatabaseStructure.GetTableFields(TableItem,table, Database);
                    TableItem.TableFields = TableFields;
                    DatabaseItem.Tables.Add(TableItem);
                }
                databases.Add(DatabaseItem);
            }
            DatabaseStructuree = databases;
        }
    }
}
