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

        public void Insert(Node node)
        {
            Root = Insertrec(Root, node);
            count++;
        }
        public Node Insertrec(Node root, Node node)
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

        public void recursivePreorder(Node root)
        {
            Console.WriteLine(root.Defenses[0]);
            if (root.Left != null)
            {
                recursivePreorder(root.Left);
            }
            if (root.Right != null)
            {
                recursivePreorder(root.Right);
            }
        }

        public void preorderTraversal()
        {
            if (Root != null)
            {
                recursivePreorder(Root);
            }
            else
            {
                Console.WriteLine("There is no tree to process");
            }
        }
    }
}
