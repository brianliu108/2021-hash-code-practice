using System.Collections.Generic;
using System.Linq;
using static _2020hashcodepractice.Team.TeamSize;

namespace _2020hashcodepractice
{
    public class PizzaManager
    {
        public readonly int numOfPizzas;
        public readonly int[] teamMax = new int[3];
        public List<Team>[] teams = new List<Team>[3];
        public int pizzasLeft;

        private List<Pizza> pizzas = new List<Pizza>();

        public PizzaManager(int numOfPizzas, int team2Count, int team3Count, int team4Count)
        {
            this.numOfPizzas = pizzasLeft = numOfPizzas;
            teamMax[SIZE_TWO] = team2Count;
            teamMax[SIZE_THREE] = team3Count;
            teamMax[SIZE_FOUR] = team4Count;

            teams[SIZE_TWO] = new List<Team>();
            teams[SIZE_THREE] = new List<Team>();
            teams[SIZE_FOUR] = new List<Team>();
        }

        public void addPizza(Pizza pizza) => pizzas.Add(pizza);

        const int SIZE_TWO = (int)Team.TeamSize.TWO;
        const int SIZE_THREE = (int)Team.TeamSize.THREE;
        const int SIZE_FOUR = (int)Team.TeamSize.FOUR;

        static readonly Team.TeamSize[] teamSizes = new[] { FOUR, THREE, TWO };

        /// <summary>
        /// Solution 1
        /// </summary>
        /// <param name="team"></param>
        public void givesPizzas_LargerTeams()
        {
            pizzas = pizzas.OrderBy(x => x.toppings.Length).ToList();

            foreach (Team.TeamSize size in teamSizes)
            {
                while (canMakeGivenSize((int)size) && shouldMakeGivenSize((int)size))
                {
                    teams[(int)size].Add(new Team(size));
                }
            }
            
            int minAcceptedDupes = 0;

            while(pizzasLeft > 0)
            {
                int minDupes = int.MaxValue;
                for (int currentSize = SIZE_FOUR; currentSize >= SIZE_TWO; currentSize--)
                {
                    foreach (Team team in teams[currentSize])
                    {
                        Pizza firstPizza = pizzas.FirstOrDefault(x => !x.Used);
                        Pizza[] pizzasToCheck = new Pizza[team.pizzas.Count + 1];

                        pizzasToCheck[0] = firstPizza;
                        for (int i = 1; i < pizzasToCheck.Length; i++)
                        {
                            pizzasToCheck[i] = team.pizzas[i - 1];
                        }

                        int currentDupes = Pizza.NumDuplicates(pizzasToCheck);

                        if (currentDupes <= minAcceptedDupes)
                        {
                            team.givePizza(firstPizza);
                        }
                        
                        if(currentDupes < minDupes)
                        {
                            minDupes = currentDupes;
                        }
                    }
                }
                minAcceptedDupes = minDupes;
            }            
        }

        public bool canMakeGivenSize(int teamSize)
        {
            return ((teamMax[teamSize] > teams[teamSize].Count) && (pizzasLeft >= teamSize + 2));
        }

        public bool shouldMakeGivenSize(int teamSize)
        {
            return (((pizzasLeft - teamSize + 2) > 2) || teamSize == SIZE_TWO);
        }

        //public bool assignPizza(Pizza pizza, int teamMembers)
        //{

        //}
    }
}