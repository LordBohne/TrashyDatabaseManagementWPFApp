
using System.Diagnostics;


//namespace DatabaseManagementUI.Models.SQL
namespace DatabaseManagementUI.Models
{
    public class ProcessUtil
    {
        static Process SQLServer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="processStart"></param>
        public static void ProcessStart(string processStart)
        {
            //Simple-DMS\DatabaseManagementUI\XAMPP\mysql_start.bat

            SQLServer = Process.Start(processStart);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="processStop"></param>
        public static void ProcessStop()
        {
            //Simple-DMS\DatabaseManagementUI\XAMPP\mysql_stop.bat
            SQLServer.Kill();
            SQLServer.Dispose();
        }
    }
}