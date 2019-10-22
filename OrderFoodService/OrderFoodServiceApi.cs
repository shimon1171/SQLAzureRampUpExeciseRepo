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

        public OrderFoodServiceApi(IDal dal = null)
        {
            Dal = dal;
            if (Dal == null)
            {
                Dal = new LocalSqlDalApi();
            }
            Dal.Init();
        }

        public bool Init()
        {
            if (Dal == null) return false;
            return Dal.Init();
        }

        public IEnumerable<string> GetOrdersByCompanyAndDay(string companyName, DateTime date)
        {
            if (Dal == null) return null;
            if (companyName == null) return null;
            return Dal.GetOrdersByCompanyAndDay(companyName, date);
        }


        public int Order(string userName, string companyName, string restaurantName, string description, DateTime date)
        {
            if (Dal == null) return -1;
            if (userName == null) return -1;
            if (companyName == null) return -1;
            if (restaurantName == null) return -1;
            if (description == null) return -1;
            return Dal.Order(userName, companyName, restaurantName, description, date);
        }

        public IDal Dal { get; }
    }
}
