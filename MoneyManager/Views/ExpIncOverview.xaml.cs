using System.Globalization;
using System.Windows;
using MoneyManager.Models;

namespace MoneyManager.Views
{
    public partial class ExpIncOverview
    {
        private int _sel = -1;

        public ExpIncOverview()
        {
            InitializeComponent();

            OnLoad();
        }

        public ExpenseList ExpenseList { get; set; }

        private void OnLoad()
        {
            ExpenseList = new ExpenseList();

            AssetCreator.OnAddTransaction = AddAsset;

            IncomeList.ItemsSource = ExpenseList.Income;
            CostsList.ItemsSource = ExpenseList.Costs;

            DataContext = this;
        }

        public void UpdateResults()
        {
            TotalCosts.Text = ExpenseList.TotalCosts.ToString(CultureInfo.InvariantCulture);
            TotalIncome.Text = ExpenseList.TotalIncome.ToString(CultureInfo.InvariantCulture);
            TotalSum.Text = ExpenseList.FinalSum.ToString(CultureInfo.InvariantCulture);
        }

        private void AddAsset(object sender, RoutedEventArgs e)
        {
            ExpenseList.AddAsset(AssetCreator.AssetItem);
            UpdateResults();
            //TODO: this.AssetCreator.Reset()
        }

        private void IncomeListSelection(object sender, RoutedEventArgs e)
        {
            if (IncomeList.Items.Count == 0) return;

            _sel = IncomeList.SelectedIndex;

            if (_sel > ExpenseList.Income.Count || _sel < 0)
                //TODO: WIP
                return;
        }

        private void CostsListSelection(object sender, RoutedEventArgs e)
        {
            if (CostsList.Items.Count == 0)
                return;

            _sel = CostsList.SelectedIndex;
            if (_sel > ExpenseList.Costs.Count || _sel < 0)
                return;
        }
    }
}