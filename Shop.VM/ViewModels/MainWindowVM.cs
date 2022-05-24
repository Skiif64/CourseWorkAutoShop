using Shop.Data;
using Shop.Data.Entities;
using Shop.Services;
using Shop.Services.Base;
using Shop.VM.Commands;
using Shop.VM.ViewModels.Base;
using System;
using System.Collections.Generic;
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
        private CreateVehicleVM _createVM;
        public CreateVehicleVM CreateVM
        {
            get => _createVM;
            set => Set(ref _createVM, value);
        }
        private Deal _deal;
        public Deal Deal
        {
            get => _deal;
            set => Set(ref _deal, value);
        }
        public decimal TotalSum => _vehicles.Sum(x => x.Price);

        private string _customerFullName;
        public string CustomerFullName
        {
            get => _customerFullName;
            set => Set(ref _customerFullName, value);
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
        private Vehicle _selectedVehicle;
        public Vehicle SelectedVehicle
        {
            get => _selectedVehicle;
            set => Set(ref _selectedVehicle, value);
        }
        private List<Vehicle> _vehiclesCart;
        public List<Vehicle> VehiclesCart
        {
            get => _vehiclesCart;
            set => Set(ref _vehiclesCart, value);
        }
        #endregion
        #region Команды
        #region Добавить авто в договор
        private ICommand _addVehicleCommand;
        public ICommand AddVehicleCommand => _addVehicleCommand ??=
            new LambdaCommand(OnAddVehicleCommandExecuted, CanAddVehicleCommandExecute);
        private void OnAddVehicleCommandExecuted(object obj)
        {
            VehiclesCart.Add(SelectedVehicle);
        }
        private bool CanAddVehicleCommandExecute(object arg) => SelectedVehicle != null;
        
        #endregion
        #region Обновить
        private ICommand _updateCommand;
        public ICommand UpdateCommand => _updateCommand ??=
            new LambdaCommand(OnUpdateCommandExecuted, CanUpdateCommandExecute);
        private void OnUpdateCommandExecuted(object obj)
        {
            Vehicles = _data.Vehicles.GetAll().ToList();
            Customers = _data.Customers.GetAll().ToList();
        }
        private bool CanUpdateCommandExecute(object arg) => true;
        
        #endregion
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
            _createVM = new CreateVehicleVM(_data);

            Vehicles = _data.Vehicles.GetAll().ToList();
            Customers = _data.Customers.GetAll().ToList();
        }
    }
}
