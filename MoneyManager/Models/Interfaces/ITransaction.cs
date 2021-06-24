using System;

namespace MoneyManager.Models.Interfaces
{
    interface ITransaction
    {
        DateTime Date { get; set; }
        string Category { get; set; }
        double Amount { get; set; }

        void Save();
    }
}
