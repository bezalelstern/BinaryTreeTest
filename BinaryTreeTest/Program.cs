// See https://aka.ms/new-console-template for more information
using System.Reflection;
using BinaryTreeTest;
using Newtonsoft.Json;
class Program
{
    public static DefenceStrategiesBST DefenceStrategiesBST= new DefenceStrategiesBST();
    public static string DefencePath = "C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\defence.json";
    public static string AttackPath = "C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\threats.json";
    static async Task Main(string[] args)
    {

        Console.WriteLine("Creates a defence binary tree...");
        using StreamReader reader = new(DefencePath);
        var json = reader.ReadToEnd();
        List<Node> stratgy = JsonConvert.DeserializeObject<List<Node>>(json);
        DefenceStrategiesBST = new DefenceStrategiesBST();
        foreach (Node node in stratgy)
        {
            DefenceStrategiesBST.Insert(node);
        }
  
       
        Task.Delay(2000).Wait();
        Console.WriteLine("Binary tree created successfully!");
        DefenceStrategiesBST.preorderTraversal();
        await Importsthreats();
        
    }

    public static async Task Importsthreats() 
    {
        Console.WriteLine("imports threats...");
        using StreamReader reader2 = new(AttackPath);
        var jsonthreats = reader2.ReadToEnd();
        List<threat> threats = JsonConvert.DeserializeObject<List<threat>>(jsonthreats);
        await severitycalculation(threats);
        Task.Delay(2000).Wait();
        Console.WriteLine("All threats have been identified");
        await activet(threats, DefenceStrategiesBST);
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

    public static async Task activet(List<threat> threats, DefenceStrategiesBST bst )
    {
        for (int i = 0; i < threats.Count; i++) 
        {
            if (threats[i].Severity < bst.MinSeverity) 
            {
                Console.WriteLine($"Threats {i+1} is severity Attack below the threshold. Attack is ignored");
            }
            else {
                Node defence =  bst.Find(threats[i].Severity);
                Console.WriteLine($"Threat {i+1} in progres");
                Task.Delay(2000).Wait();
                if (defence != null)
                {
                    Console.WriteLine(defence.Defenses[0]);
                    Console.WriteLine(defence.Defenses[1]);
                }
                else { Console.WriteLine("No suitable defence wes found. Brace for impact"); }
                Console.WriteLine();
            }
            
        }
    }
}