// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Threading;
using BinaryTreeTest;
using BinaryTreeTest.Models;
using BinaryTreeTest.servis;
using Newtonsoft.Json;
class Program
{
    public static string DefencePath = "C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\json\\defence.json";
    public static string AttackPath = "C:\\Users\\internet\\source\\repos\\BinaryTreeTest\\BinaryTreeTest\\json\\threats.json";


    public static DefenceStrategiesBST DefenceStrategiesBST= new DefenceStrategiesBST();

    public static List<threat> Threats;

    public static ThreatsCalculate threatsInterface = new ThreatsCalculate();

   

    static async Task Main(string[] args)
    {
        //ייבוא קובץ ההגנות
        Importdefence();

        //הדפסת העץ הבינארי
        DefenceStrategiesBST.preorderTraversal();

        //ייבוא קובץ התקפה
        Importsthreats();

        //חישוב חומרת התקפה
        threatsInterface.severitycalculation(Threats);

        //הפעלת ההגנות
        activet(Threats, DefenceStrategiesBST);

       
       
    }

    //ייבוא הגנות
    public static void Importdefence() 
    {
        Console.WriteLine("Creates a defence binary tree...");
        using StreamReader reader = new(DefencePath);
        var json = reader.ReadToEnd();
        List<Node> defences = JsonConvert.DeserializeObject<List<Node>>(json);
        DefenceStrategiesBST = new DefenceStrategiesBST();
        foreach (Node node in defences)
        {
            DefenceStrategiesBST.Insert(node);
        }
        Thread.Sleep(4000);
        Console.WriteLine("Binary tree created successfully!");
        
    }


    //ייבוא איומים
    public static void Importsthreats() 
    {
        Console.WriteLine("imports threats...");
        using StreamReader reader2 = new(AttackPath);
        var jsonthreats = reader2.ReadToEnd();
        Threats = JsonConvert.DeserializeObject<List<threat>>(jsonthreats);              
        Thread.Sleep(4000);
        Console.WriteLine("All threats have been identified");
       
    }


    
    //הפעלת הגנות
    public static void activet(List<threat> threats, DefenceStrategiesBST bst )
    {
        for (int i = 0; i < threats.Count; i++) 
        {
            Console.WriteLine();
            if (threats[i].Severity < bst.MinSeverity) 
            {
                Console.WriteLine($"Threats {i+1} is severity Attack below the threshold. Attack is ignored");
            }
            else {
                Node defence =  bst.Find(threats[i].Severity);
                Console.WriteLine($"Threat {i+1} in progres");
                Thread.Sleep(2000);
                if (defence != null)
                {
                    Console.WriteLine(defence.Defenses[0]);
                    Console.WriteLine(defence.Defenses[1]);
                }
                else { Console.WriteLine("No suitable defence wes found. Brace for impact"); }
            
            }
            
        }
    }
}