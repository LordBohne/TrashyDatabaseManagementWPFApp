using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace DatabaseManagementUI.Models
{
    public class DatabaseConnector
    {
        public MySqlConnection MySqlConn = new MySqlConnection();
        /// <summary>
        /// The constructor of the DatabaseConnector class. Its job is to initialiase a database connection to a specified
        /// database
        /// </summary>
        /// <param name="ConnectionString">The connection string required to connect to the SQL server</param>
        /// <param name="ServerType">The type of the server e.g. MYSQL, SQL Server etc.
        /// 1 beeing Mysql
        /// 2 beeing SQL Server
        /// </param>
        public DatabaseConnector(string ConnectionString,int ServerType=1)
        {
            switch (ServerType)
            {
                case 1:
                    MySqlConn.ConnectionString = ConnectionString;
                    MySqlConn.Open();
                    break;
                default:
                    break;
            }
            
        }
    }
}
