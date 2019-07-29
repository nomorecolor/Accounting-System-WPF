using AccountingProjectWPF.Common;
using AccountingProjectWPF.DataAccess;
using AccountingProjectWPF.Model;
using AccountingProjectWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ucStatement statement;

        private string header;

        private readonly Regex regex = new Regex("[^0-9.-]+");

        private CardModelQuery cardQuery;


        public MainWindow()
        {
            InitializeComponent();

            BtnIncome.Click += BtnStatementClicked;
            BtnExpense.Click += BtnStatementClicked;
            BtnExit.Click += BtnExitClicked;

            txtEntry.KeyDown += NewEntry;
            txtAmount.KeyDown += NewEntry;

            txtAmount.PreviewTextInput += PreviewTextInput;
            DataObject.AddPastingHandler(txtAmount, PastingHandler);

            HomePage.Closing += WindowClosing;

            cmbMonths.ItemsSource = Enum.GetValues(typeof(Enums.Months)).Cast<Enums.Months>();
            cmbMonths.SelectedIndex = 0;

            cmbMonths.SelectionChanged += CmbMonthsSelectionChanged;
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Helpers.DigitOnly($"{((TextBox)e.Source).Text}{e.Text}");
        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = $"{((TextBox)sender).Text}{(string)e.DataObject.GetData(typeof(string))}";

                if (Helpers.DigitOnly(text))
                    e.CancelCommand();
            }
            else
                e.CancelCommand();

        }

        private void BtnStatementClicked(object sender, RoutedEventArgs e)
        {
            header = (sender as Button).Tag.ToString();

            Statement();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Exit(e);
        }

        private void BtnExitClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CmbMonthsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Statement();
        }

        private void Statement()
        {
            if (stackMain.Children.Count > 2)
                //stackMain.Children.RemoveRange(1, stackMain.Children.Count - 1);
                stackMain.Children.RemoveAt(2);

            if (header == string.Empty) return;

            cardQuery = new CardModelQuery();

            cardQuery.Header = header;
            cardQuery.Month = (Enums.Months)Enum.Parse(typeof(Enums.Months), cmbMonths.SelectedValue.ToString());
            cardQuery.Year = 2019;

            var dm = Load(cardQuery);

            //statement = new ucStatement(dm);            
            statement = new ucStatement();
            statement.Loaded += StatementLoaded;
            statement.Save += SaveEvent;

            stackMain.Children.Add(statement);

            Grid.SetRow(statement, 1);
        }

        private void StatementLoaded(object sender, RoutedEventArgs e)
        {
            var cardVM = new CardViewModel();
            cardVM.LoadCard(cardQuery);

            statement.DataContext = cardVM;
        }

        private void Exit(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Accounting", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                e.Cancel = true;
        }

        private void NewEntry(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (txtEntry.Text.Trim().Any() && txtAmount.Text.Trim().Any())
                {
                    CreateEntry();

                    Save();

                    txtEntry.Text = string.Empty;
                    txtAmount.Text = string.Empty;

                    txtEntry.Focus();
                }
        }

        private void CreateEntry()
        {
            statement.CardDetailsList.Add(new CardDetails { Header = txtEntry.Text.Trim(), Amount = txtAmount.Text.Trim(), DateAdded = DateTime.Now, Description = string.Empty });
        }

        private void Save()
        {
            var dm = new Card();

            dm.Header = header;
            dm.CardDetailsList = statement.CardDetailsList;
            dm.Year = 2019;
            dm.Month = (Enums.Months)Enum.Parse(typeof(Enums.Months), cmbMonths.SelectedValue.ToString());

            var dataAccess = new DataAccess.DataAccess();
            dataAccess.SaveData(dm);
        }

        private Card Load(CardModelQuery dataModelQuery)
        {
            var dataAccess = new DataAccess.DataAccess();

            return dataAccess.LoadData(dataModelQuery);
        }

        private void SaveEvent(object sender, EventArgs e)
        {
            Save();
        }
    }
}
