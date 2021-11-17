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
        private int sel = -1;

        public ExpenseList ExpenseList { get; set; }

        private void OnLoad()
        {
            this.ExpenseList = new ExpenseList();

            this.AssetCreator.OnAddTransaction = new RoutedEventHandler(AddAsset);

            this.IncomeList.ItemsSource = this.ExpenseList.Income;
            this.CostsList.ItemsSource = this.ExpenseList.Costs;

            this.DataContext = this;
        }

        private void LoadedFile(ExpenseList _expenseList)
        {
            this.ExpenseList = new ExpenseList(_expenseList.Costs, _expenseList.Income);
            this.IncomeList.ItemsSource = this.ExpenseList.Income;
            this.CostsList.ItemsSource = this.ExpenseList.Costs;

            this.DataContext = this;
            this.UpdateResults();
        }

        private void UpdateResults()
        {
            this.TotalCosts.Text = this.ExpenseList.TotalCosts.ToString();
            this.TotalIncome.Text = this.ExpenseList.TotalIncome.ToString();
            this.TotalSum.Text = this.ExpenseList.FinalSum.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();

            this.OnLoad();
        }

        private void AddAsset(object sender, RoutedEventArgs e)
        {
            this.ExpenseList.AddAsset(this.AssetCreator.AssetItem);
            this.UpdateResults();
            //TODO: this.AssetCreator.Reset()
        }

        private void IncomeListSelection(object sender, RoutedEventArgs e)
        {
            if (this.IncomeList.Items.Count == 0)
            {
                return;
            }

            this.sel = this.IncomeList.SelectedIndex;

            if (this.sel > this.ExpenseList.Income.Count || this.sel < 0)
            {
                //TODO: WIP
                return;
            }
        }

        private void CostsListSelection(object sender, RoutedEventArgs e)
        {
            if (this.CostsList.Items.Count == 0)
                return;

            this.sel = this.CostsList.SelectedIndex;
            if (this.sel > this.ExpenseList.Costs.Count || this.sel < 0)
                return;
        }

        private void MenuClick(object sender, RoutedEventArgs e)
        {
            string menu = ((MenuItem)e.OriginalSource).Name;

            switch (menu)
            {
                case "menuSave":
                    FileSaver.SaveFile(this.ExpenseList);
                    break;

                case "menuLoad":
                    Load();
                    break;

                default:
                    break;
            }
        }

        public void Load()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
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