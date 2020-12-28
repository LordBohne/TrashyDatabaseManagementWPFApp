using DatabaseManagementUI.DatabaseStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DatabaseManagementUI.Models.DatabaseStructure
{
    public class DatabaseModel
    {
        public string DatabaseName { get; set; }
        public List<DataTableModel> Tables { get; set; }
    }
}
