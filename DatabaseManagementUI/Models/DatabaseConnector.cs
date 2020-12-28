using DatabaseManagementUI.DatabaseStructure;
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
                MySqlScript sqlScript = new MySqlScript(MySqlConn, Script);
                if (Delimiter != null)
                {
                    sqlScript.Delimiter = Delimiter;
                }
                return sqlScript.Execute();
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
                ;
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
        /// <summary>
        /// Generates a MYSQL connection string for the MySql.Data.MySqlClient Library
        /// </summary>
        /// <param name="ServerLocation">The location of the Server example: localhost or 127.0.0.1</param>
        /// <param name="UserName">The username that is required to log into the MYSQL Server example: root</param>
        /// <param name="DatabaseName">The name of the database if a connection to a specific database is wanted</param>
        /// <param name="Password">The password that is required to log into the MYSQL Server example: 1238127471267</param>
        /// <returns></returns>
        public static string GenerateMySQLConnectionString(string ServerLocation, string UserName, string DatabaseName=null,  string Password=null)
        {
            return $"server={ServerLocation};uid={UserName};pwd={Password};database={DatabaseName}";
        }
    }
}
