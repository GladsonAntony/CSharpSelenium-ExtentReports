using CSharpSeleniumExtent.src.main.net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtent.src.main.net.Utilities
{
    public class ExtentReporter : InitializeMethod
    {
        public static void EndExtentReporting()
        {
            extentReports.Flush();
        }

        public static void LogInfo(String InfoMessage)
        {
            extentTest.Info(InfoMessage);
        }

        public static void LogPass(String PassMessage)
        {
            extentTest.Pass(PassMessage);
        }

        public static void LogFail(String FailMessage)
        {
            extentTest.Fail(FailMessage);
        }
    }
}
