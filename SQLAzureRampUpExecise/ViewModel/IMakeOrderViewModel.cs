using System;
using System.Windows.Input;

namespace SQLAzureRampUpExecise.ViewModel
{
    public interface IMakeOrderViewModel
    {
        string CompanyName { get; set; }
        DateTime Data { get; set; }
        string Description { get; set; }
        string LogMessage { get; set; }
        string RestaurantName { get; set; }
        bool SetTime { get; set; }
        string UserName { get; set; }
        ICommand MakeOrderCommand { get;  }
    }
}