using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OrderFoodService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderFoodServiceApi" in both code and config file together.
    [ServiceContract]
    public interface IOrderFoodServiceApi
    {
        //Place an order and return an order id. 
        [OperationContract]
        int Order(string userName, string companyName, string restaurantName, string description, DateTime date);

        //Returns the descriptions of all orders made by users of a specific company in a specific day.  
        //For example return all the descriptions of orders made by Microsoft users on the 1th of April 2018. 
        [OperationContract]
        IEnumerable<string> GetOrdersByCompanyAndDay(string companyName, DateTime date);
    }
}
