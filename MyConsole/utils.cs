using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace MyConsole
{
    public static class CSharpUtils
    {
        public static T? JsontoTemplate<T>(string json)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };
            var generic = JsonSerializer.Deserialize<T>(json, options);

            return generic;
        }

        public static string TemplateToJson<T>(T template)
        {
            var options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true,
            };

            var json = JsonSerializer.Serialize(template, options);
            return json;
        }
    }
}
