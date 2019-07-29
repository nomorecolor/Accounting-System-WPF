using AccountingProjectWPF.Model;
using AccountingProjectWPF.ViewModel;
using System;
using System.Collections.Generic;
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

namespace AccountingProjectWPF
{
    /// <summary>
    /// Interaction logic for ucReport.xaml
    /// </summary>
    public partial class ucReport : UserControl
    {
        public double Income
        {
            get { return (double)GetValue(IncomeProperty); }
            set { SetValue(IncomeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IncomeProperty =
            DependencyProperty.Register("Income", typeof(double), typeof(ucCard));

        public double Expense
        {
            get { return (double)GetValue(ExpenseProperty); }
            set { SetValue(ExpenseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ExpenseProperty =
            DependencyProperty.Register("Expense", typeof(double), typeof(ucCard));

        public double Savings
        {
            get { return (double)GetValue(SavingsProperty); }
            set { SetValue(SavingsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SavingsProperty =
            DependencyProperty.Register("Savings", typeof(double), typeof(ucCard));

        private ReportViewModel _reportVM;
        private ReportQuery _reportQuery;

        public ucReport(ReportQuery reportQuery)
        {
            _reportVM = new ReportViewModel();
            _reportQuery = reportQuery;

            _reportVM.LoadReport(_reportQuery);

            DataContext = _reportVM;

            InitializeComponent();
        }
    }
}
