using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManagementUI.Models
{
    public class DataRowModel
    {
        public List<DataFieldModel> DataRow { get; set; }
        public string PrimaryKey { get; set; }
    }
}
