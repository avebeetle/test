using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverTest.Utilities;

namespace WebDriverTest.Pages
{
    public class LoginPage : BasePage
    {
        private readonly WebDriverWait wait;

        private readonly By loginButton = By.XPath("//*[@class='btn btn-primary menu-cta ml-2 login-button']");
        private readonly By emailInput = By.Name("Login-userName");
        private readonly By passwordInput = By.Name("Login-password");
        private readonly By loginConfirmButton = By.XPath("//*[@class='user-form-submit btn btn-cta btn-lg btn-block']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public LoginPage ClickLoginButton()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
            Driver.FindElement(loginButton).Click();

            Log.Info("Login button clicked");

            return this;
        }

        public LoginPage EnterEmail(string email)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(emailInput));
            Driver.FindElement(emailInput).SendKeys(email);

            Log.Info("Email entered");

            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            Driver.FindElement(passwordInput).SendKeys(password);

            Log.Info("Password entered");

            return this;
        }

        public MainPage ConfirmLogin()
        {
            Driver.FindElement(loginConfirmButton).Click();

            Log.Info("Login confirmed");

            return new MainPage(Driver);
        }
    }
}
