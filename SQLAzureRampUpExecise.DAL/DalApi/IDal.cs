using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalApi
{
    public interface IDal
    {

        bool Init();

        //Place an order and return an order id. 
        int Order(string userName, string companyName, string restaurantName, string description);
        //Returns the descriptions of all orders made by users of a specific company in a specific day.  
        //For example return all the descriptions of orders made by Microsoft users on the 1th of April 2018. 
        IEnumerable<string> GetOrdersByCompanyAndDay(string companyName, DateTime date);
        int Order(string userName, string companyName, string restaurantName, string description, DateTime date);
    }
}
