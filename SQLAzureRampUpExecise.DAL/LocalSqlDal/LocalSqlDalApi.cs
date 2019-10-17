using DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LocalSqlDal
{
    public class LocalSqlDalApi : IDal , IDisposable
    {
       
        public LocalSqlDalApi()
        {
            
        }

        #region Public Methods
        public bool Init()
        {
            try
            {
                string connection = System.Configuration.ConfigurationManager.
                                ConnectionStrings["ConnectionString"].
                                ConnectionString;

                conn = new SqlConnection(connection);
                conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public void Dispose()
        {
            if(conn != null )
            {
                conn.Close();
                conn = null;
            }
        }

        public IEnumerable<string> GetOrdersByCompanyAndDay(string companyName, DateTime time)
        {
            SqlCommand cmd = new SqlCommand("GetOrdersByCompanyAndDay", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@CompanyName", companyName));
            cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime) { Value = new DateTime(time.Year, time.Month, time.Day) });
            var data = new List<string>();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                data.Add(dr["Description"].ToString());
            }
            return data;
        }

        public int Order(string userName, string companyName, string restaurantName, string description)
        {
            return Order(userName, companyName, restaurantName, description , DateTime.Now);
        }

        public int Order(string userName, string companyName, string restaurantName, string description , DateTime date)
        {
            var user_id = GetUserId(userName, companyName, restaurantName);
            if( user_id  == -1)
            {
                user_id = InsertUser(userName, companyName, restaurantName);
            }
            return InsertOrderInfo(description, date, user_id);
        }
        #endregion

        #region Private Methods
        private int InsertOrderInfo(string description, DateTime time, int user_id)
        {
            SqlCommand command = new SqlCommand("InsertOrderInfo", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime) { Value = new DateTime(time.Year,time.Month, time.Day) });
            command.Parameters.AddWithValue("@User_id", user_id);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                var id = (int)dt.Rows[0]["OrderInfoID"];
                return id;
            }
            return -1;

        }

        private int InsertUser(string userName, string companyName, string restaurantName)
        {
            SqlCommand command = new SqlCommand("InsertUser", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@CompanyName", companyName);
            command.Parameters.AddWithValue("@RestaurantName", restaurantName);

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                var id = (int)dt.Rows[0]["UserID"];
                return id;
            }
            return -1;
        }

        private int GetUserId(string userName, string companyName, string restaurantName)
        {
            SqlCommand command = new SqlCommand("GetUserId", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@CompanyName", companyName);
            command.Parameters.AddWithValue("@RestaurantName", restaurantName);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                var id = (int)dt.Rows[0]["UserID"];
                return id;
            }
            return -1;

        }
        #endregion


        SqlConnection conn = null;
    }
}
