using AccountingProjectWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.ViewModel
{
    public class CardViewModel
    {
        public Card Card { get; set; }

        private DataAccess.DataAccess _dataAccess;

        public CardViewModel()
        {
            Card = new Card();

            _dataAccess = new DataAccess.DataAccess();
        }

        public void SaveCard(Card card)
        {
            _dataAccess.SaveData(card);
        }

        //private Card LoadCard(CardModelQuery cardModelQuery)
        //{
        //    return _dataAccess.LoadData(cardModelQuery);
        //}

        public void LoadCard(CardModelQuery cardModelQuery)
        {
            Card = _dataAccess.LoadData(cardModelQuery); 
        }
    }
}
