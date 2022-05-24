using Shop.Data.Entities;
using Shop.Services.Base;
using Shop.VM.Commands;
using Shop.VM.ViewModels.Base;
using System;
using System.Windows.Input;

namespace Shop.VM.ViewModels
{
    public class CreateVehicleVM : ViewModel
    {
        private IDataService _data;
        #region Привязки
        private string _name;
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        private string _manufacturer;
        public string Manufacturer
        {
            get => _manufacturer;
            set => Set(ref _manufacturer, value);
        }
        private int _power;
        public int Power
        {
            get => _power;
            set => Set(ref _power, value);
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => Set(ref _price, value);
        }
        #endregion
        #region Команды
        #region Создать
        private ICommand _createCommand;
        public ICommand CreateCommand => _createCommand ??=
            new LambdaCommand(OnCreateCommandExecuted, CanCreateCommandExecute);
        private void OnCreateCommandExecuted(object obj)
        {
            _data.Vehicles.Add(new Vehicle
            {
                ModelName = Name,
                ManufacturerName = Manufacturer,
                Power = Power,
                Price = Price
            });
            _data.Complete();
        }
        private bool CanCreateCommandExecute(object arg) => true;
        #endregion
        #endregion
        public CreateVehicleVM(IDataService data)
        {
            _data = data;
        }
    }
}
