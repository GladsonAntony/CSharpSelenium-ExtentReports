using AventStack.ExtentReports;
using Hardware.Info;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface;
using System.Runtime.InteropServices;

namespace CSharpSeleniumExtent.src.main.net.Core
{
    public class InitalizeMethod
    {
        //Initialize Thread Safe Iwebdriver Instance
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        //Get the Browser Name from the App.Config File
        public static String ConfigBrowserName;

        //Initialize Extent Reports
        public ExtentReports extentReports;
        public ExtentTest extentTest;


        public static IHardwareInfo hardwareInfo = new HardwareInfo(useAsteriskInWMI: false);


        //Get Hardware Info

        public static String OperationSystem = RuntimeInformation.OSDescription;
        public static String OperationSystem1 = Environment.CurrentDirectory;
        public String OperationSystem2;
        public static String OperationSystem3 = RuntimeInformation.OSArchitecture.ToString();
        public static String OperationSystem4 = Environment.MachineName;
        public static String OperationSystem5 = Environment.OSVersion.Platform.ToString();

        Action OSName = () => Console.WriteLine(hardwareInfo.OperatingSystem.Name);



        [Test]
        public void randomTest()
        {
            hardwareInfo.RefreshAll();
            TestContext.WriteLine("Operation System Details: " + OperationSystem);
            TestContext.WriteLine(OperationSystem1);
            TestContext.WriteLine(OperationSystem2);
            TestContext.WriteLine(OperationSystem3);
            TestContext.WriteLine(OperationSystem4);
            TestContext.WriteLine(OperationSystem5);
            TestContext.WriteLine(OSName);
            //Console.WriteLine(OperationSystem2.ToString());
            Console.WriteLine(hardwareInfo.OperatingSystem.Name.ToString());
            //Console.WriteLine(hardwareInfo.MemoryStatus);
        }        
    }
}
