using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_for_HBAR.BaseMethod
{
    [TestClass]
    public class AutomationCore
    {
        public static ExtentTest test;
        public static ExtentReports extent;
 
        UseText OI = new UseText();
        [TestInitialize()]
        public void StartTest() // This method will be fired at the start of the test
        {
            string windir = System.IO.Path.GetPathRoot(Environment.SystemDirectory);
            string directory = windir + "Automation Logs\\Logs_" + DateTime.Now.ToString("MMM dd, yyyy - hh.mm.sstt") + ".txt";
            OI.TextDirectoryFileName(@directory);
            OI.TextAppend("");
            OI.TextAppend("---------------------- " + DateTime.Now.ToString("MMM/dd/yyyy hh:mm:sstt") + " ---------------------- ");
            OI.TextAppend("---------------------- Execution Start ----------------------");
          
            Browsers.Init();
        }

        [TestCleanup]
        public void EndTest() // This method will be fired at the end of the test
        {
            extent.Flush();
            OI.TextAppend("---------------------- " + DateTime.Now.ToString("MMM/dd/yyyy hh:mm:sstt") + " ---------------------- ");
            OI.TextAppend("---------------------- End of Execution ----------------------");
            Browsers.Close();
        }

    }
}
