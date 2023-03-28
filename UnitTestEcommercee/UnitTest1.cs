using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ProjectECommerce_Apii;
using ProjectECommerce_Apii.Models;
using System.Reflection;
using ProjectECommerce_Apii.DalClasses;
using System.Windows.Markup;
using System.Collections.Generic;
using ProjectECommerce_Apii.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Security.Policy;

namespace UnitTestEcommercee
{
    [TestClass]
    public class UnitTest1
    {
        UserDal userDal=new UserDal();
        ProductDal productDal=new ProductDal();
        Product product=new Product(2,"kkkk",15,(int)Catagory.Ayıcık );

        WebSite webSite = new WebSite();

        [TestMethod]
        public void DummyDataControl()
        {
            List<Product> productdb = productDal.GetProductById(2);
            
            List<Product> products = new List<Product>();
            products.Add(product);
            Assert.AreEqual(productdb.Count,products.Count);
        }

        [TestMethod]
        public void WepSiteProductControl()
        {
            var webproducts = webSite.GetWebProducts("osevio");
            
            Assert.AreEqual(48,webproducts.Count);
        }

        [TestMethod]
        public void DbLoginControl()
        {
            string name = "ngul";
            string email = "16";
            string result = "";
            if (email.Length>3 && name.Length>3)
            {
                result = userDal.LoginUser(name,email);
            }
            else
            {
                result = "";
            }
            Assert.AreEqual(result,"giriş basarılı");
        }
        [TestMethod]
        public void WebLoginControl()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Url = "https://www.osevio.com/";
            Thread.Sleep(TimeSpan.FromSeconds(2));
            
            driver.FindElement(By.XPath(" html / body / section[3] / div / div / div[1] / div / a / span")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            
            driver.FindElement(By.XPath("html/body/header/div/div/div[3]/ul/li[2]")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            var email = driver.FindElement(By.Id("Email"));
            if (email != null)
            {
                email.SendKeys("gonulyldrm46@gmail.com");
               
            }

            Thread.Sleep(TimeSpan.FromSeconds(2));
            var password = driver.FindElement(By.Id("Password"));
            if (password != null)
            {
                password.SendKeys("gonuly.:1");

            }
            Thread.Sleep(TimeSpan.FromSeconds(20));  
            driver.FindElement(By.Id("login-button")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            //var kirmizigul = driver.FindElement(By.XPath("//*[@id='vl-storylb-container-13']/div/div[1]/a/div"));
            //string kirmizi = "Kırmızı Gül";
            //Assert.AreEqual(kirmizigul,kirmizi);

            Thread.Sleep(TimeSpan.FromSeconds(2));

            driver.Close();

        }

    }
}
