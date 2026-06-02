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
            //ChromeOptions options = new ChromeOptions();
            //options.BinaryLocation = @"C:\Program Files (X86)\Google\Chrome\Application\chrome.exe"; // Path to stable Chrome
            //options.AddArguments("--headless");

            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");

            using var driver = new ChromeDriver(options);

            IWebDriver _webDriver = new ChromeDriver(options);
            new DriverManager().SetUpDriver(new ChromeConfig());

            _webDriver.Navigate().GoToUrl("http://localhost:8080");
            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60));
            //var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            wait.Until(driver => driver.FindElement(By.Name("email")));
            //wait.Until(drv => drv.FindElement(By.CssSelector(".card-title")));

            _webDriver.FindElement(By.Name("email")).SendKeys("admin@test.com");
            _webDriver.FindElement(By.Name("password")).SendKeys("password123");
            _webDriver.FindElement(By.CssSelector("button")).Click();

            string title = _webDriver.FindElement(By.CssSelector(".card-title")).Text;

            Assert.That(title, Is.EqualTo("Projects"));

            _webDriver.Close();
            _webDriver.Quit();
        }
    }
}
