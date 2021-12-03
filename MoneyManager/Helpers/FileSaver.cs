using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Win32;
using MoneyManager.Models;
using Newtonsoft.Json;

namespace MoneyManager.Helpers
{
    public static class FileSaver
    {
        private static readonly string FILTER = "Json files (*.json)|*.json|Text files (*.txt)|*.txt";

        public static ExpenseList Load(string name)
        {
            var js = File.ReadAllText(name);
            var listObserver = JsonConvert.DeserializeObject<ListObserver>(js);
            var income = new ObservableCollection<Asset>();
            var costs = new ObservableCollection<Asset>();

            foreach (var i in listObserver.Income)
                income.Add(new Asset
                {
                    Description = i.Description, Amount = i.Amount, CreationDate = i.CreationDate, Category = i.Category
                });
            foreach (var c in listObserver.Costs)
                costs.Add(new Asset
                {
                    Description = c.Description, Amount = c.Amount, CreationDate = c.CreationDate, Category = c.Category
                });

            return new ExpenseList(costs, income);
        }

        public static void SaveAs(string name, ExpenseList expenseList)
        {
            var listObserver = new ListObserver(expenseList);
            var js = JsonConvert.SerializeObject(listObserver);
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
                var fileName = saveFileDialog.FileName;
                SaveAs(fileName, expenseList);
            }
        }
    }
}