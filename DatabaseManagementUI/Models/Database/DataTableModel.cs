using System.Collections.Generic;

namespace DatabaseManagementUI.Models
{
    class DataTableModel
    {
        // The name of the table in the database
        public string TableName { get; set; }
        // The name of the database
        public string DataBaseName { get; set; }
        // The content of the database
        public List<DataRowModel> DataRows { get; set; }
    }
}
