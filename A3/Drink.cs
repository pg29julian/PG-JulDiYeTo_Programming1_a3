using System;

namespace A3
{
    public class Drink
    {
        private Random rnd = new Random(); // Random generator
        private List<EIngredient> requiredIngredients = new List<EIngredient>(); // Ingredients required by the drink
        private List<EIngredient> fillRequiredIngredients = new List<EIngredient>(); // Ingredients put into the drink

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="inventory"></param>
        public Drink(Inventory inventory)
        {
            requiredIngredients = inventory.GetIngredients().OrderBy(x => rnd.Next()).Take(3).ToList();
        }

        /// <summary>
        /// Fills a Drink with the given Ingredients
        /// </summary>
        /// <param name="ingredients"></param>
        public void FillIngredients(List<EIngredient> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                fillRequiredIngredients.Add(ingredient);
            }
        }

        /// <summary>
        /// Check if the drink created is the drink ordered
        /// </summary>
        /// <returns></returns>
        public bool CheckDrink()
        {
            if (fillRequiredIngredients.Count != requiredIngredients.Count) return false;
            return !requiredIngredients.Except(fillRequiredIngredients).Any();
        }

        /// <summary>
        /// Returns required ingredients list
        /// </summary>
        /// <returns></returns>
        public List<EIngredient> GetRequiredIngredients()
        {
            return requiredIngredients;
        }
    }
}
