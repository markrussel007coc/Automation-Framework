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
    public class Step1:BaseTest
    {

        IWebDriver newWebDriver = Browsers.GetDriver;

        private IWebElement CoverType
        {
            get { return newWebDriver.FindElement(By.XPath("//input[@class='vs__search']")); }
        }

        private IWebElement PostCode
        {
            get { return newWebDriver.FindElement(By.Id("inputPostCode")); }
        }

        private IWebElement NextButton
        {
            get { return newWebDriver.FindElement(By.CssSelector("#btn_submit_next")); }
        }

        public void SelectCoverType(string type)
        {
            ClickElement(CoverType);
              

            switch (type)
            {
                case "Single":
                    newWebDriver.FindElement(By.Id("drpdwn_coveroptions_single")).Click();
                    break;
                case "Couple":
                    newWebDriver.FindElement(By.Id("drpdwn_coveroptions_couple")).Click();
                    break;
                case "Family":
                    newWebDriver.FindElement(By.Id("drpdwn_coveroptions_family")).Click();
                    break;
                case "Single Parent Family":
                    newWebDriver.FindElement(By.Id("drpdwn_coveroptions_singleparent")).Click();
                    break;
          
            }
  
        }

        public void FillUpFormStep1(string type, string postcode)
        {
            var wait = new WebDriverWait(newWebDriver, TimeSpan.FromSeconds(60));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//input[@class='vs__search']")));

            SelectCoverType(type);
            EnterText(PostCode, postcode);
            TakeScreenshot("");
            ClickElement(NextButton);
          
        }
    }

}

