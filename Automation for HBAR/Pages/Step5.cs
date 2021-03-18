using Automation_for_HBAR.BaseMethod;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation_for_HBAR.Pages
{
    public class Step5:BaseTest
    {

        IWebDriver newWebDriver = Browsers.GetDriver;

        private IWebElement Name
        {
            get { return newWebDriver.FindElement(By.CssSelector("#__layout #first_name")); }
        }

        private IWebElement PhoneNumber
        {
            get { return newWebDriver.FindElement(By.Id("phone")); }
        }

        private IWebElement EmailAddress
        {
            get { return newWebDriver.FindElement(By.Id("email")); }
        }

        private IWebElement ShowMyQuotesButton
        {
            get { return newWebDriver.FindElement(By.CssSelector("#btn_submit")); }
        }


        public void FillUpFormStep5(string name, string phone, string email)
        {

            var wait = new WebDriverWait(newWebDriver, TimeSpan.FromSeconds(60));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("first_name")));
         
            EnterText(Name, name);
            EnterText(PhoneNumber, phone);
            EnterText(EmailAddress, email);
            TakeScreenshot("");
            ClickElement(ShowMyQuotesButton);   
        }

    }
}

