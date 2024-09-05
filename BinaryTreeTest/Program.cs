// See https://aka.ms/new-console-template for more information
using System.Reflection;
using BinaryTreeTest;
using Newtonsoft.Json;
class Program
{
    static async Task Main(string[] args)
    {
        using StreamReader reader = new("C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\defence.json");
        var json = reader.ReadToEnd();
        List<Node> stratgy = JsonConvert.DeserializeObject<List<Node>>(json);
        DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();
        foreach (Node node in stratgy)
        {
            defenceStrategiesBST.Insert(node);
         
        }
        //Console.WriteLine(defenceStrategiesBST.count);
        //defenceStrategiesBST.preorderTraversal();
       
        using StreamReader reader2 = new("C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\threats.json");
        var jsonthreats = reader2.ReadToEnd();
        List<threat> threats =  JsonConvert.DeserializeObject<List<threat>>(jsonthreats);
        Console.WriteLine(threats.Count);
        await severitycalculation(threats);
    }



    public static async Task severitycalculation(List<threat> threats)
    {
        int TargetValue;
        foreach (threat threat in threats)
        {
            TargetValue = await converter(threat.Target);
            threat.Severity = (threat.Volume * threat.Sophistication) + TargetValue;
            Console.WriteLine(threat.Severity); 
        }
    }
    

    public static async Task<int> converter(string target)
    {
        int value;
        switch (target)
        {
            case "Web Server":
                value = 10; break;
            case "Database":
                value = 15; break;
            case "User Credentials":
                value = 20; break;
            default:
                value = 5;
                break;
        }
        return value;
    }
}