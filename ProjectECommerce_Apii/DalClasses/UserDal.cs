using ProjectECommerce_Apii.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectECommerce_Apii.DalClasses
{
    public class UserDal
    {
        public List<User> users = new List<User>();

        string conStr = "Data Source =EVT03306NB\\SQLEXPRESS;Initial Catalog = E_CommerceDb; Integrated Security=SSPI";
        public List<User> GetUsers()
        {
            SqlConnection connection = new SqlConnection(conStr);
            string quary = "select * from Users";
            SqlCommand cmd = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int genderId = Convert.ToInt32(dr[3]);
                User user = new User(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), (Gender)genderId);
                users.Add(user);
            }
            connection.Close();
            return users;

        }
        public List<User> GetUserById(int id)
        {
            SqlConnection connection = new SqlConnection(conStr);
            string quary = "select * from Users where userId=" + id;
            SqlCommand cmd = new SqlCommand(quary, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int genderId = Convert.ToInt32(dr[3]);
                User user = new User(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), (Gender)genderId);
                users.Add(user);
            }
            connection.Close();
            return users;
        }
        public bool UserAdd(User user)
        {
            string sql = "insert into Users (userId,userName,email,gender) values('" + user.UserId + "','" + user.UserName + "','" + user.Email + "','" + user.Gender + "')";
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
        public bool UserUpdate(User user)
        {
            string sql = "update Users set userName='" + user.UserName + "' ,email='" + user.Email + "', gender='" + user.Gender + "' where userId='" + user.UserId + "' ";
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
        public bool UserDelete(int id)
        {
            string sql = "delete from Users Where userId= " + id;
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
        public string LoginUser(string name, string email)
        {

            string result = "Basarısızz...";
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand komut = new SqlCommand("Select * from Users", conn);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                if (name == reader["userName"].ToString().TrimEnd() && email == reader["email"].ToString().TrimEnd())
                {
                    result = "giriş basarılı";
                    break;
                }

            }
            conn.Close();
            return result;
        }
    }
}
