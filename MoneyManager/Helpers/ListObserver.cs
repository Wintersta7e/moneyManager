using MoneyManager.Models;
using System.Collections.ObjectModel;

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

        public ListObserver(ExpenseList expenseList)
        {
            this.income = expenseList.Income;
            this.costs = expenseList.Costs;
        }
    }
}