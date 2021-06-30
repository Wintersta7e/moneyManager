using MoneyManager.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Helpers
{
    public static class FileSaver
    {
        public static ExpenseList Load(string name)
        {
            string js = System.IO.File.ReadAllText(name);
            double transaction;
            ListObserver listObserver = JsonConvert.DeserializeObject<ListObserver>(js);
            ObservableCollection<Asset> income = new ObservableCollection<Asset>();
            ObservableCollection<Asset> costs = new ObservableCollection<Asset>();

            foreach (var i in listObserver.income)
            {
                transaction = i.Amount;
                income.Add(new Asset { Description = i.Description, Amount = i.Amount, CreationDate = i.CreationDate, Category = i.Category });
            }
            foreach (var c in listObserver.costs)
            {
                transaction = c.Amount;
                costs.Add(new Asset { Description = c.Description, Amount = c.Amount, CreationDate = c.CreationDate, Category = c.Category });
            }

            return new ExpenseList(costs, income);
        }

        public static void SaveAs (string name, ExpenseList expenseList)
        {
            ListObserver listObserver = new ListObserver(expenseList);

            string js = JsonConvert.SerializeObject(listObserver);

            System.IO.File.WriteAllText(name, js);
        }
    }
}
