using Shop.Data;
using Shop.Data.Entities;
using Shop.Domain;
using Shop.Services;
using Shop.Services.Base;
using Shop.VM.Commands;
using Shop.VM.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;

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


        private string _customerFullName = string.Empty;
        public string CustomerFullName 
        {
            get => _customerFullName;
            set => Set(ref _customerFullName, value);
        }        

        private IEnumerable<Vehicle> _vehicles;
        public IEnumerable<Vehicle> Vehicles
        {
            get => _vehicles;
            set => Set(ref _vehicles, value);
        }
        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set => Set(ref _selectedVehicle, value);
        }
        private ObservableCollection<Vehicle> _vehiclesCart;
        public ObservableCollection<Vehicle> VehiclesCart
        {
            get => _vehiclesCart;
            set => Set(ref _vehiclesCart, value);
        }
        private Vehicle _selectedCartVehicle;
        public Vehicle SelectedCartVehicle
        {
            get => _selectedCartVehicle;
            set => Set(ref _selectedCartVehicle, value);
        }
        #endregion
        #region Команды
        #region Добавить авто в договор
        private ICommand _addVehicleCommand;
        public ICommand AddVehicleCommand => _addVehicleCommand ??=
            new LambdaCommand(OnAddVehicleCommandExecuted, CanAddVehicleCommandExecute);
        private void OnAddVehicleCommandExecuted(object obj)
        {
            _vehiclesCart.Add(SelectedVehicle);
            TotalSum = VehiclesCart.Sum(x => x.Price);
        }
        private bool CanAddVehicleCommandExecute(object arg) => SelectedVehicle != null;

        #endregion
        #region Удаление авто из договора
        private ICommand _removeVehicleCommand;
        public ICommand RemoveVehicleCommand => _removeVehicleCommand ??=
            new LambdaCommand(OnRemoveVehicleCommandExecuted, CanRemoveVehicleCommandExecute);
        private void OnRemoveVehicleCommandExecuted(object obj)
        {
            VehiclesCart.Remove(SelectedCartVehicle);
            TotalSum = VehiclesCart.Sum(x => x.Price);
        }
        private bool CanRemoveVehicleCommandExecute(object arg) => SelectedCartVehicle != null;

        #endregion
        #region Обновить
        private ICommand _updateCommand;  
        public ICommand UpdateCommand => _updateCommand ??=
            new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
        private void OnUpdateCommandExecuted(object obj)
        {
            Vehicles = _data.Vehicles.GetAll().ToList();            
        }
        private bool CanUpdateCommandExecute(object arg) => true;

        #endregion
        #region Создание договора
        private ICommand _createDealCommand;
        public ICommand CreateDealCommand => _createDealCommand ??=
            new LambdaCommand(OnCreateDealCommandExecuted, CanCreateDealCommandExecute);
        private void OnCreateDealCommandExecuted(object obj)
        {
            
            var order = new VehiclesOrder
            {
                CustomerName = CustomerFullName,
                Vehicles = VehiclesCart.ToList()
            };
            _sell.SellVehicle(order);
        }
        private bool CanCreateDealCommandExecute(object arg) => VehiclesCart.Count != 0 && CustomerFullName!=string.Empty;
        
        #endregion        
        #endregion
        public MainWindowVM()
        {
            _db = new ShopContext();
            _data = new DataService(_db);
            _sell = new AutoShopSellService(_data);                           
            VehiclesCart = new ObservableCollection<Vehicle>();

            Vehicles = _data.Vehicles.GetAll().ToList();
        }
    }
}
