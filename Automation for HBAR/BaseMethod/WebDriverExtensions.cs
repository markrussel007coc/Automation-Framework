using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_for_HBAR.BaseMethod
{
    public static class WebDriverExtensions
    {
        public static bool TryFindElement(this IWebDriver driver, By by, out IWebElement element)
        {
            try
            {
                element = driver.FindElement(by);
                return true;
            }
            catch (WebDriverException)
            {
                element = null;
                return false;
            }
        }

        public static bool IsElementEnabled(this IWebDriver driver, By by)
        {


            if (driver.TryFindElement(by, out IWebElement element))
            {
                return element.Enabled;
            }

            return false;
        }

        public static bool TryFindElement2(this IWebDriver driver, By by, out IWebElement element, int seconds)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
                element = driver.FindElement(by);

                return true;
            }
            catch (WebDriverException)
            {
                element = null;
                return false;
            }
        }
    }
}
