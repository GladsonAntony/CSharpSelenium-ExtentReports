using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System.Runtime.InteropServices;

namespace CSharpSeleniumExtent.src.main.net.Core
{
    public class InitializeMethod
    {
        //Initialize Thread Safe Iwebdriver Instance
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //Initialize Javascript Executor
        public static IJavaScriptExecutor javaScriptExecutor;

        //Get the Browser Name from the App.Config File
        public static String ConfigBrowserName = TestContext.Parameters["Browser"];

        //Initialize Extent Reports
        public static ExtentReports extentReports;
        [ThreadStatic]
        public static ExtentTest extentTest;
        public static ExtentHtmlReporter htmlReporter;


        //Get Hardware Info
        public static String OSVersion = Environment.OSVersion.ToString();
        public static String OSDescription = RuntimeInformation.OSDescription;
        public static String OSArchitecture = RuntimeInformation.OSArchitecture.ToString();
        public static String MachineName = Environment.MachineName.ToString();

        //To Get and Set Paths
        public static String WorkingDirectory = Environment.CurrentDirectory;
        public static String ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
        public static String ReportPath = ProjectDirectory + "/src/test/resources/Reports/";
        public static String TestDataPath = ProjectDirectory + "/src/test/resources/TestData/";
        public static String ScreenshotPath = ProjectDirectory + "/src/test/resources/Screenshots/";
    }
}
