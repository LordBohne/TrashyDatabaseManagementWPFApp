using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseManagementUI.Models.Database
{
    class DatabaseModel
    {
        public string DatabaseName { get; set; }
        public List<DataTableModel> Tables { get; set; }
    }
}
