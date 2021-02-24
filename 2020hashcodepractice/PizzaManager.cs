using System.Collections.Generic;

namespace _2020hashcodepractice {
    public class PizzaManager {
        public readonly int numOfPizzas, team2Count, team3Count, team4Count;
        public static List<int[]> team2Orders = new List<int[]>();
        public static List<int[]> team3Orders = new List<int[]>();
        public static List<int[]> team4Orders = new List<int[]>();
        public int pizzasLeft { get; private set; }

        private List<Pizza> pizzas = new List<Pizza>();

        public PizzaManager(int numOfPizzas, int team2Count, int team3Count, int team4Count) {
            this.numOfPizzas = pizzasLeft = numOfPizzas;
            this.team2Count = team2Count;
            this.team3Count = team3Count;
            this.team4Count = team4Count;
        }

        public void addPizza(Pizza pizza) => pizzas.Add(pizza);
    }
}