using AccountingProjectWPF.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AccountingProjectWPF
{
    /// <summary>
    /// Interaction logic for ucStatement.xaml
    /// </summary>
    public partial class ucStatement : UserControl
    {
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register("Header", typeof(string), typeof(ucStatement));

        public ObservableCollection<CardDetails> CardDetailsList
        {
            get { return (ObservableCollection<CardDetails>)GetValue(CardDetailsListProperty); }
            set { SetValue(CardDetailsListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardDetailsListProperty =
            DependencyProperty.Register("CardDetailsList", typeof(ObservableCollection<CardDetails>), typeof(ucStatement));

        public Card DataModel
        {
            get { return (Card)GetValue(DataModelProperty); }
            set { SetValue(DataModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataModelProperty =
            DependencyProperty.Register("DataModel", typeof(Card), typeof(ucStatement));

        public ucStatement(Card dm)
        {
            DataModel = dm;

            InitializeComponent();

            Header = DataModel.Header;
            CardDetailsList = DataModel.CardDetailsList;

            DataContext = this;
        }

        public ucStatement()
        {
            InitializeComponent();
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            CardDetailsList.Remove((CardDetails)(sender as ucCard).DataContext);

            Save?.Invoke(this, e);
        }

        public event EventHandler Save;
    }
}
