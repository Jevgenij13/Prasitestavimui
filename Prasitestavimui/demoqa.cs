using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prasitestavimui
{
    
    public class demoqa
    {
        static IWebDriver driver;


        [SetUp]

        public static void Test01()
        {
             driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://demoqa.com/text-box");
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollTo(0, 350)");

        }
        [Test]

        public static void Test02()
        {
            By fullname = By.Id("userName");
            By email = By.Id("userEmail");
            By currentAddress = By.Id("currentAddress");
            By permanentAddress = By.Id("permanentAddress");
            By submitbutton = By.XPath("//button[@id='submit']");

            driver.FindElement(fullname).SendKeys("Jeronimas");
            driver.FindElement(email).SendKeys("jeronimas@gmail.com");
            driver.FindElement(currentAddress).SendKeys("Gedimino pr");
            driver.FindElement(permanentAddress).SendKeys("rygos");
            driver.FindElement(submitbutton).Click();

            By box = By.XPath("//div[@class='border col-md-12 col-sm-12']");
            if (!driver.FindElement(box).Displayed)
            {
                Assert.Fail("FAILED");
            }


        }

        //[Test]
        //public static void Test03()
        //{

        //}
    }
}
