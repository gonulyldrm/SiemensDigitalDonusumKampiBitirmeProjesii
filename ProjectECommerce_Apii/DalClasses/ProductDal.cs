using ProjectECommerce_Apii.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectECommerce_Apii.DalClasses
{
    public class ProductDal
    {
        public List<Product> products = new List<Product>();
        string conStr = "Data Source =EVT03306NB\\SQLEXPRESS;Initial Catalog = E_CommerceDb; Integrated Security=SSPI";
        public List<Product> GetProducts()
        {


            SqlConnection connection = new SqlConnection(conStr);
            string quary = "select * from Products";
            SqlCommand cmd = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int catagoryId = Convert.ToInt32(dr[3]);
                Product product = new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), (Catagory)catagoryId);
                products.Add(product);
            }
            connection.Close();
            return products;

        }
        public List<Product> GetProductById(int id)
        {
            SqlConnection connection = new SqlConnection(conStr);
            string quary = "select * from Products where productId=" + id;
            SqlCommand cmd = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int catagoryId = Convert.ToInt32(dr[3]);
                Product product = new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]), (Catagory)catagoryId);
                products.Add(product);
            }
            connection.Close();
            return products;

        }
        public bool ProductAdd(Product product)
        {
            string sql = "insert into Products (productId,productName,price,catagory) values('" + product.ProductId + "','" + product.ProductName + "','" + product.Price + "','" + product.Catagory + "')";
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
        public bool ProductUpdate(Product product)
        {
            string sql = "update Products set productName='" + product.ProductName + "' ,price='" + product.Price + "', catagory='" + product.Catagory + "' where productId='" + product.ProductId + "'";
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
        public bool ProductDelete(int id)
        {
            string sql = "delete from Products Where productId= " + id;
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
    }
}
