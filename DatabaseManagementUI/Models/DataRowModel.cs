﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseManagementUI.Models
{
    public class DataRowModel
    {
        // The primary key that corresponds to the current row
        public string PrimaryKey { get; set; }
        // The individuel rows of the database
        public List<DataFieldModel> DataRow { get; set; }
        
    }
}
