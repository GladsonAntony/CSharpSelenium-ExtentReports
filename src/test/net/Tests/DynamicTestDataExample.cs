using CSharpSeleniumExtent.src.main.net.Utilities;
using CSharpSeleniumFramework.src.test.net.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtent.src.test.net.Tests
{
    public class DynamicTestDataExample
    {
        public static IEnumerable<TestCaseData> ReadDataFromJSON()
        {
            JsonReader jsonReader = new JsonReader();
            yield return new TestCaseData(jsonReader.extractDataWithFilename("username","Credentials"), 
                jsonReader.extractDataWithFilename("password", "Credentials"));
        }


        [TestCaseSource(nameof(ReadDataFromJSON))]
        public void TestDynamicData(string username, string password)
        {
            TestContext.WriteLine("To Demo the use of Dynamically reading the JSON Test Data and Printing the values");
            TestContext.WriteLine(username);
            TestContext.WriteLine(password);
        }
    }
}
