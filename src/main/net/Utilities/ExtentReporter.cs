using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using CSharpSeleniumExtent.src.main.net.Core;
using AventStack.ExtentReports.Reporter.Configuration;

namespace CSharpSeleniumExtent.src.main.net.Utilities
{
    public class ExtentReporter : BrowserFactory
    {
        public static void SetupExtentReporting()
        {
            htmlReporter = new ExtentHtmlReporter(ReportPath);
            htmlReporter.Config.ReportName = "Extent Report - Selenium-NUnit";
            htmlReporter.Config.Theme = Theme.Dark;
            htmlReporter.Config.Encoding = "utf-8";
            htmlReporter.Config.CSS = "css-string";
            htmlReporter.Config.DocumentTitle = "Extent Report - Selenium-NUnit";
            htmlReporter.Config.EnableTimeline = true;
            htmlReporter.Config.JS = "js-string";
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            extentReports.AddSystemInfo("Username", "Gladson Antony");
            extentReports.AddSystemInfo("Machine Name", MachineName);
            extentReports.AddSystemInfo("OS Version", OSVersion);
            extentReports.AddSystemInfo("OS Description", OSDescription);
            extentReports.AddSystemInfo("OS Architecture", OSArchitecture);
        }

        public static void ExtentCreateTest() => extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);


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

        public static void EndExtentReporting()
        {
            extentReports.Flush();
        }
    }
}