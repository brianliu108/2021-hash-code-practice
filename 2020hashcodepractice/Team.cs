using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020hashcodepractice {
    public class Team {
        public enum TeamSize { TWO, THREE, FOUR }

        public readonly TeamSize teamSize;
        public List<Pizza> pizzas = new List<Pizza>();

        public int MaxPizzas {
            get => (int) teamSize + 2;
        }

        public int Score {
            get {
                int unique = Pizza.NumUnique(pizzas.ToArray());
                return unique * unique;
            }
        }

        public Team(TeamSize teamSize) {
            this.teamSize = teamSize;
        }

        public string GetPizzaStringList() {
            int numUnique = Pizza.NumUnique(pizzas.ToArray());
            StringBuilder s = new StringBuilder()
                .Append("Pizzas: ").Append(pizzas.Count.ToString().PadRight(6))
                .Append(" Unique T: ").Append(numUnique.ToString().PadRight(6))
                .Append(" Waisted T: ").Append(Pizza.NumDuplicates(pizzas.ToArray()).ToString().PadRight(6))
                .Append(" Score: ").Append((numUnique * numUnique).ToString().PadRight(6))
                .Append(" Pizzas... ");
            foreach (Pizza pizza in pizzas) s.Append(" ").Append(pizza.id);
            return s.ToString();
        }

        public string fileSaveLine()
        {
            StringBuilder strBuilder = new StringBuilder()
                .Append(pizzas.Count);

            foreach (var pizza in pizzas)
            {
                strBuilder.Append(" ").Append(pizza.id - 1);
            }

            return strBuilder.ToString();
        }

        public bool givePizza(Pizza pizza) {
            if (pizza.Used)
                return false;

            pizzas.Add(pizza);
            pizza.Used = true;

            return true;
        }

        public bool removePizza(Pizza pizza) {
            bool result = pizzas.Remove(pizza);

            if (result)
                pizza.Used = false;

            return result;
        }
    }
}