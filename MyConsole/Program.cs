using System.Text.Json;
using System.Text.Json.Nodes;

JsonObject jo = new()
{
    ["name"] = "suhyeon",
    ["age"] = 34,
};

Person person = JsonSerializer.Deserialize<Person>(jo);

Console.WriteLine(person.address);

class Person
{
    public string name { get; set; }
    public int age { get; set; }
    public string address { get; set; }
}