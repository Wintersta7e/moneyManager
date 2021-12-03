using System;
using System.Windows;
using System.Windows.Input;
using MoneyManager.Helpers;
using MoneyManager.Models;

namespace MoneyManager.Controls
{
    /// <summary>
    ///     Interaction logic for TransactionCreator.xaml
    /// </summary>
    public partial class TransactionCreator
    {
        //public event handler to handle click on add button inside usercontrol
        public RoutedEventHandler OnAddTransaction;

        public TransactionCreator()
        {
            InitializeComponent();

            Events();
        }

        private string Description => TxtDescription.Text;

        private decimal Amount => ValueCheck.GetVal(TxtAmount.Text);

        private EAssetType Type => EvaluateType(TxtAmount.Text);

        private static string Date => DateTime.Now.ToLongDateString();

        public Asset AssetItem => new Asset
            {Description = Description, Amount = Amount, Category = Type, CreationDate = Date};

        private void OnAddTransactionClick(object sender, RoutedEventArgs e)
        {
            OnAddTransaction(sender, e);
        }

        //test value input and "restrict" it to only doubles
        private static void OnTextPreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValueCheck.IsDouble(e.Text);
        }

        private void Events()
        {
            AddTransaction.Click += OnAddTransactionClick;
            TxtAmount.PreviewTextInput += OnTextPreviewInput;
        }

        private static EAssetType EvaluateType(string amount)
        {
            return amount.Contains("-") ? EAssetType.Expense : EAssetType.Income;
        }
    }
}