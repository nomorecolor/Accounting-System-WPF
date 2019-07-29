using AccountingProjectWPF.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingProjectWPF.DataAccess
{
    public class DataAccess
    {
        //private DataModel _dataModel { get => Read(); set => Write(value); }
        private DataModel _dataModel { get; set; }

        public DataAccess()
        {
            _dataModel = Read();
        }

        public Card LoadData(CardQuery cardQuery)
        {
            var cardList = _dataModel.CardList.Where(dm => dm.Month == cardQuery.Month
                                                           && dm.Year == cardQuery.Year
                                                           && dm.Header == cardQuery.Header).ToList();

            var card = new Card();

            card.Header = cardQuery.Header;
            card.Month = cardQuery.Month;
            card.Year = cardQuery.Year;

            if (cardList.Any())
                card.CardDetailsList = cardList.FirstOrDefault().CardDetailsList;

            return card;
        }

        public List<Card> LoadData(ReportQuery reportQuery)
        {
            return _dataModel.CardList.Where(dm => dm.Month == reportQuery.Month
                                                   && dm.Year == reportQuery.Year).ToList();
        }

        public List<Card> LoadData()
        {
            return _dataModel.CardList;
        }

        public void SaveData(Card card)
        {
            var data = _dataModel.CardList.Where(dm => dm.Month == card.Month
                                             && dm.Year == card.Year
                                             && dm.Header == card.Header).ToList();

            if (data.Any())
                _dataModel.CardList.RemoveAt(_dataModel.CardList.IndexOf(data[0]));

            _dataModel.CardList.Add(card);

            Write(_dataModel);
        }

        private DataModel Read()
        {
            var docPath = AppDomain.CurrentDomain.BaseDirectory + @"Data.ate";
            var json = string.Empty;

            if (File.Exists(docPath))
                json = File.ReadAllText(docPath);

            return json == string.Empty ? new DataModel() : JsonConvert.DeserializeObject<DataModel>(json);
        }

        private void Write(DataModel dataModel)
        {
            var json = JsonConvert.SerializeObject(dataModel);

            var docPath = AppDomain.CurrentDomain.BaseDirectory + @"Data.ate";

            File.WriteAllText(docPath, json);
        }
    }
}
