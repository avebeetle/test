using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTest.Driver
{
    public static class DriverManager
    {
        private static IWebDriver driver;

        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(@"..\..\..");
            }

            return driver;
        }

        public static void CloseWebDriver()
        {
            driver.Quit();
            driver = null;
        }
    }
}
