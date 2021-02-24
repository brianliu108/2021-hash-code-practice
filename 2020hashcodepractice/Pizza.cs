using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2020hashcodepractice {
    /// <summary>
    /// A pizzas has an id number (the index of the pizzas on the original input), and toppings.
    /// </summary>
    public class Pizza {
        public readonly int id;
        public bool used = false;

        public string[] toppings { get; private set; }

        public Pizza(int lineNumber, string[] toppingsArray) {
            id = lineNumber;
            toppings = toppingsArray;
        }

        public override string ToString() {
            StringBuilder s = new StringBuilder();
            s.Append("#").Append(id).Append(" ");
            foreach (var topping in toppings)
                s.Append(topping).Append(" ");
            return s.ToString();
        }

        public static int numUnique(params Pizza[] pizzas) {
            HashSet<string> set = new HashSet<string>();
            foreach (var pizza in pizzas)
            foreach (var topping in pizza.toppings)
                set.Add(topping);
            return set.Count;
        }

        public static int numDuplicates(params Pizza[] pizzas) {
            int numUnique = Pizza.numUnique(pizzas);
            int nunTotal = pizzas.Sum(pizza => pizza.toppings.Length);
            return nunTotal - numUnique;
        }
    }
}