using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MoneyManager.Models
{
    public class ExpenseList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyRaised(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private ObservableCollection<Asset> costs;

        public ObservableCollection<Asset> Costs
        {
            get => this.costs;
            set => this.costs = value;
        }

        private ObservableCollection<Asset> income;

        public ObservableCollection<Asset> Income
        {
            get => this.income;
            set => this.income = value;
        }

        private decimal computeCosts()
        {
            decimal sum = 0;
            foreach (Asset cost in costs)
            {
                sum += cost.Amount;
            }

            return sum;
        }

        public decimal TotalCosts
        {
            get => this.computeCosts();
        }

        private decimal computeIncome()
        {
            decimal sum = 0;
            foreach (Asset inc in income)
            {
                sum += inc.Amount;
            }

            return sum;
        }

        public decimal TotalIncome
        {
            get => this.computeIncome();
        }

        private decimal computeTotal()
        {
            return this.computeIncome() + this.computeCosts();
        }

        public decimal FinalSum
        {
            get => this.computeTotal();
        }

        public ExpenseList()
        {
            this.costs = new ObservableCollection<Asset>();
            this.income = new ObservableCollection<Asset>();
        }

        public ExpenseList(ObservableCollection<Asset> _cost, ObservableCollection<Asset> _inc)
        {
            this.costs = _cost;
            this.income = _inc;
        }

        public void AddAsset(Asset ass)
        {
            if (ass.Category == EAssetType.EXPENSE)
                this.costs.Add(ass);
            else this.income.Add(ass);

            this.OnPropertyRaised("updated");
        }
    }
}