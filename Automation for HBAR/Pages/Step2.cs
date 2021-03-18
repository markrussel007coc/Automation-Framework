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
    public class Step2:BaseTest
    {

        IWebDriver newWebDriver = Browsers.GetDriver;

        private IWebElement MyAge
        {
            get { return newWebDriver.FindElement(By.Id("age")); }
        }

        private IWebElement MyCurrentHealthFund
        {
            get { return newWebDriver.FindElement(By.XPath("//input[@class='vs__search']")); }
        }

        private IWebElement NextButton
        {
            get { return newWebDriver.FindElement(By.CssSelector("#btn_submit_next")); }
        }

        public void SelectMyCurrentHealthFund(string type)
        {
            ClickElement(MyCurrentHealthFund);

            if (type.Equals("I don't currently have a fund"))
            {
                IWebElement element = newWebDriver.FindElement(By.XPath("//*[contains(text(),'currently have a fund')]"));
                ScrollToElement(element);
                ClickElement(element);
            }
            else
            {
                IWebElement element2 = newWebDriver.FindElement(By.XPath("//*[text()='"+ type + "']"));
                ScrollToElement(element2);
                ClickElement(element2);
            }
            

        }

        public void FillUpFormStep2(string age, string type)
        {
            var wait = new WebDriverWait(newWebDriver, TimeSpan.FromSeconds(60));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='vs__search']")));

            EnterText(MyAge, age);
            SelectMyCurrentHealthFund(type);
            TakeScreenshot("");
            ClickElement(NextButton);
        
        }

    }
}

