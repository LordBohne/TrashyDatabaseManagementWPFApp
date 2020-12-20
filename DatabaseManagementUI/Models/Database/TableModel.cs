using System.Collections.Generic;

namespace DatabaseManagementUI.Models
{
    public class TableModel
    {
        // The primary key that corresponds to the current row
        public string TableName { get; set; }
        // The individuel rows of the database
        public List<TableFieldModel> Table { get; set; }

    }
}
