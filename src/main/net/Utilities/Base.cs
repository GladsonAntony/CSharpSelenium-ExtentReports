using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using CSharpSeleniumFramework.src.test.net.Tests;

namespace CSharpSeleniumFramework.src.main.net.Utilities
{
    public class Base
    {
        public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        string ConfigBrowserName;
        ExtentReports extentReports;
        ExtentTest extentTest;

        [OneTimeSetUp]
        public void Setup()
        {
            string WorkingDirectory = Environment.CurrentDirectory;
            Console.WriteLine(WorkingDirectory);
            string ProjectDirectory = Directory.GetParent(WorkingDirectory).Parent.Parent.FullName;
            Console.WriteLine(ProjectDirectory);
            string ReportPath = ProjectDirectory + "//Index.html";
            var HtmlReporter = new ExtentHtmlReporter(ReportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(HtmlReporter);
            extentReports.AddSystemInfo("Username", "Gladson Antony");
        }


        [SetUp]
        public void SetupBrowser()
        {
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.Name);
            ConfigBrowserName = TestContext.Parameters["Browser"];
            if (ConfigBrowserName == null)
            {
                ConfigBrowserName = ConfigurationManager.AppSettings["Browser"];
            }
            InitBrowser(ConfigBrowserName);
            driver.Value.Manage().Window.Maximize();
            driver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Value.Url = ConfigurationManager.AppSettings["URL"];
            TestContext.WriteLine("Title of the Webpage " + driver.Value.Title);
        }

        public void InitBrowser(string BrowserName)
        {
            switch (BrowserName.ToLower())
            {
                case "firefox":
                    if (ConfigurationManager.AppSettings["Headless"].ToLower().Equals("true"))
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArguments("--headless");
                        driver.Value = new FirefoxDriver(firefoxOptions);
                    }
                    else
                    {
                        driver.Value = new FirefoxDriver();
                    }
                    break;

                case "edge":
                    if (ConfigurationManager.AppSettings["Headless"].ToLower() == "true")
                    {
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.AddArguments("--headless");
                        driver.Value = new EdgeDriver(edgeOptions);
                    }
                    else
                    {
                        driver.Value = new EdgeDriver();
                    }
                    break;

                case "chrome":
                    
                    if (ConfigurationManager.AppSettings["Headless"].ToLower() == "true")
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--headless");
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    else
                    {
                        driver.Value = new ChromeDriver();
                    }
                    break;

                case "brave":                    
                    if (ConfigurationManager.AppSettings["Headless"].ToLower() == "true")
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--headless");
                        chromeOptions.BinaryLocation = ConfigurationManager.AppSettings["BravePath"];
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    else
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = ConfigurationManager.AppSettings["BravePath"];
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    break;

                case "opera":
                    if (ConfigurationManager.AppSettings["Headless"].ToLower() == "true")
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = ConfigurationManager.AppSettings["OperaPath"];
                        chromeOptions.AddArguments("--headless");
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    else
                    {                         
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = ConfigurationManager.AppSettings["OperaPath"];
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    break;

                case "chromium":
                    if (ConfigurationManager.AppSettings["Headless"].ToLower() == "true")
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = ConfigurationManager.AppSettings["ChromiumPath"];
                        chromeOptions.AddArguments("--headless");
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    else
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.BinaryLocation = ConfigurationManager.AppSettings["ChromiumPath"];
                        driver.Value = new ChromeDriver(chromeOptions);
                    }
                    break;
            }
        }

        public IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public static JsonReader getDataParser()
        {
            return new JsonReader();
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
                extentTest.Fail("Test Failed", CaptureScreenShot(driver.Value, fileName));
                extentTest.Log(AventStack.ExtentReports.Status.Fail, "Test Failed with Logtrace" + StackTrace);
            }
            else if (Status == TestStatus.Passed)
            {
                extentTest.Pass("Test Passed");
            }
            extentReports.Flush();
            driver.Value.Quit();
        }

        public MediaEntityModelProvider CaptureScreenShot(IWebDriver driver, string ScreenshotName)
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            var CapturedScreenshot = screenshot.GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(CapturedScreenshot, ScreenshotName).Build();
        }
    }
}