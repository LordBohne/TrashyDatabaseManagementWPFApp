using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagementUI.Models
{
    public class ConfigHandler
    {
        public string optXAMPPLocation { get; set; }
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
