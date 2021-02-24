using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2020hashcodepractice {
    /// <summary>
    /// A pizzas has an id number (the index of the pizzas on the original input), and toppings.
    /// </summary>
    public class Pizza {
        /// <summary> This is the line number of the pizza and is needed for the final submission </summary>
        public readonly int id;

        /// <summary> For internal use only. We can only deliver each pizza once, so we must keep track. </summary>
        public bool used = false;

        /// <summary> This is an array of the toppings as strings. </summary>
        public string[] toppings { get; private set; }

        /// <summary>
        /// Generic constructor.
        /// </summary>
        /// <param name="lineNumber">The index of the pizza (needed for submission)</param>
        /// <param name="toppingsArray">An array containing all toppings and nothing else.</param>
        public Pizza(int lineNumber, string[] toppingsArray) {
            id = lineNumber;
            toppings = toppingsArray;
        }

        /// <summary>
        /// Pretty prints the pizza info.
        /// </summary>
        /// <returns>A string describing the pizza.</returns>
        public override string ToString() {
            StringBuilder s = new StringBuilder();
            s.Append("#").Append(id).Append(" ");
            foreach (var topping in toppings)
                s.Append(topping).Append(" ");
            return s.ToString();
        }

        /// <summary>
        /// Tells you the number of unique toppings used throughout all given pizzas.
        /// </summary>
        /// <param name="pizzas">The pizzas to count the unique topppings from.</param>
        /// <returns>The number of unique toppings.</returns>
        public static int NumUnique(params Pizza[] pizzas) {
            HashSet<string> set = new HashSet<string>();
            foreach (var pizza in pizzas)
            foreach (var topping in pizza.toppings)
                set.Add(topping);
            return set.Count;
        }

        /// <summary>
        /// The number of wasted toppings. These are duplicate toppings that will not count towards score.
        /// </summary>
        /// <param name="pizzas">The pizzas to count the duplicate toppings for.</param>
        /// <returns>The number of duplicate toppings on the pizzas.</returns>
        public static int NumDuplicates(params Pizza[] pizzas) {
            int numUnique = Pizza.NumUnique(pizzas);
            int nunTotal = pizzas.Sum(pizza => pizza.toppings.Length);
            return nunTotal - numUnique;
        }
    }
}