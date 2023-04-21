using AventStack.ExtentReports;
using CSharpSeleniumExtent.src.main.net.Core;
using CSharpSeleniumExtent.src.main.net.Utilities;
using CSharpSeleniumFramework.src.main.net.Core;
using CSharpSeleniumFramework.src.test.net.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumExtent.src.test.net.Tests
{
    public class DynamicTestDataExample : Base
    {
        public static IEnumerable<TestCaseData> ReadDataFromJSON()
        {
            JsonReader jsonReader = new JsonReader();
            yield return new TestCaseData(jsonReader.extractDataWithFilename("username","Credentials"), 
                jsonReader.extractDataWithFilename("password", "Credentials"));
        }


        [TestCaseSource(nameof(ReadDataFromJSON))]
        public void TestDynamicData(String username, String password)
        {
            TestContext.WriteLine("To Demo the use of Dynamically reading the JSON Test Data and Printing the values");
            TestContext.WriteLine(username);
            //LogInfo($"Provided Username : {username}");
            TestContext.WriteLine(password);
            //LogInfo($"Provided Password : {password}");
        }


        public static IEnumerable<TestCaseData> ReadDataFromEXCEL()
        {
            ExcelReader excelReader = new ExcelReader();
            return excelReader.ReadFromExcel("ExcelTestData", "Sheet1");
        }


        [TestCaseSource(nameof(ReadDataFromEXCEL))]
        public void TestDynamicDataExcel(String Column1, String Column2, String Column3, String Column4, String Column5)
        {
            TestContext.WriteLine("To Demo the use of Dynamically reading the Excel Test Data and Printing the values");
            TestContext.WriteLine(Column1);
            TestContext.WriteLine(Column2);
            TestContext.WriteLine(Column3);
            TestContext.WriteLine(Column4);
            TestContext.WriteLine(Column5);
        }
    }
}