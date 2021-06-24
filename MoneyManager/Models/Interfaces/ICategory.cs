﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.Interfaces
{
    interface ICategory
    {
        string Category { get; set; }
        string Keyword { get; set; }
        string CategoryOrder { get; set; }

        void UpdateDefinition(string old_keyword, bool is_insert);
    }
}
