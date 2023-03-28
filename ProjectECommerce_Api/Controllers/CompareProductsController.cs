using Microsoft.AspNetCore.Mvc;
using ProjectECommerce_Api.DalClasses;
using ProjectECommerce_Api.Models;
using ProjectECommerce_Api.Selenium;

namespace ProjectECommerce_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CompareProductsController : ControllerBase
    {
        WebSite webSite = new WebSite();
        ProductDal productDal = new ProductDal();

        [HttpGet]
        public async Task<ActionResult<WebProduct>> GetWebsiteProduct(string siteAd)
        {
            var result = webSite.GetWebProducts(siteAd);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("{siteAd}")]
        public async Task<ActionResult> CompareProductss(string siteAd)
        {
            List<WebProduct> webProducts = webSite.GetWebProducts(siteAd);
            List<Product> dbproducts = productDal.GetProducts();
            
            List<string> results = new List<string>();


            foreach (WebProduct webProduct in webProducts)
            {
                foreach (Product product in dbproducts)
                {
                    if (Convert.ToInt32(product.Price) < Convert.ToInt32( webProduct.ProductPrice))
                    {
                        results.Add(product.ProductName+","+webProduct.ProductTitle+" arasında Databasedeki ürün daha uygun");
                    }
                    else if (Convert.ToInt32(product.Price) == Convert.ToInt32(webProduct.ProductPrice))
                    {
                        results.Add(product.ProductName + "," + webProduct.ProductTitle + " arasındaDatabasedeki ürün ve Webdeki ürünün fiyatı eşit");
                    }
                    else
                    {
                        results.Add(product.ProductName + "," + webProduct.ProductTitle + " arasındaWeb sitesindeki ürün daha uygun");
                    }
                }
            }
            
            return Ok(results);

        }
        
    }
}
