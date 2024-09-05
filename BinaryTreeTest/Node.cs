using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTest
{
    internal class Node
    {
        public Node() { }

        public int MinSeverity;
        public int MaxSeverity;
        public List<string> Defenses;
        public Node Right;
        public Node Left;
    }
}
