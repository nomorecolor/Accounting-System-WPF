using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.Common
{
    public static class Enums
    {
        public enum Months
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12
        }

        public enum ReportView
        {
            CompactView = 1,
            DetailedView = 2
        }

        public enum StatementType
        {
            None = 0,
            Income = 1,
            Expense = 2
        }

        public enum MainView
        {
            None = 0,
            Statement = 1,
            Reports = 2
        }
    }
}
