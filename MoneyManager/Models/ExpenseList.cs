using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace MoneyManager.Models
{
    public class ExpenseList : INotifyPropertyChanged
    {
        public ExpenseList()
        {
            Costs = new ObservableCollection<Asset>();
            Income = new ObservableCollection<Asset>();
        }

        public ExpenseList(ObservableCollection<Asset> cost, ObservableCollection<Asset> inc)
        {
            Costs = cost;
            Income = inc;
        }

        public ObservableCollection<ReportItem> ReportItems { get; set; }

        public ObservableCollection<Asset> Costs { get; set; }

        public ObservableCollection<Asset> Income { get; set; }

        public decimal TotalCosts => ComputeCosts();

        public decimal TotalIncome => ComputeIncome();

        public decimal FinalSum => ComputeTotal();
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private decimal ComputeCosts()
        {
            return Costs.Sum(cost => cost.Amount);
        }

        private decimal ComputeIncome()
        {
            return Income.Sum(inc => inc.Amount);
        }

        private decimal ComputeTotal()
        {
            return ComputeIncome() + ComputeCosts();
        }

        public void AddAsset(Asset ass)
        {
            if (ass.Category == EAssetType.Expense)
                Costs.Add(ass);
            else
                Income.Add(ass);

            OnPropertyRaised("updated");
        }
    }
}