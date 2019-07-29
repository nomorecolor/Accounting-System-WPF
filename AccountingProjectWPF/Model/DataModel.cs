using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.Model
{
    public class DataModel
    {
        public List<Card> CardList { get; set; }

        public DataModel()
        {
            CardList = new List<Card>();
        }
    }
}
