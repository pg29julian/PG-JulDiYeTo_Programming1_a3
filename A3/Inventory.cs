using System;

namespace A3
{
    public class Inventory
    {
        /// <summary>
        /// Contains the whole ingredients list
        /// </summary>
        private List<EIngredient> ingredients;

        // Constructor
        public Inventory()
        {
            ingredients = new List<EIngredient>()
            {
                EIngredient.Rum, EIngredient.Vodka, EIngredient.Tequila, EIngredient.Gin,
                EIngredient.Whiskey, EIngredient.Lemon, EIngredient.Sugar, EIngredient.Ice,
                EIngredient.Soda, EIngredient.Mint
            };
        }

        /// <summary>
        /// Returns the ingredients list
        /// </summary>
        /// <returns></returns>
        public List<EIngredient> GetIngredients()
        {
            return ingredients;
        }

        /// <summary>
        /// Returns an ingredient depending on the provided index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public EIngredient GetIngredient(int index) 
        {
            return (EIngredient)index;
        }
    }

    /// <summary>
    /// Enum that contains every individual ingredient
    /// </summary>
    public enum EIngredient
    {
        Rum = 1, Vodka = 2, Tequila = 3, Gin = 4, Whiskey = 5,
        Lemon = 6, Sugar = 7, Ice = 8, Soda = 9, Mint = 10
    }
}
