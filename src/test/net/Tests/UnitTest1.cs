using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Collections;
using NUnit.Framework;
using CSharpSeleniumFramework.src.main.net.Core;

namespace CSharpSeleniumFramework.src.test.net.Tests
{
    public class Tests : Base
    {
        [Test]
        [Ignore("Sample Test")]
        public void Test1()
        {
            IWebElement pageContents = driver.Value.FindElement(By.XPath("//select[@id='page-menu']"));
            SelectElement selectElement = new SelectElement(pageContents);
            Assert.IsNotNull(selectElement);
            selectElement.SelectByValue("20");

            ArrayList a = new ArrayList();
            IList<IWebElement> VeggiesList = driver.Value.FindElements(By.XPath("//tr/td[1]"));

            TestContext.WriteLine(
                "\n\nListing all the Vegitables in the Web Page and moving them to Array List"
            );
            foreach (IWebElement element in VeggiesList)
            {
                TestContext.WriteLine(element.Text);
                a.Add(element.Text);
            }

            TestContext.WriteLine("\n\nNow Priting the Vegitables in the Array List");
            foreach (string sortedVeggies in a)
            {
                TestContext.WriteLine(sortedVeggies);
            }

            a.Sort();

            TestContext.WriteLine("\n\nNow Sorting and Priting the Vegitables in the Array List");
            foreach (string sortedVeggies in a)
            {
                TestContext.WriteLine(sortedVeggies);
            }

            driver.Value.FindElement(By.XPath("//span[normalize-space()='Veg/fruit name']")).Click();
            Thread.Sleep(1000);

            ArrayList b = new ArrayList();

            IList<IWebElement> SortedVeggiesList = driver.Value.FindElements(By.XPath("//tr/td[1]"));

            TestContext.WriteLine(
                "\n\nListing all the Vegitables in the Web Page after Sorting and moving them to Array List"
            );
            foreach (IWebElement element1 in SortedVeggiesList)
            {
                TestContext.WriteLine(element1.Text);
                b.Add(element1.Text);
            }

            Assert.AreEqual(a, b);
        }
    }
}
