using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Helpers
{
    public class ListObserver
    {
        public ObservableCollection<Asset> income;
        public ObservableCollection<Asset> costs;

        public ListObserver()
        {
            this.income = new ObservableCollection<Asset>();
            this.costs = new ObservableCollection<Asset>();
        }

        public ListObserver (ExpenseList expenseList)
        {
            this.income = expenseList.Income;
            this.costs = expenseList.Costs;
        }
    }
}
