using ProjectECommerce_Api.Models;
using System.Data.SqlClient;

namespace ProjectECommerce_Api.DalClasses
{
    public class BasketDal
    {
        string conStr = "Data Source =EVT03306NB\\SQLEXPRESS;Initial Catalog = E_CommerceDb; Integrated Security=SSPI";
        List<Basket> baskets = new List<Basket>();
        public bool BasketAdd(double price)
        {
            string sql = "insert into Baskets (totalPrice) values('" + price + "')";
            bool result = false;

            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;
        }
        public bool BasketDelete(int id)
        {
            string sql = "delete from Baskets Where basketId= " + id;
            bool result = false;

            SqlConnection conn = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand(sql, conn);

            try
            {
                if (conn.State != System.Data.ConnectionState.Open)
                {
                    conn.Open();
                }
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    result = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
            return result;

        }
        public List<Basket> GetBaskets()
        {
            SqlConnection connection = new SqlConnection(conStr);
            string quary = "select * from Baskets";
            SqlCommand cmd = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Basket basket = new Basket(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]));
                baskets.Add(basket);
            }
            connection.Close();
            return baskets;

        }

    }
}
