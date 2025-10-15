using System;

namespace A3
{
    public class Drink
    {
        Random rnd = new Random(); // Random generator
        private string recipeName;
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
        /// Returns recipe name
        /// </summary>
        /// <returns></returns>
        public string GetRecipeName()
        {
            return recipeName;
        }

        /// <summary>
        /// Returns required ingredients list
        /// </summary>
        /// <returns></returns>
        public List<EIngredient> GetRequiredIngredients()
        {
            return requiredIngredients;
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
    }
}
