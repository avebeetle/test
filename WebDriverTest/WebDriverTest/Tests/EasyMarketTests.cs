using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using WebDriverTest.Utilities;
using WebDriverTest.Driver;
using WebDriverTest.Pages;
using FluentAssertions;
using System.Threading;
using WebDriverTest.Model;
using WebDriverTest.Service;

namespace WebDriverTest.Tests
{
    public class EasyMarketTestsFirstPack : IDisposable
    {
        protected IWebDriver Driver;

        public EasyMarketTestsFirstPack()
        {
            Log.Info("Start test");
            Driver = DriverManager.GetWebDriver();
            Driver.Navigate().GoToUrl("https://www.easymarkets.com/syc/");

            LoginPage loginPage = new LoginPage(Driver);
            User testUser = UserBuilder.WithCredentialsFromProperty();
            var mainPage = loginPage
                .ClickLoginButton()
                .EnterEmail(testUser.Email)
                .EnterPassword(testUser.Password)
                .ConfirmLogin();
        }

        public void Dispose()
        {
            Log.Info($"End test");
            DriverManager.CloseWebDriver();
        }

        [Fact]
        public void CreateUpBTCTradeDealWithSufficientAmountOfFundsOnAccount()
        {
            string riskSum = "10";

            var btcTradeDeals = new MainPage(Driver)
                .ClosePopUpWindows()
                .ChooseBitcoinToTrade()
                .FillFormWithRiskSum(riskSum)
                .ChooseUpDeal()
                .GetTrades();

            btcTradeDeals.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void CreateDownBTCTradeDealWithSufficientAmountOfFundsOnAccount()
        {
            string riskSum = "10";

            var btcTradeDeals = new MainPage(Driver)
                .ClosePopUpWindows()
                .ChooseBitcoinToTrade()
                .FillFormWithRiskSum(riskSum)
                .ChooseDownDeal()
                .GetTrades();

            btcTradeDeals.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void CloseOpenedTradeDeal()
        {
            var closeConfirmationMessage = new MainPage(Driver)
                .ClosePopUpWindows()
                .CloseTradeDeal()
                .ConfirmCloseTradeDeal()
                .GetCloseDealConfirmation();

            closeConfirmationMessage.Should().NotBeNull();
        }

        [Fact]
        public void CreateUpBTCTradeDealWithInsufficientAmountOfFundsOnAccount()
        {
            string riskSum = "3000";

            var insufficientBalanceWarningMessage = new MainPage(Driver)
                .ClosePopUpWindows()
                .ChooseBitcoinToTrade()
                .FillFormWithRiskSum(riskSum)
                .ChooseUpDeal()
                .GetInsufficientBalanceWarningMessage();

            insufficientBalanceWarningMessage.Should().NotBeNull();
        }

        [Fact]
        public void CreateDownBTCTradeDealWithInsufficientAmountOfFundsOnAccount()
        {
            string riskSum = "3000";

            var insufficientBalanceWarningMessage = new MainPage(Driver)
                .ClosePopUpWindows()
                .ChooseBitcoinToTrade()
                .FillFormWithRiskSum(riskSum)
                .ChooseDownDeal()
                .GetInsufficientBalanceWarningMessage();

            insufficientBalanceWarningMessage.Should().NotBeNull();
        }

        [Fact]
        public void ModifyOpenedTradeDeal()
        {
            string payOutTargetRate = "38000";

            var successfulTradeDealModifiedMessage = new MainPage(Driver)
                .ClosePopUpWindows()
                .ModifyOpenedTradeDeal()
                .EnterPayOutTargetRate(payOutTargetRate)
                .AcceptModifyOpenedTradeDeal()
                .GetSuccessfulTradeDealModifiedMessage();

            successfulTradeDealModifiedMessage.Should().NotBeNull();
        }
    }
}
