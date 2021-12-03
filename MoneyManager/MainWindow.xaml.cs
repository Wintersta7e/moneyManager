using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MoneyManager.Helpers;
using MoneyManager.Models;

namespace MoneyManager
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadedFile(ExpenseList expenseList)
        {
            ExpIncOverview.ExpenseList = new ExpenseList(expenseList.Costs, expenseList.Income);
            ExpIncOverview.IncomeList.ItemsSource = ExpIncOverview.ExpenseList.Income;
            ExpIncOverview.CostsList.ItemsSource = ExpIncOverview.ExpenseList.Costs;

            DataContext = this;
            ExpIncOverview.UpdateResults();
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
            var menu = ((MenuItem) e.OriginalSource).Name;

            switch (menu)
            {
                case "menuSave":
                    FileSaver.SaveFile(ExpIncOverview.ExpenseList);
                    break;

                case "menuLoad":
                    Load();
                    break;
            }
        }

        private void Load()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == true) LoadedFile(FileSaver.Load(openFileDialog.FileName));
        }
    }
}