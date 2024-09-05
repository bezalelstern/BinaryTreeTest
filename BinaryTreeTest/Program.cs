// See https://aka.ms/new-console-template for more information
using System.Reflection;
using BinaryTreeTest;
using Newtonsoft.Json;
class Program
{
    static void Main(string[] args)
    {
        using StreamReader reader = new("C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\json2.json");
        var json = reader.ReadToEnd();
        List<Node> stratgy = JsonConvert.DeserializeObject<List<Node>>(json);
        DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();
        foreach (Node node in stratgy)
        {
            defenceStrategiesBST.Insert(node);
            //Console.WriteLine(node.Defenses[0]);
        }
        Console.WriteLine(defenceStrategiesBST.count);
        defenceStrategiesBST.preorderTraversal();

       
    }
}