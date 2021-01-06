
using System.Diagnostics;


//namespace DatabaseManagementUI.Models.SQL
namespace DatabaseManagementUI.Models
{
    public class SQL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processStart"></param>
        public static void ProcessStart(string processStart)
        {
            //Simple-DMS\DatabaseManagementUI\XAMPP\mysql_start.bat

            Process.Start(processStart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processStop"></param>
        public static void ProcessStop(string processStop)
        {
            //Simple-DMS\DatabaseManagementUI\XAMPP\mysql_stop.bat

            Process.Start(processStop);
        }
    }
}