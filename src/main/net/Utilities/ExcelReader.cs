using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSharpSeleniumExtent.src.main.net.Core;

namespace CSharpSeleniumExtent.src.main.net.Utilities
{
    public class ExcelReader : InitializeMethod
    {
        public IEnumerable<TestCaseData> ReadFromExcel(String excelFileName, String excelsheetName)
        {            
            string excelLocation = Path.Combine(TestDataPath + excelFileName + ".xlsx");

            string cmdText = "SELECT * FROM [" + excelsheetName + "$]";

            if (!File.Exists(excelLocation))
                throw new Exception(string.Format("File name: {0}", excelLocation), new FileNotFoundException());

            string connectionStr = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";", excelLocation);

            var testCases = new List<TestCaseData>();
            using (var connection = new OleDbConnection(connectionStr))
            {
                connection.Open();
                var command = new OleDbCommand(cmdText, connection);
                var reader = command.ExecuteReader();
                if (reader == null)
                    throw new Exception(string.Format("No data return from file, file name:{0}", excelLocation));
                while (reader.Read())
                {
                    var row = new List<string>();
                    var feildCnt = reader.FieldCount;
                    for (var i = 0; i < feildCnt; i++)
                        row.Add(reader.GetValue(i).ToString());
                    testCases.Add(new TestCaseData(row.ToArray()));
                }
            }

            if (testCases != null)
                foreach (TestCaseData testCaseData in testCases)
                    yield return testCaseData;
        }
    }
}

