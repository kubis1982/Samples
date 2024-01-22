// See https://aka.ms/new-console-template for more information
using System.Text.Json;

string c = """
{
    "Id":2
}
""";
var f = JsonSerializer.Deserialize<TempClass>("""
{
    "Id":2
}
""")!;
Console.WriteLine("Hello, World!");

public class TempClass {
    public int Id { get; set; }
}
