using CSharpSeleniumExtent.src.main.net.Core;
using Newtonsoft.Json.Linq;

namespace CSharpSeleniumExtent.src.main.net.Utilities
{
    public class JsonReader : InitalizeMethod
    {
        public JsonReader() { }

        public String extractData(String TokenName)
        {
            var myJsonString = File.ReadAllText("src/test/resources/TestData/TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(TokenName).Value<string>();
        }

        public String[] extractArrayData(String TokenName)
        {
            var myJsonString = File.ReadAllText("Tests/TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<string> arrayLists = jsonObject.SelectTokens(TokenName).Values<string>().ToList();
            return arrayLists.ToArray();
        }

        public String extractDataWithFilename(String TokenName, String Filename)
        {
            var myJsonString = File.ReadAllText(TestDataPath + Filename + ".json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(TokenName).Value<string>();
        }
    }
}
