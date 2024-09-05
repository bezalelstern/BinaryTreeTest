using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeTest.Models;

namespace BinaryTreeTest
{
    internal class DefenceStrategiesBST
    {
        public DefenceStrategiesBST() { }
        public Node Root;
        public int count = 0;
        public int MinSeverity = 0;
        
        //הוספה לעץ
        //סיבוכיות (n)
        public void Insert(Node node)
        {
            if (node.MinSeverity < MinSeverity)
            {
                MinSeverity = node.MinSeverity;
            }
            Root = Insertrec(Root, node);
            count++;
        }



        private Node Insertrec(Node root, Node node)
        {
            if (root == null)
            {
                return node;
            }
            if (node.MinSeverity <root.MinSeverity)
            {
                root.Left = Insertrec(root.Left, node);
            }
            else   
            {
                root.Right = Insertrec(root.Right, node);
            }
            return root;
        }

        //הדפסה
        //(n)
        public void preorderTraversal()
        {
            if (Root != null)
            {
                recursivePreorder(Root, "root", "");
            }
            else
            {
                Console.WriteLine("There is no tree to process");
            }
        }

        private void recursivePreorder(Node root, string location, string space)
        {
            string str = "";
            if (location == "root")
                str = "Root:";
            else if (location == "right")
                str = "|__ Right Child:";
            else if (location == "left")
                str = "|__ Left Child:";
            space += "  ";
            Console.WriteLine($"{space} {str} [{root.MinSeverity} - {root.MaxSeverity}] Defences: {root.Defenses[0]}, {root.Defenses[1]}");
            if (root.Left != null)
            {
                recursivePreorder(root.Left, "left", space);
            }
            if (root.Right != null)
            {
                recursivePreorder(root.Right, "right", space);
            }
        }

       //חיפוש הגנה מתאימה
        //סיבוכיות log(n)
        public Node Find(double data)
        {
            Node result =  Findrec(Root, data);
            return result;
        }

        public Node Findrec(Node node, double data)
        {
            if (node == null)
                return node;
            if (data <= node.MaxSeverity && data >= node.MinSeverity)
            { 
                return node;              
            }
            return Findrec(data < node.MinSeverity ? node.Left : node.Right, data);
        }
    }
}
