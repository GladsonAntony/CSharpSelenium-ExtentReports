using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using CSharpSeleniumFramework.src.main.net.Core;

namespace CSharpSeleniumFramework.src.test.net.PageObjects
{
    public class ProductsPageObjects : Base
    {
        private IWebDriver driver;

        public ProductsPageObjects(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.TagName, Using = "app-card")]
        private IList<IWebElement> cards;

        [FindsBy(How = How.XPath, Using = "//a[@class='nav-link btn btn-primary']")]
        private IWebElement button_Checkout;

        public ProductsPageObjects WaitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));
            TestContext.WriteLine("Title Of The Page --> " + driver.FindElement(By.TagName("h1")).Text);
            return this;
        }

        public ProductsPageObjects getProducts()
        {
            string[] expectedProducts = { "iphone X", "Samsung Note 8" };
            TestContext.WriteLine("Products available in the Page..");

            foreach (IWebElement product in cards)
            {
                TestContext.WriteLine(product.FindElement(By.CssSelector(".card-title a")).Text);
                if (expectedProducts.Contains(product.FindElement(By.CssSelector(".card-title a")).Text))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }
            return this;
        }

        public ProductsPageObjects clickOnCheckOutButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(button_Checkout));
            return this;
        }
    }
}
