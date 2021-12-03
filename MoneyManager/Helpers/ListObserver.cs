using System.Collections.ObjectModel;
using MoneyManager.Models;

namespace MoneyManager.Helpers
{
    public class ListObserver
    {
        public readonly ObservableCollection<Asset> Costs;
        public readonly ObservableCollection<Asset> Income;

        public ListObserver()
        {
            Income = new ObservableCollection<Asset>();
            Costs = new ObservableCollection<Asset>();
        }

        public ListObserver(ExpenseList expenseList)
        {
            Income = expenseList.Income;
            Costs = expenseList.Costs;
        }
    }
}