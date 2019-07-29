using AccountingProjectWPF.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.Model
{
    public class CardModel { }
    public class Card
    {
        public string Header { get; set; }
        public Enums.Months Month { get; set; }
        public int Year { get; set; }
        public ObservableCollection<CardDetails> CardDetailsList { get; set; }

        public Card()
        {
            CardDetailsList = new ObservableCollection<CardDetails>();
        }
    }
}
