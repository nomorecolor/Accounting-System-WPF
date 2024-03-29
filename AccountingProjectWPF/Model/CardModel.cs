﻿using AccountingProjectWPF.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AccountingProjectWPF.Common.Enums;

namespace AccountingProjectWPF.Model
{
    public class CardModel { }
    public class Card
    {
        public StatementType Header { get; set; }
        public Months Month { get; set; }
        public int Year { get; set; }
        public ObservableCollection<CardDetails> CardDetailsList { get; set; }

        public Card()
        {
            CardDetailsList = new ObservableCollection<CardDetails>();
        }
    }
}
