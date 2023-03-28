using ProjectECommerce_Api.Models;
using System.Data.SqlClient;

namespace ProjectECommerce_Api.DalClasses
{
    public class PaymentDal
    {
        List<Payment> payments = new List<Payment>();
        BasketDal basketDal = new BasketDal();
        string conStr = "Data Source =EVT03306NB\\SQLEXPRESS;Initial Catalog = E_CommerceDb; Integrated Security=SSPI";

        public bool PaymentAddAndBasketDelete(int id, PaymentOption paymentOption, int basketid)
        {
            Payment payment = new Payment(id, paymentOption, basketid);

            string sql = "insert into Payments (paymentId,basketId,optionPayment) values('" + payment.PaymentId + "','" + payment.BasketId + "','" + payment.PaymentOption + "')";
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
            id = payment.BasketId;
            basketDal.BasketDelete(id);
            return result;
        }
    }
}
