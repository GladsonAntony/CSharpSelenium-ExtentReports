using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CSharpSeleniumExtent.src.main.net.Core
{
    public class BrowserFactory : InitializeMethod
    {
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

    }
}
