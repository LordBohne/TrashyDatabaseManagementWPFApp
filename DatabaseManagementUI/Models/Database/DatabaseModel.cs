using System.Collections.Generic;

namespace DatabaseManagementUI.Models
{
    class DatabaseModel
    {
        // The name of the table in the database
        public string DatabaseName { get; set; }
        // The name of the database
        public string DataBaseName { get; set; }
        // The content of the database
        public List<TableModel> DataRows { get; set; }
    }
}
