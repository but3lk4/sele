using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace sele
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    [TestFixture]
    public class SUnitTests
    {

       public IWebDriver _driver
       {
            private set;

            get;
       }

        [SetUp]
        public void StartBrowser()
        {
            _driver = new FirefoxDriver();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();

        }

        [Test]
        public void LoginTest()
        {
           
            var userName = "jDoe234";
            var password = "newJonDoe234";

            _driver.Navigate().GoToUrl("https://github.com/login");

           
            var searchUserBox = _driver.FindElement(By.Id("login_field"));
            var searchPasswordBox = _driver.FindElement(By.Id("password"));

            searchUserBox.SendKeys(userName + Keys.Enter);
             searchPasswordBox.SendKeys(password + Keys.Enter);


            new WebDriverWait(_driver, TimeSpan.FromSeconds(10))

            .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.CssSelector("div.hdtb - mitem:nth - child(1)"))));
            StringAssert.StartsWith("https://www.google.pl/search?", _driver.Url);
        }

        


    }
}
