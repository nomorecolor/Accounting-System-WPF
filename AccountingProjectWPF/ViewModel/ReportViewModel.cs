using AccountingProjectWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AccountingProjectWPF.Common.Enums;

namespace AccountingProjectWPF.ViewModel
{
    public class ReportViewModel : NotifyPropertyChanged
    {
        public double Income { get => Compute(StatementType.Income); }
        public double Expense { get => Compute(StatementType.Expense); }
        public double Savings { get => Income - Expense; }

        private List<Card> _cardList;

        private DataAccess.DataAccess _dataAccess;

        public ReportViewModel()
        {
            _cardList = new List<Card>();

            _dataAccess = new DataAccess.DataAccess();
        }

        public void LoadReport(ReportQuery reportQuery)
        {
            _cardList = _dataAccess.LoadData(reportQuery);
        }

        private double Compute(StatementType statementType)
        {
            var result = 0.0;

            _cardList.Where(cl => cl.Header == statementType).ToList().ForEach(c =>
            {
                result += c.CardDetailsList.Sum(cdl => Convert.ToDouble(cdl.Amount));
            });

            return result;
        }
    }
}
