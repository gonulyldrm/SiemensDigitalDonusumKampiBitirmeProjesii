using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectECommerce_Apii.Selenium
{
    public class WebSite
    {
        public List<WebProduct> webproducts = new List<WebProduct>();
        public List<WebProduct> GetWebProducts(string site)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";

            Thread.Sleep(TimeSpan.FromSeconds(5));
            var searchbox = driver.FindElement(By.Name("q"));
            if (searchbox != null)
            {
                searchbox.SendKeys(site);
                searchbox.SendKeys(OpenQA.Selenium.Keys.Enter);
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));

            driver.FindElement(By.XPath("//*[@id='rso']/div[1]/div/div/div/div/div/div/div[1]/a/h3")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            driver.FindElement(By.XPath(" html / body / section[3] / div / div / div[1] / div / a / span")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));

            driver.FindElement(By.XPath("//*[@id='navbarMenu']/ul[1]/li[4]")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string url = driver.Url;

            driver.Quit();


            string product_card_query = "//div[@class='col-xxl-2 col-xl-3 col-md-3 col-6']/a[1]";

            HtmlWeb web = new HtmlWeb();
            //List<WebProduct> product_list = new List<WebProduct>();

            while (true)
            {
                try
                {

                    var doc = web.Load(url);

                    var products = doc.DocumentNode.SelectNodes(product_card_query);


                    foreach (var productDiv in products)
                    {
                        WebProduct new_product = new WebProduct();

                        var product_url_node = productDiv.SelectSingleNode("//a[@class='card reduced  mb-3']");
                        if (product_url_node != null)
                            new_product.ProductUri = url + product_url_node.Attributes["href"].Value;

                        var product_image_node = productDiv.SelectSingleNode(".//figure/img");
                        string product_image_url = string.Empty;
                        if (product_image_node != null)
                            new_product.ProductImageUri = product_image_node.Attributes["src"].Value;

                        var title_node = productDiv.SelectSingleNode(".//div/p");
                        if (title_node != null)
                            new_product.ProductTitle = title_node.InnerText;

                        var price_node = productDiv.SelectSingleNode(".//div/ul/li[3]/div/span[1]");
                        if (price_node != null)
                            new_product.ProductPrice = price_node.InnerText;


                        webproducts.Add(new_product);


                    }
                    return webproducts;




                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);


                }
                return webproducts;
            }

        }
        public List<WebProduct> WebProducts()
        {
            string product_card_query = "//div[@class='col-xxl-2 col-xl-3 col-md-3 col-6']/a[1]";
            const string BASE_URI = "https://www.osevio.com/urun/hediye";

            HtmlWeb web = new HtmlWeb();
            List<WebProduct> product_list = new List<WebProduct>();
            int pageNumber = 50;
            while (true)
            {
                try
                {

                    var doc = web.Load(BASE_URI);

                    var products = doc.DocumentNode.SelectNodes(product_card_query);


                    foreach (var productDiv in products)
                    {
                        WebProduct new_product = new WebProduct();

                        var product_url_node = productDiv.SelectSingleNode("//a[@class='card reduced  mb-3']");
                        if (product_url_node != null)
                            new_product.ProductUri = BASE_URI + product_url_node.Attributes["href"].Value;

                        var product_image_node = productDiv.SelectSingleNode(".//figure/img");
                        string product_image_url = string.Empty;
                        if (product_image_node != null)
                            new_product.ProductImageUri = product_image_node.Attributes["src"].Value;

                        var title_node = productDiv.SelectSingleNode(".//div/p");
                        if (title_node != null)
                            new_product.ProductTitle = title_node.InnerText;

                        var price_node = productDiv.SelectSingleNode(".//div/ul/li[3]/div/span[1]");
                        if (price_node != null)
                            new_product.ProductPrice = price_node.InnerText;


                        product_list.Add(new_product);


                    }
                    pageNumber++;
                    return product_list;




                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);


                }
                return product_list;
            }
        }
    }
}
