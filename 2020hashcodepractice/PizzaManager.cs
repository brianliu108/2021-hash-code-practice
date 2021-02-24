using System.Collections.Generic;

namespace _2020hashcodepractice
{
    public class PizzaManager {
        public readonly int numOfPizzas, team2Count, team3Count, team4Count;
        public List<Team>[] teams = new List<Team>[3];
        public int pizzasLeft { get; private set; }

        private List<Pizza> pizzas = new List<Pizza>();

        public PizzaManager(int numOfPizzas, int team2Count, int team3Count, int team4Count) {
            this.numOfPizzas = pizzasLeft = numOfPizzas;
            this.team2Count = team2Count;
            this.team3Count = team3Count;
            this.team4Count = team4Count;   
            
            
        }

        public void addPizza(Pizza pizza) => pizzas.Add(pizza);

        const int TWO = (int)Team.TeamSize.TWO;
        const int THREE = (int)Team.TeamSize.THREE;
        const int FOUR = (int)Team.TeamSize.FOUR;

        /// <summary>
        /// Solution 1
        /// </summary>
        /// <param name="team"></param>
        public void givesPizzas_LargerTeams(Team team)
        {            
            pizzas[TWO].
        }

        //public bool assignPizza(Pizza pizza, int teamMembers)
        //{

        //}
    }
}