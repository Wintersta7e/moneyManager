using MoneyManager.Helpers;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyManager.Controls
{
    /// <summary>
    /// Interaction logic for PlanOverview.xaml
    /// </summary>
    public partial class PlanOverview : UserControl
    {
        private void onTextPreviewInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ValueCheck.isDouble(e.Text);
        }

        private void events()
        {
            this.txtFinancialPlan.PreviewTextInput += this.onTextPreviewInput;
            this.txtFixedCost.PreviewTextInput += this.onTextPreviewInput;
        }

        public PlanOverview()
        {
            InitializeComponent();

            events();
        }

        public decimal FinancePlan
        {
            get => ValueCheck.getVal(this.txtFinancialPlan.Text);
            set => this.txtFinancialPlan.Text = value.ToString();
        }

        public decimal FixedCosts
        {
            get => ValueCheck.getVal(this.txtFixedCost.Text);
            set => this.txtFixedCost.Text = value.ToString();
        }
    }
}