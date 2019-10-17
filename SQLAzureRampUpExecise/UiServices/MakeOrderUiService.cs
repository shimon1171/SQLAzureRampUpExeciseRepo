using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLAzureRampUpExecise.OrderFoodServiceReference;

namespace SQLAzureRampUpExecise.UiServices
{

    public interface IMakeOrderUiService
    {
        Task<int> Order(string userName, string companyName, string restaurantName, string description, DateTime date);
        Task<IEnumerable<string>> GetOrdersByCompanyAndDay(string companyName, DateTime date);
    }

    public class MakeOrderUiService : IMakeOrderUiService
    {
        public MakeOrderUiService()
        {
            Api = new OrderFoodServiceApiClient("BasicHttpBinding_IOrderFoodServiceApi");
        }


        public async Task<int> Order(string userName, string companyName, string restaurantName, string description, DateTime date)
        {
            var order_id = await Api.OrderAsync(userName, companyName, restaurantName, description, date);
            return order_id;
        }

        public async Task<IEnumerable<string>> GetOrdersByCompanyAndDay(string companyName, DateTime date)
        {
            var data = await Api.GetOrdersByCompanyAndDayAsync(companyName, date);
            return data;
        }

        private IOrderFoodServiceApi Api;

    }
}
