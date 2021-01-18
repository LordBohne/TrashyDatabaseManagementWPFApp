using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseManagementUI.Properties;
namespace DatabaseManagementUI.ViewModels
{
    public class SettingsPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        private static string mySQLServerExecutablePath = Properties.Settings.Default.MysqlServerExecutableLocation;
        public string MySQLServerExecutablePath
        {
            get
            {
                return mySQLServerExecutablePath;
            }
            set
            {
                if (mySQLServerExecutablePath == value)
                {
                    return;
                }
                mySQLServerExecutablePath = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(MySQLServerExecutablePath)));
                Properties.Settings.Default.MysqlServerExecutableLocation = value;
            }
        }
    }
}
