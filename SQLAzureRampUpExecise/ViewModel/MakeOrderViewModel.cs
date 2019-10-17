using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLAzureRampUpExecise.UiServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLAzureRampUpExecise.ViewModel
{
    public class MakeOrderViewModel : ViewModelBase, IMakeOrderViewModel
    {

        public MakeOrderViewModel(IMakeOrderUiService makeOrderUiService)
        {
            MakeOrderUiService = makeOrderUiService;
            Data = DateTime.Now;
            MakeOrderCommand = new RelayCommand(MakeOrder);
            
        }

        private async void MakeOrder()
        {
            DateTime time = DateTime.Now;
            if(SetTime)
            {
                time = Data;
            }
            var order_id = await MakeOrderUiService.Order(UserName, CompanyName, RestaurantName, Description, time);
            LogMessage = $"Order received. order number is : {order_id}";
        }

        private bool _setTime;
        public bool SetTime
        {
            get => _setTime;
            set => Set(ref _setTime, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        private string _restaurantName;
        public string RestaurantName
        {
            get => _restaurantName;
            set => Set(ref _restaurantName, value);
        }

        private string _companyName;
        public string CompanyName
        {
            get => _companyName;
            set => Set(ref _companyName, value);
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set => Set(ref _userName, value);
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data;
            set => Set(ref _data, value);
        }

        private string _logMessage;
        public string LogMessage
        {
            get => _logMessage;
            set => Set(ref _logMessage, value);
        }

        public ICommand MakeOrderCommand { get; private set; }
        private IMakeOrderUiService MakeOrderUiService { get; }
    }
}
