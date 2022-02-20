using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace WebDriverTest.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(driver, this);
        }
    }
}
