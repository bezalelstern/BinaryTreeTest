// See https://aka.ms/new-console-template for more information
using System.Reflection;
using BinaryTreeTest;
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        using StreamReader reader = new("C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\json1.json");
        var json = reader.ReadToEnd();
        List<Node> stratgy = JsonConvert.DeserializeObject<List<Node>>(json);
        Console.WriteLine(stratgy.Count());

      
    }
}