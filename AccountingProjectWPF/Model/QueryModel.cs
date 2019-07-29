using AccountingProjectWPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AccountingProjectWPF.Common.Enums;

namespace AccountingProjectWPF.Model
{
    public class CardQuery
    {
        public StatementType Header { get; set; }
        public Months Month { get; set; }
        public int Year { get; set; }
    }

    public class ReportQuery
    {
        public StatementType Header { get; set; }
        public Months Month { get; set; }
        public int Year { get; set; }
        public ReportView ReportView { get; set; }
    }
}
