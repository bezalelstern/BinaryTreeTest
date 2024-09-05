// See https://aka.ms/new-console-template for more information
using System.Reflection;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string data = File.ReadAllText(Path.Combine("C:\\Users\\Rafi\\Desktop\\Exercises\\LinkedList\\LinkedList", "tree.json"));
        Dictionary<string, Model> dictionary = JsonConvert.DeserializeObject<Dictionary<string, Model>>(data)!;
        Dictionary<string, BinaryTree> trees = new();
        foreach (Model model in dictionary.Values)
        {
            BinaryTree tree = new();
            foreach (int num in model.t)
            {
                tree.Insert(num);
            }
            trees[model.n] = tree;
        }
        Console.WriteLine(trees["or"].GetMax());
    }