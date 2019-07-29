using System;
using System.ComponentModel;

namespace AccountingProjectWPF.Model
{
    public class CardDetails 
    {
        public string Header { get; set; }
        public object Amount { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string HeaderAmount { get => $"{Header} - {Amount}"; }
    }
}