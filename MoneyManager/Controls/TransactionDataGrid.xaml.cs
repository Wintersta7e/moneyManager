using MoneyManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for TransactionDataGrid.xaml
    /// </summary>
    public partial class TransactionDataGrid : UserControl
    {
        public ObservableCollection<Asset> Assets { get; set; }

        public TransactionDataGrid()
        {
            InitializeComponent();

            this.Assets = new ObservableCollection<Asset>();

            this.DataContext = this;
        }
    }
}
