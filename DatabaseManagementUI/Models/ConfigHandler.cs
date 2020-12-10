using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagementUI.Models
{
    public class ConfigHandler
    {
        public Dictionary<string, bool> Settings = new Dictionary<string, bool>();
        public bool ConfigCreate(string ConfigPath)
        {
            try
            {
                File.Create(ConfigPath);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                return false;
                throw;
            }
        }
    }
}
