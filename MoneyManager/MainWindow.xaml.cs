using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace MoneyManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing()
        {

        }

        private void AddTransaction_Click(object sender, RoutedEventArgs e)
        {
            //string description = txtDescription.Text;
            //double amount = convertToDouble(txtAmount.Text);
            //EAssetType type;

            //type = amount < 0 ? EAssetType.EXPENSE : EAssetType.INCOME;

            //Asset ass = new Asset { Description = description, Amount = amount, Category = type, Date = DateTime.Now };

            //this.Assets.Add(ass);
        }

        private void NumericOnly(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private double convertToDouble (string someDouble)
        {
            return Convert.ToDouble(someDouble);
        }
    }
}
