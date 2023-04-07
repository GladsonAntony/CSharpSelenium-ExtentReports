using Newtonsoft.Json.Linq;

namespace CSharpSeleniumFramework.src.test.net.Tests
{
    public class JsonReader
    {
        public JsonReader() { }

        public string extractData(string TokenName)
        {
            var myJsonString = File.ReadAllText("src/test/net/Tests/TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(TokenName).Value<string>();
        }

        public string[] extractArrayData(string TokenName)
        {
            var myJsonString = File.ReadAllText("Tests/TestData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<string> arrayLists = jsonObject.SelectTokens(TokenName).Values<string>().ToList();
            return arrayLists.ToArray();
        }
    }
}
