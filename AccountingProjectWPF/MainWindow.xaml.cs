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
using System.Windows.Data;
using System.Windows.Input;
using static AccountingProjectWPF.Common.Enums;

namespace AccountingProjectWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ucStatement statement;
        private ucReport report;

        private StatementType header;

        private CardQuery cardQuery;
        private ReportQuery reportQuery;

        private MainView currentView = MainView.None;

        public MainWindow()
        {
            InitializeComponent();

            BtnIncome.Click += BtnStatementClicked;
            BtnExpense.Click += BtnStatementClicked;
            BtnReport.Click += BtnReportClicked;
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

        #region Others

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

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Exit(e);
        }

        private void BtnExitClicked(object sender, RoutedEventArgs e)
        {
            Close();
        }

        #endregion Others

        #region Main

        private void BtnStatementClicked(object sender, RoutedEventArgs e)
        {
            header = (StatementType)Enum.Parse(typeof(StatementType), (sender as Button).Tag.ToString());

            Statement();

            currentView = MainView.Statement;
        }
        private void BtnReportClicked(object sender, RoutedEventArgs e)
        {
            Reports();

            currentView = MainView.Reports;
        }

        private void CmbMonthsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (currentView)
            {
                case MainView.Statement:
                    {
                        Statement();
                        currentView = MainView.Statement;
                        break;
                    }
                case MainView.Reports:
                    {
                        Reports();
                        currentView = MainView.Reports;
                        break;
                    }
            }
        }

        private void NewEntry(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (txtEntry.Text.Trim().Any() && txtAmount.Text.Trim().Any())
                {
                    CreateEntry();

                    txtEntry.Text = string.Empty;
                    txtAmount.Text = string.Empty;

                    txtEntry.Focus();
                }
        }

        #endregion Main

        #region Methods

        #region Private 

        private void Statement()
        {
            if (stackMain.Children.Count > 2)
                //stackMain.Children.RemoveRange(1, stackMain.Children.Count - 1);
                stackMain.Children.RemoveAt(2);

            if (header == StatementType.None) return;

            cardQuery = new CardQuery();

            cardQuery.Header = header;
            cardQuery.Month = (Months)Enum.Parse(typeof(Months), cmbMonths.SelectedValue.ToString());
            cardQuery.Year = 2019;

            statement = new ucStatement(cardQuery);

            stackMain.Children.Add(statement);

            Grid.SetRow(statement, 1);
        }

        private void Reports()
        {
            if (stackMain.Children.Count > 2)
                //stackMain.Children.RemoveRange(1, stackMain.Children.Count - 1);
                stackMain.Children.RemoveAt(2);

            reportQuery = new ReportQuery();

            reportQuery.Header = header;
            reportQuery.Month = (Months)Enum.Parse(typeof(Months), cmbMonths.SelectedValue.ToString());
            reportQuery.Year = 2019;

            report = new ucReport(reportQuery);

            stackMain.Children.Add(report);

            Grid.SetRow(report, 1);
        }

        private void CreateEntry()
        {
            statement.AddEntry(new CardDetails
            {
                Header = txtEntry.Text.Trim(),
                Amount = Convert.ToDouble(txtAmount.Text.Trim()),
                DateAdded = DateTime.Now,
                Description = string.Empty
            });
        }

        private void Exit(System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Accounting", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                e.Cancel = true;
        }

        #endregion Private 

        #endregion Methods
    }
}
