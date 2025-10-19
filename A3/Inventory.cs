using System;

namespace A3
{
    /// <summary>
    /// Enum that contains every individual ingredient
    /// </summary>
    public enum EIngredient
    {
        Rum, Vodka, Tequila, Gin, Whiskey,
        Lemon, Sugar, Ice, Soda, Mint
    }

    public class Inventory
    {
        /// <summary>
        /// Contains the whole ingredients list
        /// </summary>
        List<EIngredient> ingredients = new List<EIngredient>()
        {
            EIngredient.Rum, EIngredient.Vodka, EIngredient.Tequila, EIngredient.Gin,
            EIngredient.Whiskey, EIngredient.Lemon, EIngredient.Sugar, EIngredient.Ice,
            EIngredient.Soda, EIngredient.Mint
        };

        /// <summary>
        /// Returns the ingredients list
        /// </summary>
        /// <returns></returns>
        public List<EIngredient> GetIngredients()
        {
            return ingredients;
        }
    }
}
