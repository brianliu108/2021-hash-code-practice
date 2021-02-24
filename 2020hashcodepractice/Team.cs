using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020hashcodepractice
{
    public class Team
    {
        public enum TeamSize
        {
            TWO,
            THREE,
            FOUR
        }
        public readonly TeamSize teamSize;
        public List<Pizza> pizzas = new List<Pizza>();
        public int MaxPizzas { get => (int)teamSize + 2; }

        public Team(TeamSize teamSize)
        {
            this.teamSize = teamSize;
        }

        public bool givePizza(Pizza pizza)
        {
            if (pizza.used)
                return false;

            pizzas.Add(pizza);
            pizza.used = true;

            return true;
        }

        public bool removePizza(Pizza pizza)
        {
            bool result = pizzas.Remove(pizza);

            if (result)
                pizza.used = false;

            return result;
        }
    }
}
