using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Models
{
    public class Asset
    {
        public string Description { get; set; }

        public double Amount { get; set; }

        public string CreationDate { get; set; }

        public EAssetType Category { get; set; }
    }
}
