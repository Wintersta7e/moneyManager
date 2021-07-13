using MoneyManager.Helpers;
using MoneyManager.Models;
using System;
using System.Text.RegularExpressions;
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

        private void onAddTransactionClick(object sender, RoutedEventArgs e)
        {
            this.OnAddTransaction(sender, e);
        }

        //test value input and "restrict" it to only doubles
        private void onTextPreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValueCheck.isDouble(e.Text);
        }

        private void events()
        {
            this.AddTransaction.Click += this.onAddTransactionClick;
            this.txtAmount.PreviewTextInput += this.onTextPreviewInput;
        }

        public TransactionCreator()
        {
            InitializeComponent();

            this.events();
        }

        public string Description
        {
            get => this.txtDescription.Text;
            set => this.txtDescription.Text = value.ToString();
        }

        public double Amount
        {
            get => ValueCheck.getVal(this.txtAmount.Text);
            set => this.txtAmount.Text = value.ToString();
        }

        public EAssetType Type
        {
            get => this.evaluateType(this.txtAmount.Text);
        }

        public string Date
        {
            get => DateTime.Now.ToLongDateString();
        }

        private EAssetType evaluateType(string amount)
        {
            return Convert.ToDouble(amount) < 0 ? EAssetType.EXPENSE : EAssetType.INCOME;
        }

        public Asset AssetItem
        {
            get
            {
                return new Asset { Description = this.Description, Amount = this.Amount, Category = this.Type, CreationDate = this.Date };
            }
        }
    }
}