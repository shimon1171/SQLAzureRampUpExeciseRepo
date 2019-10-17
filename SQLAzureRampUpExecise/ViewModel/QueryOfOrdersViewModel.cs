using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SQLAzureRampUpExecise.UiServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//SQLAzureRampUpExeciseScript.sql
namespace SQLAzureRampUpExecise.ViewModel
{
    public class Orderdata
    {
        public Orderdata()
        {

        }
        public Orderdata(string description)
        {
            Description = description;
        }
        public string Description { set; get; }
    }

    


    public interface IQueryOfOrdersViewModel
    {
        string CompanyName { get; set; }
        DateTime Date { get; set; }
        ObservableCollection<Orderdata> OrdersDescription { get; set; }
        ICommand GetOrdersCommand { get; }
        ICommand CleanOrdersCommand { get; }
    }

    public class QueryOfOrdersViewModelDesign : IQueryOfOrdersViewModel
    {
        public QueryOfOrdersViewModelDesign()
        {
            CompanyName = "Microsoft";
            Date = new DateTime(1985, 9, 17);
            LogMessage = "Order recived";
            OrdersDescription = new ObservableCollection<Orderdata>
            {
                new Orderdata("dsdsd"),
                new Orderdata("dsdsds"),
                new Orderdata("dsdsds")
            };

        }
        public string LogMessage { get; set; }
        public ObservableCollection<Orderdata> OrdersDescription { get; set; }
        public string CompanyName { get; set; }
        public DateTime Date { get; set; }
        public ICommand GetOrdersCommand => new RelayCommand(() => { });
        public ICommand CleanOrdersCommand => new RelayCommand(() => { });

    }

    public class QueryOfOrdersViewModel : ViewModelBase, IQueryOfOrdersViewModel
    {
        public QueryOfOrdersViewModel(IMakeOrderUiService makeOrderUiService)
        {
            MakeOrderUiService = makeOrderUiService;
            Date = DateTime.Now;
            GetOrdersCommand = new RelayCommand(GetOrders);
            CleanOrdersCommand = new RelayCommand(CleanOrders);
        }

        private void CleanOrders()
        {
            OrdersDescription = new ObservableCollection<Orderdata>();
            LogMessage = $"Clean Orders";
        }

        private async void GetOrders()
        {
            var orders = await MakeOrderUiService.GetOrdersByCompanyAndDay(CompanyName, Date);
            if (orders != null && orders.Count() > 0)
            {
                OrdersDescription = new ObservableCollection<Orderdata>(orders.Select(s => new Orderdata(s)));
                LogMessage = $"Get {orders.Count()} Oreders form server";
            }
            else
            {
                OrdersDescription = new ObservableCollection<Orderdata>();
                LogMessage = $"Get null or zero Oreders form server";
            }
        }

        private string _companyName;
        public string CompanyName
        {
            get => _companyName;
            set => Set(ref _companyName, value);
        }

        private DateTime _data;
        public DateTime Date
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


        private ObservableCollection<Orderdata> _ordersDescription;
        public ObservableCollection<Orderdata> OrdersDescription
        {
            get => _ordersDescription;
            set => Set(ref _ordersDescription, value);
        }


        public ICommand GetOrdersCommand { get; private set; }
        public ICommand CleanOrdersCommand { get; private set; }
        public IMakeOrderUiService MakeOrderUiService { get; }
    }
}
