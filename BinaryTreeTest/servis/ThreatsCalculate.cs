using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BinaryTreeTest.Models;

namespace BinaryTreeTest.servis
{
    public class ThreatsCalculate
    {
        //חישוב חומרת האיום
        public void severitycalculation(List<threat> threats)
        {

            Console.WriteLine("Calculates the severity of threats...");

            Thread.Sleep(4000);
            int TargetValue;
            foreach (threat threat in threats)
            {
                TargetValue = converter(threat.Target);
                threat.Severity = threat.Volume * threat.Sophistication + TargetValue;
            }
            Console.WriteLine("The severity of the threats was calculated");
        }

        //המרה של ערך המטרה
        public static int converter(string target)
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
}
