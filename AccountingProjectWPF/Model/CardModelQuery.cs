using AccountingProjectWPF.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.Model
{
    public class CardModelQuery
    {
        public string Header { get; set; }
        public Enums.Months Month { get; set; }
        public int Year { get; set; }
    }
}
