using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using DatabaseManagementUI.Models.DatabaseStructure;
using System.Windows;

namespace DatabaseManagementUI.Models
{
    public class DatabaseStructureMethods
    {
        public MySqlConnection MySqlConn { get; set; }

        /// <summary>
        /// Initializes a new instance of the DatabaseStructureMethods Class
        /// </summary>
        /// <param name="ConnectionStringToServer">The Connection string to the server itself not to a specific database</param>
        /// <param name="ServerType">The Type of server used
        /// 1 for MYSQL
        /// 2 for SQL Server
        /// </param>
        public DatabaseStructureMethods(string ConnectionStringToServer,int ServerType=1)
        {
            switch (ServerType)
            {
                case 1:
                    MySqlConn = new MySqlConnection(ConnectionStringToServer);
                    try
                    {
                        MySqlConn.Open();
                    }
                    catch (MySql.Data.MySqlClient.MySqlException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    
                    break;
                default:
                    break;
            }
        }
        ~DatabaseStructureMethods()
        {
            MySqlConn.Close();
        }
        public List<string> GetMySQLDatabases()
        {
            //MySqlConn = new MySqlConnection(ConnectionString);
            //MySqlConn.Open();
            var sqlCommand = new MySqlCommand("SHOW DATABASES", MySqlConn);
            var Databases = new List<string>();
            MySqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                Databases.Add((string)rdr[0]);
            }
            //MySqlConn.Close();
            rdr.Close();
            return Databases;
        }

        public List<string> GetMySQLTables(string DatabaseName)
        {
            List<string> Tables = new List<string>();
            //MySqlConn = new MySqlConnection(GenerateMySQLConnectionString("localhost", "root", DatabaseName)); // TODO: Make it dynamic
            //MySqlConn.Open();
            var sqlCommand = new MySqlCommand($"SHOW TABLES FROM `{DatabaseName}`", MySqlConn);
            MySqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                Tables.Add((string)rdr[0]);
            }
            //MySqlConn.Close();
            rdr.Close();
            return Tables;
        }

        public List<FieldModel> GetTableFields(TableModel sender, string TableName, string DatabaseName)
        {
            var TableFields = new List<FieldModel>();
            //MySqlConn = new MySqlConnection(GenerateMySQLConnectionString("localhost", "root", DatabaseName)); // TODO: Make it dynamic
            //MySqlConn.Open();
            var sqlCommand = new MySqlCommand($"DESCRIBE {DatabaseName}.`{TableName}`;", MySqlConn);
            MySqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                TableFields.Add(new FieldModel()
                {
                    DatabaseName = DatabaseName,
                    FieldName = rdr[0].ToString(),
                    Type = rdr[1].ToString(),
                    Null = rdr[2].ToString(),
                    Key = rdr[3].ToString(),
                    Default = rdr[4].ToString()
                }
                );
            }
            rdr.Close();
            return TableFields;
        }
    }
}
