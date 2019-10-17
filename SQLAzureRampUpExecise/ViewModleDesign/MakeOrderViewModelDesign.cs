using GalaSoft.MvvmLight.Command;
using SQLAzureRampUpExecise.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SQLAzureRampUpExecise.ViewModleDesign
{
    public class MakeOrderViewModelDesign : IMakeOrderViewModel
    {
        public MakeOrderViewModelDesign()
        {
            UserName = "Shimon Arzuan";
            CompanyName = "Microsoft";
            RestaurantName = "Sinta Bar";
            Description = "medium 200 gram Steak, 1 Sprite and Vegetable Salad";
            Data = new DateTime(1985, 9, 17);

            SetTime = true;
            LogMessage = "Order recived";
        }


        public string CompanyName { get; set; }
        public DateTime Data { get; set; }
        public string Description { get; set; }
        public string LogMessage { get; set; }
        public string RestaurantName { get; set; }
        public bool SetTime { get; set; }
        public string UserName { get; set; }
        public ICommand MakeOrderCommand => new RelayCommand( () => { });
    }
}
