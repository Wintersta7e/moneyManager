using MoneyManager.Helpers;
using MoneyManager.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyManager.Controls
{
    /// <summary>
    /// Interaction logic for TransactionCreator.xaml
    /// </summary>
    public partial class TransactionCreator : UserControl
    {
        //public event handler to handle click on add button inside usercontrol
        public RoutedEventHandler OnAddTransaction;

        private void OnAddTransactionClick(object sender, RoutedEventArgs e)
        {
            this.OnAddTransaction(sender, e);
        }

        //test value input and "restrict" it to only doubles
        private void OnTextPreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValueCheck.IsDouble(e.Text);
        }

        private void Events()
        {
            this.AddTransaction.Click += this.OnAddTransactionClick;
            this.txtAmount.PreviewTextInput += this.OnTextPreviewInput;
        }

        public TransactionCreator()
        {
            InitializeComponent();

            this.Events();
        }

        public string Description
        {
            get => this.txtDescription.Text;
            set => this.txtDescription.Text = value.ToString();
        }

        public decimal Amount
        {
            get => ValueCheck.GetVal(this.txtAmount.Text);
            set => this.txtAmount.Text = value.ToString();
        }

        public EAssetType Type => EvaluateType(this.txtAmount.Text);

        public string Date
        {
            get => DateTime.Now.ToLongDateString();
        }

        private EAssetType EvaluateType(string amount)
        {
            return amount.Contains("-") ? EAssetType.EXPENSE : EAssetType.INCOME;
        }

        public Asset AssetItem => new Asset { Description = this.Description, Amount = this.Amount, Category = this.Type, CreationDate = this.Date };
    }
}