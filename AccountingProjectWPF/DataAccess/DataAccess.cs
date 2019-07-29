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
        private DataModel _dataModel { get => Read(); set => Write(value); }

        public Card LoadData(CardModelQuery dataModelQuery)
        {
            var cardList = _dataModel.CardList.Where(dm => dm.Month == dataModelQuery.Month
                                                           && dm.Year == dataModelQuery.Year
                                                           && dm.Header == dataModelQuery.Header).ToList();

            var card = new Card();

            card.Header = dataModelQuery.Header;
            card.Month = dataModelQuery.Month;
            card.Year = dataModelQuery.Year;

            if (cardList.Any())
                card.CardDetailsList = cardList.FirstOrDefault().CardDetailsList;

            return card;
        }

        public List<Card> LoadData()
        {
            return _dataModel.CardList;
        }

        public void SaveData(Card dataModel)
        {
            var dataComplete = _dataModel.CardList;

            var data = dataComplete.Where(dm => dm.Month == dataModel.Month
                                             && dm.Year == dataModel.Year
                                             && dm.Header == dataModel.Header).ToList();

            if (data.Any())
                dataComplete.RemoveAt(dataComplete.IndexOf(data[0]));

            dataComplete.Add(dataModel);
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
