using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MoneyManager.Models
{
    public class ExpenseList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<ReportItem> ReportItems { get; set; }

        public ObservableCollection<Asset> Costs { get; set; }

        public ObservableCollection<Asset> Income { get; set; }

        private decimal ComputeCosts()
        {
            decimal sum = 0;
            foreach (Asset cost in Costs)
            {
                sum += cost.Amount;
            }

            return sum;
        }

        public decimal TotalCosts
        {
            get => this.ComputeCosts();
        }

        private decimal ComputeIncome()
        {
            decimal sum = 0;
            foreach (Asset inc in Income)
            {
                sum += inc.Amount;
            }

            return sum;
        }

        public decimal TotalIncome
        {
            get => this.ComputeIncome();
        }

        private decimal ComputeTotal()
        {
            return this.ComputeIncome() + this.ComputeCosts();
        }

        public decimal FinalSum
        {
            get => this.ComputeTotal();
        }

        public ExpenseList()
        {
            this.Costs = new ObservableCollection<Asset>();
            this.Income = new ObservableCollection<Asset>();
        }

        public ExpenseList(ObservableCollection<Asset> _cost, ObservableCollection<Asset> _inc)
        {
            this.Costs = _cost;
            this.Income = _inc;
        }

        public void AddAsset(Asset ass)
        {
            if (ass.Category == EAssetType.EXPENSE)
            {
                this.Costs.Add(ass);
            }
            else
            {
                this.Income.Add(ass);
            }

            this.OnPropertyRaised("updated");
        }
    }
}