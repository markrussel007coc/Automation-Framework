using Automation_for_HBAR.BaseMethod;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class QuotesResult : BaseTest
    {
        IWebDriver newWebDriver = Browsers.GetDriver;
    
        public void verifyURL()
        {
            string weburl = newWebDriver.Url;
            OI.TextAppend("url:" + weburl);
            if (!weburl.Contains("/quotes-results/"))
            {
                Assert.Fail("URL is incorrect");
            }
        }
        public void VerifyPopUp()
        {
            //pop up for After hours call
            newWebDriver.TryFindElement2(By.XPath("//header[contains(@id, __BVID__)]"), out IWebElement elementfound, 5000);
            if (elementfound == null)
            {
                OI.TextAppend("Popup message for after hours call was not displayed");
            }
            else
            {
                TakeScreenshot("");
                newWebDriver.FindElement(By.CssSelector(".btn.btn-link.d-block")).Click();
                OI.TextAppend("Popup message for after hours call was displayed");
            }
        }

        private IWebElement ChangeMyPolicyOptionsHereButton
        {
            get { return newWebDriver.FindElement(By.XPath("//button[text()='Change my policy options here']")); }
        }

        private IWebElement HospitalSlider
        {
            get { return newWebDriver.FindElement(By.CssSelector(".hic-form__options #hospitals_slider .range-slider-knob")); }
        }

        private IWebElement ExtrasSlider
        {
            get { return newWebDriver.FindElement(By.CssSelector(".hic-form__options #extras_slider .range-slider-knob")); }
        }

        private IWebElement ProductId1
        {
            get { return newWebDriver.FindElement(By.CssSelector("#product0_id")); }
        }
        private IWebElement ProductId2
        {
            get { return newWebDriver.FindElement(By.CssSelector("#product1_id")); }
        }

        private IWebElement ProductId3
        {
            get { return newWebDriver.FindElement(By.CssSelector("#product2_id")); }
        }

        private IWebElement OtherPlans
        {
            get { return newWebDriver.FindElement(By.CssSelector(".container > .hic-form__result--other")); }
        }

        private IWebElement YourAge65To69
        {
            get { return newWebDriver.FindElement(By.CssSelector("#your_age_65to69")); }
        }

        private IWebElement YourAge65Less
        {
            get { return newWebDriver.FindElement(By.CssSelector("#your_age_under65")); }
        }

        private IWebElement HospitalGold
        {
            get { return newWebDriver.FindElement(By.Id("hospitals_gold")); }
        }


        public void ClickChangeMyPolicyOptions()
        {

            Thread.Sleep(5000);
            
            ClickElement(ChangeMyPolicyOptionsHereButton);
        }
      
        public void SelectHospitalSliderValue(string value)
        {
           IJavaScriptExecutor js = newWebDriver as IJavaScriptExecutor;
           IWebElement sliderfill = newWebDriver.FindElement(By.CssSelector("#hospitals_slider .range-slider-fill"));
           IWebElement sliderknob = newWebDriver.FindElement(By.CssSelector("#hospitals_slider .range-slider-knob"));

           Thread.Sleep(5000);
           Actions action = new Actions(newWebDriver);
                      
           switch (value)
           {
           case "Nil":
               action.DragAndDropToOffset(sliderknob, 0, 0).Release().Build();
               action.Perform();
               break;
           case "Basic":
               action.DragAndDropToOffset(sliderknob, 60, 0).Release().Build();
               action.Perform();
               break;
           case "Bronze":
               action.DragAndDropToOffset(sliderknob, 120, 0).Release().Build();
               action.Perform();
               break;
           case "Silver":
               action.DragAndDropToOffset(sliderknob, 180, 0).Release().Build();
               action.Perform();
               break;
           case "Gold":
               action.DragAndDropToOffset(sliderknob, 240, 0).Release().Build();
               action.Perform();
               break;
           default:
               js.ExecuteScript("arguments[0].style='width: 0%;'", sliderfill);
               js.ExecuteScript("arguments[0].style='left: 0%;'", sliderknob);
               break;
           }        
        }


        public void SelectExtrasSliderValue(string value)
        {           
            IJavaScriptExecutor js = newWebDriver as IJavaScriptExecutor;
            IWebElement sliderknob = newWebDriver.FindElement(By.CssSelector("#extras_slider .range-slider-knob"));
            Thread.Sleep(5000);
            Actions action = new Actions(newWebDriver);
          
            switch (value)
            {
                case "Nil":
                    action.DragAndDropToOffset(sliderknob, 0, 0).Release().Build();
                    action.Perform();
                    break;
                case "Low":
                    action.DragAndDropToOffset(sliderknob, 80, 0).Release().Build();
                    action.Perform();
                    break;
                case "Medium":
                    action.DragAndDropToOffset(sliderknob, 160, 0).Release().Build();
                    action.Perform();
                    break;
                case "High":
                    action.DragAndDropToOffset(sliderknob, 240, 0).Release().Build();
                    action.Perform();
                    break;
                default:
                    action.DragAndDropToOffset(sliderknob, 0, 0).Release().Build();
                    action.Perform();
                    break;
            }

     
        }
  

        public void VerifyDisplayedProducts()
        {
            Thread.Sleep(2000);
       
            Thread.Sleep(2000);

            ScrollToElement(OtherPlans);

            string product_value1 = ProductId1.Text;         
            string product_value2 = ProductId2.Text;
            string product_value3 = ProductId3.Text;

            TakeScreenshot("");

            if (!product_value1.Contains("11597") & !product_value2.Contains("16501") & !product_value3.Contains("12845"))
            {
                Assert.Fail("Displayed Products are incorrect");

            }
            else
            {
                OI.TextAppend("Product: "+ product_value1+" is displayed. ");
                OI.TextAppend("Product: " + product_value2 + " is displayed. ");
                OI.TextAppend("Product: " + product_value3 + " is displayed. ");
            }
        }
    }
}

