using System.Collections.Generic;

namespace DatabaseManagementUI.Models.DatabaseStructure
{
    public class DataTableModel
    {
        // The name of the table in the database
        public string TableName { get; set; }
        // The name of the database
        public string DatabaseName { get; set; }
        
        public List<DataFieldModel> TableFields { get; set; }

        public DataTableModel(DatabaseModel database)
        {
            DatabaseName = database.DatabaseName;
        }
    }
}
