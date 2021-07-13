using Microsoft.Win32;
using MoneyManager.Helpers;
using MoneyManager.Models;
using System.Windows;
using System.Windows.Controls;

namespace MoneyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExpenseList expenseList;

        private int sel = -1;

        public ExpenseList ExpenseList
        {
            get
            {
                return this.expenseList;
            }
            set
            {
                this.expenseList = value;
            }
        }

        private void OnLoad()
        {
            this.expenseList = new ExpenseList();

            this.AssetCreator.OnAddTransaction = new RoutedEventHandler(AddAsset);

            this.IncomeList.ItemsSource = this.expenseList.Income;
            this.CostsList.ItemsSource = this.expenseList.Costs;

            this.DataContext = this;
        }

        private void LoadedFile(ExpenseList _expenseList)
        {
            this.expenseList = new ExpenseList(_expenseList.Costs, _expenseList.Income);
            this.IncomeList.ItemsSource = this.expenseList.Income;
            this.CostsList.ItemsSource = this.expenseList.Costs;

            this.DataContext = this;
            this.UpdateResults();
        }

        private void UpdateResults()
        {
            this.TotalCosts.Text = this.expenseList.TotalCosts.ToString();
            this.TotalIncome.Text = this.expenseList.TotalIncome.ToString();
            this.TotalSum.Text = this.expenseList.FinalSum.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();

            this.OnLoad();
        }

        private void AddAsset(object sender, RoutedEventArgs e)
        {
            this.expenseList.AddAsset(this.AssetCreator.AssetItem);
            this.UpdateResults();
            //TODO: this.AssetCreator.Reset();
        }

        private void IncomeListSelection(object sender, RoutedEventArgs e)
        {
            if (this.IncomeList.Items.Count == 0)
                return;

            this.sel = this.IncomeList.SelectedIndex;
            if (this.sel > this.expenseList.Income.Count || this.sel < 0)
                return;
        }

        private void CostsListSelection(object sender, RoutedEventArgs e)
        {
            if (this.CostsList.Items.Count == 0)
                return;

            this.sel = this.CostsList.SelectedIndex;
            if (this.sel > this.expenseList.Costs.Count || this.sel < 0)
                return;
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
            string menu = ((MenuItem)e.OriginalSource).Name;

            switch (menu)
            {
                case "menuSave":
                    FileSaver.SaveFile(this.expenseList);
                    break;

                case "menuLoad":
                    Load();
                    break;
            }
        }

        public void Load()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                this.LoadedFile(FileSaver.Load(openFileDialog.FileName));
            }
        }
    }
}