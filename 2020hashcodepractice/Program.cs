using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020hashcodepractice
{
    class Program
    {
        private static int numOfPizzas, team2Count, team3Count, team4Count;
        private static bool[] used; // whether or not a pizza has been used 
        private static HashSet<string>[] pizzas;
        private static List<int[]> team2Orders = new List<int[]>();
        private static List<int[]> team3Orders = new List<int[]>();
        private static List<int[]> team4Orders = new List<int[]>();

        static void Main(string[] args)
        {
            Init();
            Console.ReadLine();
        }

        private static void Init()
        {
            string[] lines = System.IO.File.ReadAllLines(@".\hashpractice\a_example");
            string[] firstLineInfo = lines[0].Split(' ');


            numOfPizzas = int.Parse(firstLineInfo[0]);
            team2Count = int.Parse(firstLineInfo[1]);
            team3Count = int.Parse(firstLineInfo[2]);
            team4Count = int.Parse(firstLineInfo[3]);

            pizzas = new HashSet<string>[numOfPizzas];
            used = new bool[numOfPizzas];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] toppings = lines[i].Split(' ');
                pizzas[i - 1] = new HashSet<string>();
                for (int j = 1; j < toppings.Length; j++)
                {
                    pizzas[i - 1].Add(toppings[j]);
                }
            }
            Console.WriteLine(pizzas);
        }
    }
}
