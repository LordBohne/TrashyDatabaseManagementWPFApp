using System.Collections.Generic;

namespace DatabaseManagementUI.Models.DatabaseStructure
{
    public class DataTableModel
    {
        // The name of the table in the database
        public string TableName { get; set; }
        // The name of the database
        public List<DataFieldModel> TableFields { get; set; }
    }
}
