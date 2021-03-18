using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Automation_for_HBAR.BaseMethod
{
    public class BaseTest
    {

        IWebDriver driver = Browsers.GetDriver;

        //Variables for TakeScreenshot()
        private string filePath;
        private string fileName;
        private string fileNameraw;
        private string fileNameraw2;
        private string Path;
        private DateTime date;
        private string finaldate;

        public void TakeScreenshot(string param)
        {
            date = DateTime.Now;

            string rawmonth = DateTime.Now.ToString("MM");
            string rawday = DateTime.Now.ToString("dd");
            string rawyear = DateTime.Now.ToString("yyyy");
            string rawhour = DateTime.Now.ToString("hh");
            string rawminutes = DateTime.Now.ToString("mm");
            string rawseconds = DateTime.Now.ToString("ss");

            finaldate = rawmonth + "-" + rawday + "-" + rawyear;
            fileNameraw = finaldate + "\\Test Result Screenshot\\" + DateTime.Now.ToString("hhtt") +"\\";
            fileNameraw2 = finaldate + "\\Test Result Screenshot\\" + DateTime.Now.ToString("hhtt") +"\\";
            fileName = fileNameraw + param + "_Screenshot_" + rawhour + "." + rawminutes + "." + rawseconds;

            string newFolder = "Automation Folder";
            string desktoppath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), newFolder);

            filePath = desktoppath + "\\" + fileName + ".png";
            Path = desktoppath + "\\" + fileNameraw;

            if (!Directory.Exists(Path)) Directory.CreateDirectory(Path);

            var location = desktoppath + "\\" + fileName + ".png";
            var ssdriver = driver as ITakesScreenshot;
            Thread.Sleep(1000);
            var screenshot = ssdriver.GetScreenshot();
            screenshot.SaveAsFile(location);    
        }

        static Microsoft.Office.Interop.Excel.Application xlApp;
        static Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
        static Microsoft.Office.Interop.Excel._Worksheet xlWorksheet;
        static Microsoft.Office.Interop.Excel.Range xlRange;
        static String ExcelCell;

        public void XLSetWorkbookSource(String strSource)
        {
            String user = Environment.UserName;
            String project = Assembly.GetAssembly(typeof(Program)).ToString();
            String projectname = project;
            projectname = projectname.Substring(0, projectname.IndexOf(","));
            //String path = "C:\\Users\\" + user + "\\source\\repos\\" + projectname + "\\" + projectname + "\\TestData\\" + strSource;

            string filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), strSource);

            string trimpath = filePath.Substring(0, filePath.LastIndexOf("bin"));
            var valuepathraw = trimpath + "TestData" + "/" + strSource;
            String valuepath = @valuepathraw;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkbook = xlApp.Workbooks.Open(@valuepath);
        }

        /// <summary>
        /// Specify the worksheet that will be used for writing or reading.
        /// </summary>
        /// <param name="strWorkSheet"></param>
        public void XLSetWorkSheet(String strWorkSheet)
        {
            xlWorksheet = xlWorkbook.Worksheets[strWorkSheet];
            xlRange = xlWorksheet.UsedRange;
        }

        /// <summary>
        /// Retrieve the cell value of the specified worksheet based on row and column location.
        /// </summary>
        /// <param name="rowNum"></param>
        /// <param name="colNum"></param>
        /// <returns></returns>
        /// 
        public UseText OI = new UseText();
        public String XLGetCellValue(int rowNum, int colNum)
        {

            Type type = xlRange.Cells[rowNum, colNum].value.GetType();
            if (type == typeof(Double))
            {
                double temp = xlRange.Cells[rowNum, colNum].value;
                ExcelCell = temp.ToString();
            }
            if (type == typeof(String))
            {
                String temp = xlRange.Cells[rowNum, colNum].value;
                ExcelCell = temp.ToString();
            }
            OI.TextAppend("USEEXCEL (DATATYPE): " + type);
            return ExcelCell;
        }

        /// <summary>
        /// Assign a cell value to the specified worksheet based on row and column location.&#13;
        /// This will save the workbook automatically.
        /// </summary>
        /// <param name="rowNum"></param>
        /// <param name="colNum"></param>
        /// <param name="newValue"></param>
        public void XLSetCellValue(int rowNum, int colNum, string newValue)
        {
            xlRange.Cells[rowNum, colNum].Value = newValue;
            xlRange.Columns.AutoFit();
            xlWorkbook.Save();
        }

        /// <summary>
        /// Close the instance of the excel file opened.
        /// </summary>
        public void XLEndUseExcel()
        {
            xlWorkbook.Close();
            xlApp.Quit();
        }
        public void WriteinXMLFile(string TestDataFileName, string elementname, string attributename, string attributevalue)
        {


            string filePath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), TestDataFileName);

            string trimpath = filePath.Substring(0, filePath.LastIndexOf("bin"));
            var valuepathraw = trimpath + "TestData" + "\\" + TestDataFileName;
            String valuepath = @valuepathraw;
            //var doc = XDocument.Load(valuepath);
            XElement xe = XElement.Load(valuepath);
            XElement oldnode = xe.Element(elementname);
            oldnode.SetAttributeValue(attributename, attributevalue);
            xe.Save(valuepath);
        }

        public void ClickElement(IWebElement element)
        {
            string elementname = element.Text;
            string elementvalue = element.GetAttribute("value");
            string elementtype = element.GetAttribute("type");

            if (elementname != "" & elementvalue == null)
            {
                OI.TextAppend("Clicked Link/Button: " + elementname);
                Console.WriteLine("Clicked Link/Button: " + elementname);
            }
            else if (elementname == "" & elementvalue != "" & elementvalue != null)
            {
                OI.TextAppend("Clicked Link/Button: " + elementvalue);
                Console.WriteLine("Clicked Link/Button: " + elementvalue);
            }
            else if (elementname != "" & elementvalue !=null)
            {
                OI.TextAppend("Clicked Link/Button: " + elementname);
                Console.WriteLine("Clicked Link/Button: " + elementname);
            }
            else
            {
                if(elementtype.Equals("file"))
                {
                    OI.TextAppend("Clicked Choose File");
                    Console.WriteLine("Clicked Choose File");
                }
                else
                {
                    OI.TextAppend("Clicked Link/Button");
                    Console.WriteLine("Clicked Link/Button");
                }
                                
            }
           
            element.Click();

        }

        public void EnterText(IWebElement element, string testdata)
        {
            element.Clear();
            element.SendKeys(testdata);
            OI.TextAppend("Entered value: " + testdata);
            Console.WriteLine("Entered value: " + testdata);
        }

        public void GetTextValue(IWebElement element, out string value)
        {

            value = element.Text;
            OI.TextAppend("Returned value: " + value);
            Console.WriteLine("Returned value: " + value);

        }

        public void SelectElementDropdownByText(IWebElement element, string testdata)
        {
            var selectElement = new SelectElement(element);
            selectElement.SelectByText(testdata);
            OI.TextAppend("Selected value: " + testdata);
            Console.WriteLine("Selected value: " + testdata);

        }
        public void TickUntickCheckbox(IWebElement element, string testdata)
        {
            string value = element.GetAttribute("name");
            if (testdata.Equals("Tick"))
            {


                if (element.Selected)
                {
                    Console.WriteLine(value + " is already ticked");
                    OI.TextAppend(value+" is already ticked");
                }
                else
                {
                    element.Click();
                    Console.WriteLine(value + " is ticked");
                    OI.TextAppend(value + " is ticked");
                }
            }
            else if (testdata.Equals("Untick"))
            {
                if (!element.Selected)
                {
                    Console.WriteLine(value + " is already unticked");
                    OI.TextAppend(value + " is already unticked");
                }
                else
                {
                    element.Click();
                    Console.WriteLine(value + " is unticked");
                    OI.TextAppend(value + " ss already unticked");
                }
            }
            else
            {
                Assert.Fail("Check Value of test data");
            }

        }

        public void SelectDeselectRadio(IWebElement element, string testdata)
        {
            if (testdata.Equals("Select"))
            {
                if (element.Selected)
                {
                    OI.TextAppend("Element is already selected");
                }
                else
                {
                    element.Click();
                }
            }
            else if (testdata.Equals("Deselect"))
            {
                if (!element.Selected)
                {
                    OI.TextAppend("Element is already deselected");
                }
                else
                {
                    element.Click();
                }
            }
            else
            {
                Assert.Fail("Check Value of test data");
            }

        }

        public void DeleteFile(string fileToDeleteWithPath)
        {
            // Delete a file by using DeleteFile method...
            if (System.IO.File.Exists(@fileToDeleteWithPath))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(@fileToDeleteWithPath);
                    OI.TextAppend("Successfully deleted the file" + fileToDeleteWithPath);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    OI.TextAppend(e.Message.ToString());
                    return;
                }
            }
        }

        public void scrolldown(int times)
        {
            for (int i=1; i<=times; i++)
            {
                Thread.Sleep(1000);
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            js.ExecuteScript("window.scrollTo(0,300)");
            }
        }

        public void ScrollToElement(IWebElement element)
        {
        
            Actions action = new Actions(driver);
            action.MoveToElement(element);
            action.Perform();

        }

    }
}
