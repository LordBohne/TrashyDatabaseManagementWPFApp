﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;

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
        public DatabaseConnector(string ConnectionString, int ServerType = 1)
        {
            switch (ServerType)
            {
                case 1:
                    try
                    {
                        MySqlConn.ConnectionString = ConnectionString;
                        MySqlConn.Open();
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
        public async void Query(string SQL)
        {

            List<int> StringSymbolLocation = new List<int>();
            List<int> SemicolonLocation = new List<int>();
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
            // TODO: New Approach this one doesnt work anymore for some reason. Split Stuff in between into substrings and look through those.
            List<int> SemicolonLocationInString = new List<int>();
            bool firstrun = true;
            for (int i = 0; i < SemicolonLocation.Count; i++)
            {
                for (int x = 0; x < StringSymbolLocation.Count; x++)
                {
                    if (SemicolonLocation[i]! < StringSymbolLocation[x] && firstrun)
                    {
                        if (x >=2)
                        {
                            x = 1;
                        }
                        var StringIndexBeforeSemicolon = StringSymbolLocation[x - 1];
                        
                        var StringIndexAfterSemicolon = StringSymbolLocation[x];
                        if (SemicolonLocation[0] > StringSymbolLocation[1])
                        {
                            StringSymbolLocation.RemoveAt(0);
                            StringSymbolLocation.RemoveAt(0);
                        }
                        if (SemicolonLocation[i] >= StringIndexBeforeSemicolon && SemicolonLocation[i] <= StringIndexAfterSemicolon)
                        {
                            StringSymbolLocation.RemoveAt(x - 1);
                            StringSymbolLocation.RemoveAt(x - 1);
                            SemicolonLocationInString.Add(SemicolonLocation[i]);
                        }
                        firstrun = false;
                    }
                    else if (SemicolonLocation[i]! < StringSymbolLocation[x])
                    {
                        var StringIndexBeforeSemicolon = 0;
                        if (x==0)
                        {
                            StringIndexBeforeSemicolon = StringSymbolLocation[x];
                        }
                        else
                        {
                            StringIndexBeforeSemicolon = StringSymbolLocation[x - 1];
                        }
                        
                        
                        var StringIndexAfterSemicolon = StringSymbolLocation[x];
                        
                        if (SemicolonLocation[i] >= StringIndexBeforeSemicolon && SemicolonLocation[i] <= StringIndexAfterSemicolon)
                        {
                            StringSymbolLocation.RemoveAt(x);
                            StringSymbolLocation.RemoveAt(x-1);
                            SemicolonLocationInString.Add(SemicolonLocation[i]);
                        }
                    }
                }
            }

            foreach (var item in SemicolonLocationInString)
            {
                MessageBox.Show(SQL.Substring(item));
            }
            var sqlCommand = new MySqlCommand(SQL, MySqlConn);


        }
    }
}
