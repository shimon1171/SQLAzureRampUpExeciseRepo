using DalApi;
using LocalSqlDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OrderFoodService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrderFoodServiceApi" in both code and config file together.
    public class OrderFoodServiceApi : IOrderFoodServiceApi
    {
        public OrderFoodServiceApi()
        {
            Dal = new LocalSqlDalApi();
            Dal.Init();
        }

        public OrderFoodServiceApi(IDal dal = null)
        {
            Dal = dal;
            if (Dal == null)
            {
                Dal = new LocalSqlDalApi();
            }
            Dal.Init();
        }
        public IEnumerable<string> GetOrdersByCompanyAndDay(string companyName, DateTime date)
        {
            return Dal.GetOrdersByCompanyAndDay(companyName, date);

        }


        public int Order(string userName, string companyName, string restaurantName, string description, DateTime date)
        {
            return Dal.Order(userName, companyName, restaurantName, description, date);
        }

        public IDal Dal { get; }
    }
}
