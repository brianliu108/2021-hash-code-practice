using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020hashcodepractice {
    class Program {
        private static readonly string[] files = new[] {
            "a_example",
            "b_little_bit_of_everything.in",
            "c_many_ingredients.in",
            "d_many_pizzas.in",
            "e_many_teams.in"
        };

        private static PizzaManager pizzaManager;

        static void Main(string[] args) {
            foreach (string fileNameIsh in files) {
                Console.WriteLine("\n============ DOING NEW FILE ============\nFile: " + fileNameIsh);
                InitPizzaManager(fileNameIsh);
                PizzaMain();
            }
            Console.ReadLine();
        }

        private static void InitPizzaManager(string fileNameIsh) {
            string[] lines = System.IO.File.ReadAllLines(@".\hashpractice\" + fileNameIsh);
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
                // if (i < 10)
                //     Console.WriteLine(pizza);
                // else if (i == 11)
                //     Console.WriteLine("...");
                pizzaManager.addPizza(pizza);
            }
        }

        public static void PizzaMain() {
            pizzaManager.givesPizzas_LargerTeams();
            Console.WriteLine("\n==== FINISHED ASSIGNING PIZZAS ====\n");
            Console.WriteLine("Score: " + pizzaManager.getScore() + "\n");
            Console.WriteLine(pizzaManager.checkTeamSizes());
            //Console.WriteLine(pizzaManager.printAllTeams());
            pizzaManager.saveOutputToFile();
        }
    }
}