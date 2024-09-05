using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest
{
    internal class DefenceStrategiesBST
    {
        public DefenceStrategiesBST() { }
        public Node Root;
        public int count = 0;
        public int MinSeverity = 0;
        public int MaxSeverity = 0;

        public void Insert(Node node)
        {
            if (node.MinSeverity < MinSeverity)
            {
                MinSeverity = node.MinSeverity;
            }
            if (node.MaxSeverity > MaxSeverity) 
            { MaxSeverity = node.MaxSeverity; }
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

        private void recursivePreorder(Node root, string location, string space)
        {
            string str = "";
            if (location == "root")
                str = "Root:";
            else if (location == "right")
                str = "|__ Right Child:";
            else if (location == "left")
                str = "|__ Left Child:";
            space += " ";
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
    }
}
