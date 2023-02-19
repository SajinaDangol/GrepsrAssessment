using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Conduit.Automation.Source.Drivers
{
    public class Driver
    {
        public static IWebDriver _driver;
        [SetUp]
        public void InitScript()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://next-realworld.vercel.app");
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
