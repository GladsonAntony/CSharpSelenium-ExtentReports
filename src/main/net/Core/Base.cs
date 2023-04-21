using OpenQA.Selenium;
using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using CSharpSeleniumExtent.src.main.net.Utilities;

namespace CSharpSeleniumFramework.src.main.net.Core
{
    [Author("Gladson Antony")]
    [Description("Contains the Base Class")]
    public class Base : ExtentReporter
    {

        [OneTimeSetUp]
        public void OneTimeSetup() 
        {
            SetupExtentReporting();
        }

        [OneTimeTearDown]
        public void OneTimeTeardown() 
        {
            EndExtentReporting();
        }

        [SetUp]
        public void SetupBrowser()
        {
            ExtentCreateTest();
            if (ConfigBrowserName == null)
            {
                ConfigBrowserName = ConfigurationManager.AppSettings["Browser"];
            }
            InitBrowser(ConfigBrowserName);
            GetDriver().Manage().Window.Maximize();
            GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            GetDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);
            TestContext.WriteLine("Title of the Webpage " + driver.Value.Title);
        }


        public MediaEntityModelProvider CaptureScreenShotASBase64(IWebDriver driver, string ScreenshotName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            var CapturedScreenshot = screenshot.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(CapturedScreenshot, ScreenshotName).Build();
        }

        public static string CaptureScreenShot(IWebDriver driver, string ScreenshotName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot screenshot1 = screenshot.GetScreenshot();
            var localpath = ScreenshotPath + ScreenshotName;
            var finalpath = new Uri(localpath).LocalPath;
            screenshot1.SaveAsFile(ScreenshotPath, ScreenshotImageFormat.Png);
            return finalpath;
        }


        [TearDown]
        public void Teardown()
        {
            var Status = TestContext.CurrentContext.Result.Outcome.Status;
            var StackTrace = TestContext.CurrentContext.Result.StackTrace;

            DateTime dateTime = DateTime.Now;
            string fileName = "Screenshot_" + dateTime.ToString("hh_mm_ss") + ".png";

            if (Status == TestStatus.Failed)
            {
                extentTest.Fail("Test Failed", CaptureScreenShotASBase64(GetDriver(), fileName));
                CaptureScreenShot(GetDriver(), TestContext.CurrentContext.Test.Name);
                extentTest.Log(AventStack.ExtentReports.Status.Fail, "Test Failed with Logtrace" + StackTrace);
            }
            else if (Status == TestStatus.Passed)
            {
                extentTest.Pass("Test Passed");
            }
            else if (Status == TestStatus.Skipped)
            {
                extentTest.Skip("Test Skipped");
            }
            GetDriver().Quit();
        }
    }
}