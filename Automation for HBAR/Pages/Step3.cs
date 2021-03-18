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
    public class Step3:BaseTest
    {

        IWebDriver newWebDriver = Browsers.GetDriver;

        private IWebElement NextButton
        {
            get { return newWebDriver.FindElement(By.CssSelector("button.btn.search--btn.btn-secondary")); }
        }

        public void ClickNext()
        {
            TakeScreenshot("");
            ScrollToElement(NextButton);
            ClickElement(NextButton);
           
        }

    }
}

