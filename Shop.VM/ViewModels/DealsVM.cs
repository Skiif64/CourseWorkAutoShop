using Shop.Data;
using Shop.Data.Entities;
using Shop.Services;
using Shop.Services.Base;
using Shop.VM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.VM.ViewModels
{
    public class DealsVM : ViewModel
    {
        private IDataService _data;
        #region Привязки
        private IEnumerable<Deal> _deals;
        public IEnumerable<Deal> Deals
        {
            get => _deals;
            set => Set(ref _deals, value);
        }

        private Deal _selectedDeal;
        public Deal SelectedDeal
        {
            get => _selectedDeal;
            set
            {
                Set(ref _selectedDeal, value);
                Document = ConvertToDocument(_selectedDeal);
            }
        }        

        private string _document;
        public string Document
        {
            get => _document;
            set => Set(ref _document, value);
        }
        #endregion
        public DealsVM()
        {
            var db = new ShopContext();
            _data = new DataService(db);
            Deals = _data.Deals.GetAll().ToList();
        }

        private string ConvertToDocument(Deal deal)
        {
            var str = $"Договор №{deal.Id}\n" +
                $"Дата заключения: {deal.OfferTime}\n" +
                $"Заключен с покупателем: {deal.Customer}\n" +
                $"Автомобиль(ли): \n";
            foreach(var veh in deal.Vehicles)
            {
                str += $"{veh}\n";
            }
            return str;

        }
    }
}
