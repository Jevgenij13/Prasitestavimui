using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V108.CSS;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Prasitestavimui
{
    internal class pigult
    {
        static IWebDriver driver;

        [SetUp]
        public static void SETUP()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://pigu.lt/";
            By CookieAgreeButton = By.XPath("//button[@widget-attachpoint='agree']");
            driver.FindElement(CookieAgreeButton).Click();
        }
        [TearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }
        [Test]
        public static void LoginLockedOutTest()
        {
            Thread.Sleep(300);
            By CatName = By.XPath("(//ul[@class='departaments-list-container']/li)[3]");
            driver.FindElement(CatName).Click();
            Thread.Sleep(500);
            By CatName2 = By.XPath("(//ul[contains(@class,'link-menu__has-submenu')]//a)[4]");
            driver.FindElement(CatName2).Click();
            Thread.Sleep(300);
            By firstProduct = By.XPath("//div[@id='productListLoader']//div[contains(@class,'product-list-item')]//p//a");
            Thread.Sleep(300);
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(firstProduct));
            driver.FindElement(firstProduct).Click();
            driver.FindElement(firstProduct).Click();
            Thread.Sleep(300);
            By addToBasket = By.XPath("//button[@widget-attachpoint=\"addToCart\"]");
            driver.FindElement(addToBasket).Click();
            Thread.Sleep(300);
            By closeBasketPopUp = By.XPath("//div[@class=\"modal-content\"]//a[@class=\"close-modal\"]");
            driver.FindElement(closeBasketPopUp).Click();
            By countInBasket = By.XPath("//span[@widget-attachpoint=\"count\"]");
            string count = driver.FindElement(countInBasket).Text;
            Assert.AreEqual("1", count);
        }
    }
}
