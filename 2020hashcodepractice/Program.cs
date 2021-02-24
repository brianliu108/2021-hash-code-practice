using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020hashcodepractice {
    class Program {

        private static PizzaManager pizzaManager;

        static void Main(string[] args) {
            Init();
            pizzaManager.givesPizzas_LargerTeams();
            Console.WriteLine("\n======== FINISHED ASSIGNING PIZZAS ========\n");
            Console.WriteLine(pizzaManager.checkTeamSizes());
            Console.WriteLine(pizzaManager.printAllTeams());
            Console.ReadLine();
        }

        private static void Init() {
            string[] lines = System.IO.File.ReadAllLines(@".\hashpractice\a_example");
            string[] firstLineInfo = lines[0].Split(' ');

            pizzaManager = new PizzaManager(
                int.Parse(firstLineInfo[0]),
                int.Parse(firstLineInfo[1]),
                int.Parse(firstLineInfo[2]),
                int.Parse(firstLineInfo[3]));

            for (int i = 1; i < lines.Length; i++) {
                string tempLine = lines[i].Substring(lines[i].IndexOf(' ') + 1);
                string[] toppings = tempLine.Split(' ');
                Pizza pizza = new Pizza(pizzaManager, i, toppings);
                Console.WriteLine(pizza);
                pizzaManager.addPizza(pizza);
            }
        }
    }
}