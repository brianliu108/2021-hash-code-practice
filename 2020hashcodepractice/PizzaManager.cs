using System.Collections.Generic;
using System.Linq;

namespace _2020hashcodepractice {
    public class PizzaManager {
        public readonly int numOfPizzas;
        public readonly int[] teamMax = new int[3];
        public List<Team>[] teams = new List<Team>[3];
        public int pizzasLeft { get; private set; }

        private List<Pizza> pizzas = new List<Pizza>();

        public PizzaManager(int numOfPizzas, int team2Count, int team3Count, int team4Count) {
            this.numOfPizzas = pizzasLeft = numOfPizzas;
            teamMax[SIZE_TWO] = team2Count;
            teamMax[SIZE_THREE] = team3Count;
            teamMax[SIZE_FOUR] = team4Count;
        }

        public void addPizza(Pizza pizza) => pizzas.Add(pizza);

        const int SIZE_TWO = (int) Team.TeamSize.TWO;
        const int SIZE_THREE = (int) Team.TeamSize.THREE;
        const int SIZE_FOUR = (int) Team.TeamSize.FOUR;

        /// <summary>
        /// Solution 1
        /// </summary>
        /// <param name="team"></param>
        public void givesPizzas_LargerTeams(Team team) {
            pizzas[SIZE_TWO].
        }

        //public bool assignPizza(Pizza pizza, int teamMembers)
        //{

        //}
    }
}