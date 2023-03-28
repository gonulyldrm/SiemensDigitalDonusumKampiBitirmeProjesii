using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectECommerce_Apii.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }

        public Product(int id, string name, int price, Catagory catagory)
        {
            ProductId = id;
            ProductName = name;
            Price = price;
            Catagory = catagory;

        }
        public Product()
        {

        }
    }
}
