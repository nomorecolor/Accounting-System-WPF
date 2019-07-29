using AccountingProjectWPF.Model;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AccountingProjectWPF
{
    /// <summary>
    /// Interaction logic for ucCard.xaml
    /// </summary>
    public partial class ucCard : UserControl
    {
        public string HeaderAmount
        {
            get { return (string)GetValue(HeaderAmountProperty); }
            set { SetValue(HeaderAmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderAmountProperty =
            DependencyProperty.Register("HeaderAmount", typeof(string), typeof(ucCard));

        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ucCard));

        public double Amount
        {
            get { return (double)GetValue(AmountProperty); }
            set { SetValue(AmountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AmountProperty =
            DependencyProperty.Register("Amount", typeof(double), typeof(ucCard));

        public DateTime DateAdded
        {
            get { return (DateTime)GetValue(DateAddedProperty); }
            set { SetValue(DateAddedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateAddedProperty =
            DependencyProperty.Register("DateAdded", typeof(DateTime), typeof(ucCard));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(ucCard));

        public string Month
        {
            get { return (string)GetValue(MonthProperty); }
            set { SetValue(MonthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MonthProperty =
            DependencyProperty.Register("Month", typeof(string), typeof(ucCard));

        public int Year
        {
            get { return (int)GetValue(YearProperty); }
            set { SetValue(YearProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearProperty =
            DependencyProperty.Register("Year", typeof(int), typeof(ucCard));

        public event EventHandler DeleteButtonClicked;

        public ucCard()
        {
            InitializeComponent();
        }

        protected virtual void OnDeleteButtonClicked(EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, e);
        }

        private void DeleteButtonClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OnDeleteButtonClicked(e);
        }
    }
}