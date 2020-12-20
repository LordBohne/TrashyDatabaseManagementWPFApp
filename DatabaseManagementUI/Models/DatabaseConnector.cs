using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace DatabaseManagementUI.Models
{
    public class DatabaseConnector
    {
        // TODO: Make everything asyncrynous 
        // TODO: Optimize and comment the code
        public MySqlConnection MySqlConn { get; set; }
        public string ConnectionString { get; set; }
        /// <summary>
        /// The constructor of the DatabaseConnector class. Its job is to initialiase a database connection to a specified
        /// database
        /// </summary>
        /// <param name="ConnectionString">The connection string required to connect to the SQL server</param>
        /// <param name="ServerType">The type of the server e.g. MYSQL, SQL Server etc.
        /// 1 beeing Mysql
        /// 2 beeing SQL Server
        /// </param>
        public DatabaseConnector(string ConnectionString, int ServerType = 1)
        {
            switch (ServerType)
            {
                case 1:
                    try
                    {
                        //MySqlConn.ConnectionString = ConnectionString;
                        //MySqlConn.Open();
                        this.ConnectionString = ConnectionString;
                        break;
                    }
                    catch (InvalidOperationException e)
                    {
                        throw e;
                    }

                default:
                    break;
            }

        }
        public int ExecuteScript(string Script, string Delimiter = null)
        {
            try
            {
                MySqlScript sqlScript = new MySqlScript(MySqlConn, Script);
                if (Delimiter != null)
                {
                    sqlScript.Delimiter = Delimiter;
                }
                return sqlScript.Execute();
            }
            catch (Exception)
            {

                throw;
            }

        }
        public async Task<DataTable> Query(string SQL, int CommandTimeout=30)
        {
            MySqlConn = new MySqlConnection(this.ConnectionString);
            MySqlConn.Open();
            List<int> StringSymbolLocation = new List<int>();
            List<int> SemicolonLocation = new List<int>();
            List<int> StringsWithSemicolons = new List<int>();
            List<string> Statements = new List<string>();
            DataTable QueryResult = new DataTable();
            int StartPos = 0;
            int StartPos2 = 0;
            for (int i = 0; i < SQL.Length; i++)
            {
                if (SQL[i] == '\"' || SQL[i] == '\'' || SQL[i] == '`')
                {
                    StringSymbolLocation.Add(i);
                }
                else if (SQL[i] == ';')
                {
                    SemicolonLocation.Add(i);
                }
            }
            if (StringSymbolLocation.Count % 2 != 0)
            {
                
            }
            else if (SemicolonLocation.Count == 0)
            {
                Statements.Add(SQL);
            }
            
            for (int i = 0; i < StringSymbolLocation.Count; i+=2)
            {
                var StringFirstSymbol = StringSymbolLocation[i];
                var StringSecondSymbol = StringSymbolLocation[i + 1];
                var StringToCheck = SQL.Substring(StringFirstSymbol, StringSecondSymbol - StringFirstSymbol); // may need to add an additional -1 to the Equation
                if (StringToCheck.Contains(';'))
                {
                    StringsWithSemicolons.Add(StringFirstSymbol);
                    StringsWithSemicolons.Add(StringSecondSymbol);
                } 
                
            }
            if (StringsWithSemicolons.Count == 0)
            {
                foreach (var Semicolon in SemicolonLocation)
                {
                    Statements.Add(SQL.Substring(StartPos2, Semicolon));
                    StartPos2 = Semicolon;
                }
            }
            for (int i = 0; i < SemicolonLocation.Count; i++)
            {
                for (int STL = 0; STL < StringsWithSemicolons.Count; STL+=2)
                {
                    if (SemicolonLocation[i] >= StringsWithSemicolons[STL] !&& SemicolonLocation[i] <= StringsWithSemicolons[STL+1])
                    {
                        

                    }
                    else
                    {
                        var test = SQL.Length;
                        Statements.Add(SQL.Substring(StartPos+1, SemicolonLocation[i] - StartPos));
                        StartPos = SemicolonLocation[i];
                    }
                }
            }
            foreach (string Statement in Statements)
            {
                var sqlCommand = new MySqlCommand(Statement, MySqlConn);
                sqlCommand.CommandTimeout = CommandTimeout;
                if (!Statement.ToLower().Contains("select"))
                {
                    await sqlCommand.ExecuteNonQueryAsync();
                }
                else
                {
                    var Reader = await sqlCommand.ExecuteReaderAsync();
                    QueryResult.Load(Reader);
                    Reader.Close();

                }
                sqlCommand.Dispose();
            }
            MySqlConn.Close();
            return QueryResult;
        }

        public List<string> GetMySQLDatabases()
        {
            MySqlConn = new MySqlConnection(ConnectionString);
            MySqlConn.Open();
            var sqlCommand = new MySqlCommand("SHOW DATABASES", MySqlConn);
            var Databases = new List<string>();
            MySqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
               Databases.Add((string)rdr[0]);
            }
            MySqlConn.Close();
            return Databases;
        }

        public List<string> GetMySQLTables(string DatabaseName)
        {
            List<string> Tables = new List<string>();
            MySqlConn = new MySqlConnection(GenerateMySQLConnectionString(DatabaseName, "localhost", "", "root")); // TODO: Make it dynamic
            MySqlConn.Open();
            var sqlCommand = new MySqlCommand("SHOW TABLES", MySqlConn);
            MySqlDataReader rdr = sqlCommand.ExecuteReader();
            while (rdr.Read())
            {
                Tables.Add((string)rdr[0]);
            }
            MySqlConn.Close();
            return Tables;
        }

        public string GenerateMySQLConnectionString(string DatabaseName, string ServerLocation, string Password, string UserName)
        {
            return "";
        }
    }
}
