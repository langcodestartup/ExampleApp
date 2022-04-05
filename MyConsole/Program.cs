

using Microsoft.AspNetCore.JsonPatch;
using MyConsole;
using System.Text.Json;
using System.Text.Json.Nodes;

var jsonString = File.ReadAllText($"Paperpop/Analysis.json");

JsonNode node = JsonNode.Parse(jsonString);

var arr = node.AsArray();
var test = arr[0]["SKUList"];

var t = JsonSerializer.Deserialize<string[]>(test);

foreach (var item in t)
{
    Console.WriteLine(item);
}