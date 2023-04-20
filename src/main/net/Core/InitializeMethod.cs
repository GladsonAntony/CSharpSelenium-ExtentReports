using AventStack.ExtentReports;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using System.Runtime.InteropServices;

namespace CSharpSeleniumExtent.src.main.net.Core
{
    public class InitializeMethod
    {
        //Initialize Thread Safe Iwebdriver Instance
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //Get the Browser Name from the App.Config File
        public static String ConfigBrowserName;

        //Initialize Extent Reports
        public static ExtentReports extentReports;
        public static ExtentTest extentTest;


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
    }
}
