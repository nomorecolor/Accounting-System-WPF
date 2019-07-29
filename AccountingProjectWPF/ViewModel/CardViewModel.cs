using AccountingProjectWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.ViewModel
{
    public class CardViewModel : NotifyPropertyChanged
    {
        private Card _card;
        public Card Card
        {
            get => _card;
            set => SetProperty(ref _card, value);
        }

        private DataAccess.DataAccess _dataAccess;

        public CardViewModel()
        {
            Card = new Card();

            _dataAccess = new DataAccess.DataAccess();
        }

        public void SaveCard()
        {
            _dataAccess.SaveData(_card);
        }

        public void LoadCard(CardQuery cardQuery)
        {
            Card = _dataAccess.LoadData(cardQuery);
        }
    }
}
