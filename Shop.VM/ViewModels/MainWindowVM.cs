﻿using Shop.Data;
using Shop.Data.Entities;
using Shop.Services;
using Shop.Services.Base;
using Shop.VM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shop.VM.ViewModels
{
    public class MainWindowVM : ViewModel
    {
        private ShopContext _db;
        private IDataService _data;
        private IAutoShopSellService _sell;
        #region Привязки
        private Deal _deal;
        public Deal Deal
        {
            get => _deal;
            set => Set(ref _deal, value);
        }
        private decimal _totalSum;
        public decimal TotalSum
        {
            get => _totalSum;
            set => Set(ref _totalSum, value);
        }
        private Customer _selectedCustomer;
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set => Set(ref _selectedCustomer, value);
        }

        private IEnumerable<Customer> _customers;
        public IEnumerable<Customer> Customers
        {
            get => _customers;
            set => Set(ref _customers, value);
        }

        private IEnumerable<Vehicle> _vehicles;
        public IEnumerable<Vehicle> Vehicles
        {
            get => _vehicles;
            set => Set(ref _vehicles, value);
        }
        #endregion
        #region Команды
        #region Создание договора

        #endregion
        #region Отмена договора

        #endregion
        #region Просмотр договоров

        #endregion
        #endregion
        public MainWindowVM()
        {
            _db = new ShopContext();
            _data = new DataService(_db);
            _sell = new AutoShopSellService(_data);

            //Vehicles = _data.Vehicles.GetAll();
            //Customers = _data.Customers.GetAll();
        }
    }
}