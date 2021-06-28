using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyManager.Controls
{
    /// <summary>
    /// Interaction logic for TransactionCreator.xaml
    /// </summary>
    public partial class TransactionCreator : UserControl
    {
        static Regex doubleReg = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");

        //public event handler to handle click on add button inside usercontrol
        public RoutedEventHandler OnAddTransaction;

        private void onAddTransactionClick(object sender, RoutedEventArgs e)
        {
            this.OnAddTransaction(sender, e);
        }

        //test value input and "restrict" it to only doubles
        private void onTextPreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = this.isDouble(e.Text);
        }

        //use regex and test if value input text can be converted to double
        bool isDouble(string number)
        {
            return !doubleReg.IsMatch(number);
        }

        void events()
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
            get
            {
                return this.txtDescription.Text;
            }
            set
            {
                this.txtDescription.Text = value.ToString();
            }
        }

        public double Amount
        {
            get
            {
                return this.getVal();
            }
            set
            {
                this.txtAmount.Text = value.ToString();
            }
        }

        public EAssetType Type
        {
            get
            {
                return this.evaluateType(this.txtAmount.Text);
            }
        }

        private EAssetType evaluateType(string amount)
        {
            return Convert.ToDouble(amount) < 0 ? EAssetType.EXPENSE : EAssetType.INCOME;
        }

        private double getVal()
        {
            double val;
            if (!Double.TryParse(this.txtAmount.Text, out val))
                return 0;
            return val;
        }

        public Asset assetItem
        {
            get
            {
                return new Asset { Description = this.Description, Amount = this.Amount, Category = this.Type, Date = DateTime.Now };
            }
        }
    }
}
