using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using WebDriverTest.Utilities;

namespace WebDriverTest.Pages
{
    public class MainPage : BasePage
    {
        private readonly WebDriverWait wait;

        private readonly By demoTradingConfirmButton = By.XPath("//*[@class='btn btn-primary btn-block btn-xl']");
        private readonly By btcChooseButton = By.XPath("//tbody[@data-cabinet-name='Favorites']//tr[@data-symbol='BTCUSD']");
        private readonly By riskInput = By.Id("txtUsvRisk");
        private readonly By upDealButton = By.XPath("//*[@class='btn btn-trade btn-block btn-buy btn-buy-easytrade']");
        private readonly By downDealButton = By.XPath("//*[@class='btn btn-trade btn-block btn-sell btn-sell-easytrade']");
        private readonly By trades = By.ClassName("trade-info-symbol");
        private readonly By closeTradeDealButton = By.XPath("//*[@class='close-deal btn btn-sm btn-block mb-2 btn-pl btn-rounded value btn-success-down']");
        private readonly By closeTradeDealConfirmButton = By.XPath("//*[@class='btn btn-close-deal w-100 btn-success-down']");
        private readonly By closedTradeDealMessage = By.XPath("//*[@class='tym-deal-id' and contains(text(), 'successfully closed')]");
        private readonly By insufficientBalanceMessage = By.XPath("//*[@class='modal-body' and contains(text(), 'Sorry')]");
        private readonly By modifyOpenedTradeDealButton = By.XPath("//*[@class='btn btn-sm btn-outline-secondary mb-2 btn-modify-deal btn-rounded']");
        private readonly By payOutTargetRateInput = By.XPath("//*[@class='ticket-modify-deal-input-rate form-control ui-spinner-input']");
        private readonly By acceptModifyTradeDealButton = By.XPath("//*[@class='btn btn-success-up ticket-modify-deal-btn-accept']");
        private readonly By successfulTradeDealModifiedMessage = By.XPath("//*[@class='tym-deal-transaction' and contains(text(), 'successfully modified')]");
        
        public MainPage(IWebDriver driver) : base(driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public MainPage ClosePopUpWindows()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(demoTradingConfirmButton));
            wait.Until(ExpectedConditions.ElementToBeClickable(demoTradingConfirmButton));
            Driver.FindElement(demoTradingConfirmButton).Click();

            Log.Info("Pop up windows closed");

            return this;
        }

        public MainPage ChooseBitcoinToTrade()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(btcChooseButton));
            wait.Until(ExpectedConditions.ElementToBeClickable(btcChooseButton));
            Driver.FindElement(btcChooseButton).Click();

            Log.Info("Bitcoin is chosen as trade target");

            return this;
        }

        public MainPage FillFormWithRiskSum(string riskSum)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(riskInput));
            Driver.FindElement(riskInput).Clear();
            Driver.FindElement(riskInput).SendKeys(riskSum);

            Log.Info($"Entered risk sum: {riskSum}");

            return this;
        }

        public MainPage ChooseUpDeal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(upDealButton));
            Driver.FindElement(upDealButton).Click();

            Log.Info("Deal type is chosen as Up");

            return this;
        }

        public MainPage ChooseDownDeal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(downDealButton));
            Driver.FindElement(downDealButton).Click();

            Log.Info("Deal type is chosen as Down");

            return this;
        }

        public MainPage CloseTradeDeal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(closeTradeDealButton));
            Driver.FindElement(closeTradeDealButton).Click();

            Log.Info("Deal is chosen to be closed");

            return this;
        }

        public MainPage ConfirmCloseTradeDeal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(closeTradeDealConfirmButton));
            Driver.FindElement(closeTradeDealConfirmButton).Click();

            Log.Info("Confirm closing deal");

            return this;
        }

        public MainPage ModifyOpenedTradeDeal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(modifyOpenedTradeDealButton));
            Driver.FindElement(modifyOpenedTradeDealButton).Click();

            Log.Info("Deal is chosen to be modified");

            return this;
        }

        public MainPage EnterPayOutTargetRate(string payOutTargetRate)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(payOutTargetRateInput));
            wait.Until(ExpectedConditions.ElementToBeClickable(payOutTargetRateInput));
            Driver.FindElement(payOutTargetRateInput).Clear();
            Driver.FindElement(payOutTargetRateInput).SendKeys(payOutTargetRate);

            Log.Info($"Entered payout target rate: {payOutTargetRate}");

            return this;
        }

        public MainPage AcceptModifyOpenedTradeDeal()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(acceptModifyTradeDealButton));
            Driver.FindElement(acceptModifyTradeDealButton).Click();

            Log.Info("Deal modifying accepted");

            return this;
        }

        public IReadOnlyCollection<IWebElement> GetTrades()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(trades));

            return Driver.FindElements(trades);
        }

        public IWebElement GetCloseDealConfirmation()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(closedTradeDealMessage));

            return Driver.FindElement(closedTradeDealMessage);
        }

        public IWebElement GetInsufficientBalanceWarningMessage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(insufficientBalanceMessage));

            return Driver.FindElement(insufficientBalanceMessage);
        }

        public IWebElement GetSuccessfulTradeDealModifiedMessage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(successfulTradeDealModifiedMessage));

            return Driver.FindElement(successfulTradeDealModifiedMessage);
        }
    }
}
