using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models.Interfaces
{
    interface IAsset
    {
        DateTime Date { get; set; }
        string Description { get; set; }
        double Value { get; set; }

        void Save();
    }
}
