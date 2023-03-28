using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectECommerce_Api.DalClasses;
using ProjectECommerce_Api.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProjectECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BasketsController : ControllerBase
    {
        Basket basket=new Basket();
        BasketDal basketDal=new BasketDal();
        string sql = "Data Source =EVT03306NB\\SQLEXPRESS;Initial Catalog = E_CommerceDb; Integrated Security=SSPI";

        [HttpGet]
        public async Task<ActionResult> BasketGet()
        {
            var result = basketDal.GetBaskets();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost]
        public string BasketAdd(int productid,int adet)
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection(sql);
            string quary = "select * from Products Where productId=" + productid;
            SqlCommand cmd = new SqlCommand(quary, connection);

            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                int catagoryId = Convert.ToInt32(dr[3]);
                Product product= new Product(Convert.ToInt32(dr[0]), dr[1].ToString(), Convert.ToInt32(dr[2]),(Catagory)catagoryId);
                products.Add(product);
                basket.Add(product);
            }
            connection.Close();
            double toplamfiyat= basket.KdvliFiyat(adet);
            basketDal.BasketAdd(toplamfiyat);
            return "Ürün/Ürünler Sepete eklendi sepet tutarı: "+toplamfiyat;
        }
        
    }
}
