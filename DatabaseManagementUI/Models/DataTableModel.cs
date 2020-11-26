using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManagementUI.Models
{
    class DataTableModel
    {
        public string TableName { get; set; }
        public List<DataRowModel> dataRows { get; set; }
    }
}
