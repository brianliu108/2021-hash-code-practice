using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static _2020hashcodepractice.Team.TeamSize;

namespace _2020hashcodepractice {
    public class PizzaManager {
        public readonly int numOfPizzas;
        public readonly int[] teamMax = new int[3];
        public List<Team>[] teams = new List<Team>[3];
        public int pizzasLeft;

        private List<Pizza> pizzas = new List<Pizza>();

        public PizzaManager(int numOfPizzas, int team2Count, int team3Count, int team4Count) {
            this.numOfPizzas = pizzasLeft = numOfPizzas;
            teamMax[SIZE_TWO] = team2Count;
            teamMax[SIZE_THREE] = team3Count;
            teamMax[SIZE_FOUR] = team4Count;

            teams[SIZE_TWO] = new List<Team>();
            teams[SIZE_THREE] = new List<Team>();
            teams[SIZE_FOUR] = new List<Team>();
        }

        public void addPizza(Pizza pizza) => pizzas.Add(pizza);

        const int SIZE_TWO = (int) Team.TeamSize.TWO;
        const int SIZE_THREE = (int) Team.TeamSize.THREE;
        const int SIZE_FOUR = (int) Team.TeamSize.FOUR;

        static readonly Team.TeamSize[] teamSizes = new[] {FOUR, THREE, TWO};

        public string printAllTeams() {
            StringBuilder s = new StringBuilder();
            for (int currentSize = SIZE_FOUR; currentSize >= SIZE_TWO; currentSize--)
                foreach (Team team in teams[currentSize])
                    s.Append(team.GetPizzaStringList()).Append("\n");
            return s.ToString();
        }

        public void saveOutputToFile(string fileName) {
            using (StreamWriter writer = new StreamWriter(@".\" + fileName, false)) {
                writer.WriteLine((teams[SIZE_TWO].Count + teams[SIZE_THREE].Count + teams[SIZE_FOUR].Count).ToString());

                for (int currentSize = SIZE_FOUR; currentSize >= SIZE_TWO; currentSize--)
                    foreach (Team team in teams[currentSize])
                        writer.WriteLine(team.fileSaveLine());
            }
        }

        public long getScore() {
            long score = 0;
            for (int currentSize = SIZE_FOUR; currentSize >= SIZE_TWO; currentSize--)
                foreach (Team team in teams[currentSize])
                    score += team.Score;
            return score;
        }

        public string checkTeamSizes() {
            int team2count = 0;
            int team3count = 0;
            int team4count = 0;
            for (int currentSize = SIZE_FOUR; currentSize >= SIZE_TWO; currentSize--)
                foreach (Team team in teams[currentSize])
                    switch (team.teamSize) {
                        case TWO:
                            team2count++;
                            break;
                        case THREE:
                            team3count++;
                            break;
                        case FOUR:
                            team4count++;
                            break;
                        default: throw new ArgumentOutOfRangeException();
                    }
            bool t2valid = team2count <= teamMax[SIZE_TWO];
            bool t3valid = team3count <= teamMax[SIZE_THREE];
            bool t4valid = team4count <= teamMax[SIZE_FOUR];
            bool allValid = t2valid & t3valid & t4valid;
            StringBuilder s = new StringBuilder();
            s.Append("Team counts: " + (allValid ? "Good!" : "NOPE! NOPE! NOPE!")).Append("\n")
                .Append($"  {(t2valid ? "✓ " : "")}Size 2 teams: {team2count}/{teamMax[SIZE_TWO]}\n")
                .Append($"  {(t3valid ? "✓ " : "")}Size 3 teams: {team3count}/{teamMax[SIZE_THREE]}\n")
                .Append($"  {(t4valid ? "✓ " : "")}Size 4 teams: {team4count}/{teamMax[SIZE_FOUR]}\n")
                .Append($"{(allValid ? "✓✓✓ " : "NO GOOD! ")}" +
                        $"Total used: {team2count + team3count + team4count}/" +
                        $"{teamMax[SIZE_TWO] + teamMax[SIZE_THREE] + teamMax[SIZE_FOUR]}\n");

            return s.ToString();
        }

        /// <summary>
        /// Solution 1
        /// </summary>
        /// <param name="team"></param>
        public void givesPizzas_LargerTeams() {
            pizzas = pizzas.OrderBy(x => x.toppings.Length).ToList();
            int pizzasAssignable = numOfPizzas;

            foreach (Team.TeamSize size in teamSizes) {
                while (canMakeGivenSize((int) size, pizzasAssignable) &&
                       shouldMakeGivenSize((int) size, pizzasAssignable)) {
                    teams[(int) size].Add(new Team(size));
                    pizzasAssignable -= (int) size + 2;
                }
            }

            int minAcceptedDupes = 0;
            int lastNumber = 0;
            int lastNumberCount = 0;
            while (pizzasLeft > 0) {
                if (pizzasLeft == lastNumber && ++lastNumberCount == 4)
                    return;

                lastNumber = pizzasLeft;
                
                Console.WriteLine("Pizzas left: " + pizzasLeft);
                int minDupes = int.MaxValue;
                for (int currentSize = SIZE_FOUR; currentSize >= SIZE_TWO; currentSize--) {
                    foreach (Team team in teams[currentSize]) {
                        if (team.pizzas.Count < team.MaxPizzas) {
                            // Find best pizza
                            Pizza firstPizza = pizzas.FirstOrDefault(x => !x.Used);
                            // Make an array of the pizzas to compare
                            Pizza[] pizzasToCheck = new Pizza[team.pizzas.Count + 1];
                            pizzasToCheck[0] = firstPizza;
                            for (int i = 1; i < pizzasToCheck.Length; i++) pizzasToCheck[i] = team.pizzas[i - 1];
                            // See how many duplicates there are, do we want this pizza?
                            int currentDupes = Pizza.NumDuplicates(pizzasToCheck);
                            if (currentDupes <= minAcceptedDupes) {
                                // Take the pizza
                                team.givePizza(firstPizza);
                                pizzas.Remove(firstPizza); // Remove for effeciency
                            }
                            // Save the min for later
                            if (currentDupes < minDupes) minDupes = currentDupes;
                        }
                        // If we done, bail.
                        if (pizzasLeft == 0) return;
                    }
                }
                minAcceptedDupes = minDupes;
            }
        }

        public bool canMakeGivenSize(int teamSize, int pizzA) {
            return ((teamMax[teamSize] > teams[teamSize].Count) && (pizzA >= teamSize + 2));
        }

        public bool shouldMakeGivenSize(int teamSize, int pizzA) {
            return (((pizzA - (teamSize + 2)) >= 2) || teamSize == SIZE_TWO);
        }

        //public bool assignPizza(Pizza pizza, int teamMembers)
        //{

        //}
    }
}