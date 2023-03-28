using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectECommerce_Api.Models;
using System.Data.SqlClient;
using System.Data;
using ProjectECommerce_Api.DalClasses;

namespace ProjectECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        ProductDal productDal= new ProductDal();

        [HttpGet]
        public async Task<ActionResult> ProductsGet()
        {
            var result = productDal.GetProducts();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> ProductById(int id)
        {
            var result =productDal.GetProductById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();

        }
        [HttpPost]
        public async Task<ActionResult<Product>> Add(Product product)
        {
            bool result = productDal.ProductAdd(product);
            if (result == true)
            {
                return Ok(product);
            }
            return BadRequest();

        }
        [HttpPut]
        public async Task<ActionResult<Product>> Update(Product product)
        {
            bool result = productDal.ProductUpdate(product);
            if (result == true)
            {
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            bool result = productDal.ProductDelete(id);
            if (result == true)
            {
                return Ok("silindi");
            }
            return BadRequest();
        }
    }
}
