using AccountingProjectWPF.Model;
using AccountingProjectWPF.ViewModel;
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

        private CardViewModel _cardVM;
        private CardQuery _cardQuery;

        public ucStatement(CardQuery cardQuery)
        {
            _cardVM = new CardViewModel();
            _cardQuery = cardQuery;

            _cardVM.LoadCard(_cardQuery);

            DataContext = _cardVM;

            InitializeComponent();
        }

        public void AddEntry(CardDetails cardDetails)
        {
            _cardVM.Card.CardDetailsList.Add(cardDetails);
            _cardVM.SaveCard();
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            _cardVM.Card.CardDetailsList.Remove((CardDetails)(sender as ucCard).DataContext);
            _cardVM.SaveCard();
        }
    }
}
