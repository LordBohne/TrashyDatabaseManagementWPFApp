using System.Collections.Generic;

namespace DatabaseManagementUI.Models.DatabaseStructure
{
    public class TableModel
    {
        // The name of the table in the database
        public string TableName { get; set; }
        // The name of the database
        public string DatabaseName { get; set; }
        
        public List<FieldModel> TableFields { get; set; }

        public TableModel(DatabaseModel database)
        {
            DatabaseName = database.DatabaseName;
        }
    }
}
