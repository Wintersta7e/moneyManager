using Microsoft.Win32;
using MoneyManager.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace MoneyManager.Helpers
{
    public static class FileSaver
    {
        private static readonly string FILTER = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

        public static ExpenseList Load(string name)
        {
            string js = File.ReadAllText(name);
            ListObserver listObserver = JsonConvert.DeserializeObject<ListObserver>(js);
            ObservableCollection<Asset> income = new ObservableCollection<Asset>();
            ObservableCollection<Asset> costs = new ObservableCollection<Asset>();

            foreach (Asset i in listObserver.income)
            {
                income.Add(new Asset { Description = i.Description, Amount = i.Amount, CreationDate = i.CreationDate, Category = i.Category });
            }
            foreach (Asset c in listObserver.costs)
            {
                costs.Add(new Asset { Description = c.Description, Amount = c.Amount, CreationDate = c.CreationDate, Category = c.Category });
            }

            return new ExpenseList(costs, income);
        }

        public static void SaveAs(string name, ExpenseList expenseList)
        {
            ListObserver listObserver = new ListObserver(expenseList);
            string js = JsonConvert.SerializeObject(listObserver);
            File.WriteAllText(name, js);
        }

        public static void SaveFile(ExpenseList expenseList)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string fileName = saveFileDialog.FileName;
                SaveAs(fileName, expenseList);
            }
        }
    }
}