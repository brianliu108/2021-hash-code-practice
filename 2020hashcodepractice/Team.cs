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
            if (pizza.Used)
                return false;

            pizzas.Add(pizza);
            pizza.Used = true;
            
            return true;
        }

        public bool removePizza(Pizza pizza)
        {
            bool result = pizzas.Remove(pizza);

            if (result)
                pizza.Used = false;

            return result;
        }
    }
}
