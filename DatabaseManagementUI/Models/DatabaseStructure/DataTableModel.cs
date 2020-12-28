using System.Collections.Generic;

namespace DatabaseManagementUI.DatabaseStructure
{
    public class DataTableModel
    {
        // The name of the table in the database
        public string TableName { get; set; }
        // The name of the database
        public List<DataTableModel> DataFields { get; set; }
    }
}
