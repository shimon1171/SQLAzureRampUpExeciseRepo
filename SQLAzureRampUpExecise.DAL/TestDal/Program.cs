using DalApi;
using LocalSqlDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDal
{
    class Program
    {
        static void Main(string[] args)
        {
            AddRandomData();
            IDal dal = GetDal();
            if( dal.Init() == false)
            {
                return;
            }
            var list = dal.GetOrdersByCompanyAndDay("Microsoft", new DateTime(2008, 11, 11)); // 'Microsoft', @Date = '2008-11-11'
            Console.WriteLine($"{list.Count()}");
        }

        private static IDal GetDal()
        {
            var dal = new LocalSqlDalApi();
            return dal;
        }


        private static void AddRandomData()
        {
            LocalSqlDalApi dal = new LocalSqlDalApi();
            if (dal.Init() == false)
            {
                return;
            }

            var users = new List<string> { "Yarden Kristal",  "Shimon Arzuan" ,  "Shai Blum"  };
            var companys = new List<string> { "Microsoft", "Toluna", "Google","Zim", "Elbit","Yahoo","Plus500" };
            var restaurants = new List<string> { "Japnika", "Sinta bar", "Refalo" , "Vivino" , "Aroma" , "Cafe Cafe" , "Biga" };

            DateTime baseTime = DateTime.Now; 
            foreach (var user in users)
            {
                foreach (var company in companys)
                {
                    foreach (var restaurant in restaurants)
                    {
                        DateTime time = baseTime;
                        time = time.AddDays(-20);
                        for (int i = 0; i < 50; i++)
                        {
                            time = time.AddDays(1);
                            dal.Order(user, company, restaurant, user + "_" + company + "_" + restaurant + "_" + "Description_" + time.ToString("MM:dd:yyyy"), time); 
                        }
                    }
                }
            }


        }

    }
}
