using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Timesheet.Test.E2E
{
    public class E2ELoginTest
    {
        [Test]
        public void TestLoginReturnsCorrectPage()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            IWebDriver _webDriver = new ChromeDriver();

            _webDriver.Navigate().GoToUrl("http://localhost:8080");

            _webDriver.FindElement(By.Name("email")).SendKeys("admin@test.com");
            _webDriver.FindElement(By.Name("password")).SendKeys("password123");
            _webDriver.FindElement(By.CssSelector("button")).Click();

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.CssSelector(".card-title")));

            string title = _webDriver.FindElement(By.CssSelector(".card-title")).Text;

            Assert.That(title, Is.EqualTo("Projects"));

            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}
