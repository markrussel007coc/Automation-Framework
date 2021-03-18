using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_for_HBAR.BaseMethod
{
    class Browsers
    {
        private static IWebDriver webDriver;
        private static string baseURL = ConfigurationManager.AppSettings["url"];
        private static string browser = ConfigurationManager.AppSettings["browser"];

        public static void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "IE":
                    webDriver = new InternetExplorerDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
            }
            webDriver.Manage().Window.Maximize();
       
            //Goto(baseURL);
            Goto("https://healthinsurancecomparison.com.au/form/step1/?utm_source=trial-task&utm_medium=trial-task&utm_campaign=trial-task&utm_content=trial-task&utm_term=trial-task&is_bypass=1");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public static string Title
        {
            get { return webDriver.Title; }
        }

        public static string WebsiteURL
        {
            get { return webDriver.Url; ; }
        }

        public static IWebDriver GetDriver
        {
            get { return webDriver; }
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
         
        }

        public static void QuitBrowser()
        {

            switch (browser)
            {
                case "Chrome":
                    {
                        Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");
                        Process[] chromeInstances = Process.GetProcessesByName("chrome");
                        foreach (var chromeDriverProcess in chromeDriverProcesses)
                        {
                            chromeDriverProcess.Kill();
                        }

                        foreach (Process p in chromeInstances)
                            p.Kill();
                    }
                    break;
                case "IE":
                    {
                        Process[] internetExplorerProcesses = Process.GetProcessesByName("InternetExplorerDriver");
                        Process[] IEInstances = Process.GetProcessesByName("iexplorer");
                        foreach (var internetExplorerProcess in internetExplorerProcesses)
                        {
                            internetExplorerProcess.Kill();
                        }

                        foreach (Process p in IEInstances)
                            p.Kill();
                    }
                    break;
                case "Firefox":
                    {
                        Process[] FirefoxProcesses = Process.GetProcessesByName("FirefoxDriver");
                        Process[] FirefoxInstances = Process.GetProcessesByName("firefox");
                        foreach (var FirefoxProcess in FirefoxProcesses)
                        {
                            FirefoxProcess.Kill();
                        }

                        foreach (Process p in FirefoxInstances)
                            p.Kill();

                    }
                    break;
            }
        }

        public static void Close()
        {
            webDriver.Quit();
            switch (browser)
            {
                case "Chrome":
                    {
                        Process[] chromeDriverProcesses = Process.GetProcessesByName("chromedriver");

                        foreach (var chromeDriverProcess in chromeDriverProcesses)
                        {
                            chromeDriverProcess.Kill();
                        }
                    }
                    break;
                case "IE":
                    {
                        Process[] internetExplorerProcesses = Process.GetProcessesByName("InternetExplorerDriver");

                        foreach (var internetExplorerProcess in internetExplorerProcesses)
                        {
                            internetExplorerProcess.Kill();
                        }
                    }
                    break;
                case "Firefox":
                    {
                        Process[] FirefoxProcesses = Process.GetProcessesByName("FirefoxDriver");

                        foreach (var FirefoxProcess in FirefoxProcesses)
                        {
                            FirefoxProcess.Kill();
                        }
                    }
                    break;
            }
        }
      
    }
}
