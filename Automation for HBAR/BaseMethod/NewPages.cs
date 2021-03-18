using Automation_for_HBAR.Pages;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_for_HBAR.BaseMethod
{
    public static class NewPages
    {
        private static T GetPages<T>() where T : new()
        {
            var page = new T();
            // SeleniumExtras.PageObjects.PageFactory.InitElements
            PageFactory.InitElements(Browsers.GetDriver, page);
            return page;
        }

        public static Step1 NewStep1Page
        {
            get { return GetPages<Step1>(); }
        }

        public static Step2 NewStep2Page
        {
            get { return GetPages<Step2>(); }
        }

        public static Step3 NewStep3Page
        {
            get { return GetPages<Step3>(); }
        }

        public static Step5 NewStep5Page
        {
            get { return GetPages<Step5>(); }
        }

        public static QuotesResult NewQuotesResultPage
        {
            get { return GetPages<QuotesResult>(); }
        }
       
    }
}
