using Automation_for_HBAR.BaseMethod;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Automation_for_HBAR.Test
{
    [TestClass]
    public class SmokeTest : AutomationCore
    {
        public TestContext TestContext { get; set; }
        
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\Automation Report\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);
        }

        [TestMethod, TestCategory("Smoke")]

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "TestData\\TestData.xml", "practicalexam", DataAccessMethod.Sequential)]
        public void AutomationDemo()
        {
            test = extent.CreateTest("Test Case #001 Demo");
            test.Log(Status.Info, "Go to URL");
            //UseText OI = new UseText();
            //Get Test Parameters
            String CoverType = Convert.ToString(TestContext.DataRow["covertype"]);
            String PostCode = Convert.ToString(TestContext.DataRow["postcode"]);
            String Age = Convert.ToString(TestContext.DataRow["age"]);
            String CurrentInsurer = Convert.ToString(TestContext.DataRow["currentinsurer"]);
            String Name = Convert.ToString(TestContext.DataRow["name"]);
            String Phone = Convert.ToString(TestContext.DataRow["phone"]);
            String Email = Convert.ToString(TestContext.DataRow["email"]);
            String Hospital = Convert.ToString(TestContext.DataRow["hospital"]);
            String Extras = Convert.ToString(TestContext.DataRow["extras"]);
           
            //Actual Test
            using (IWebDriver newWebDriver = Browsers.GetDriver)
            {
                try
                {
                    NewPages.NewStep1Page.FillUpFormStep1(CoverType, PostCode); 
                    NewPages.NewStep2Page.FillUpFormStep2(Age, CurrentInsurer);           
                    NewPages.NewStep3Page.ClickNext();
                    NewPages.NewStep5Page.FillUpFormStep5(Name, Phone, Email);
                    newWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

                    //NewPages.NewQuotesResultPage.VerifyPopUp();

                    newWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    Thread.Sleep(10000);
                    NewPages.NewQuotesResultPage.verifyURL();               
                    newWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    NewPages.NewQuotesResultPage.ClickChangeMyPolicyOptions();
                    NewPages.NewQuotesResultPage.SelectHospitalSliderValue(Hospital);
                    NewPages.NewQuotesResultPage.SelectExtrasSliderValue(Extras);
               
                    newWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    NewPages.NewQuotesResultPage.VerifyDisplayedProducts();
                    test.Log(Status.Info, "Checker");
                }
                    
                catch (Exception e)
                {
                    test.Log(Status.Fail, "Test Fail");
                    throw e;
                }
            }

        }
                     

    }


}