using System;

namespace A3
{
    /// <summary>
    /// Customer class
    /// </summary>
    public class Customer
    {
        private int moodLevel;
        private Drink order;
        private bool inBar;

        // Constructor
        public Customer(Inventory inv) 
        {
            moodLevel = 3;
            inBar = true;
            order = new Drink(inv);
        }

        /// <summary>
        /// Fills the Customer's order with the given indredients
        /// </summary>
        /// <param name="ingredients"></param>
        public bool ReceiveDrink(List<EIngredient> ingredients)
        {
            // Customer will not receive a Drink if not in store
            if (!inBar) return false;

            // Fill order's ingredients
            order.FillIngredients(ingredients);

            // Check if order's given ingredients are the actual correct ingredients
            if (!order.CheckDrink())
            {
                DecreaseMoodLevel();
                Utils.PrintLn("You have delivered a bad drink to the customer! :(", ETextColor.Red);
                return false;
            }

            Utils.PrintLn("You have delivered the correct order!", ETextColor.Green);
            return true;
        }

        /// <summary>
        /// Decreases Customer's mood level
        /// </summary>
        public void DecreaseMoodLevel()
        {
            moodLevel--;
            if (moodLevel <= 0) inBar = false;
        }

        #region Getters

        /// <summary>
        /// Returs Customer's mood level
        /// </summary>
        public int GetMoodLevel()
        {
            return moodLevel;
        }

        /// <summary>
        /// Returns Customer's order
        /// </summary>
        public Drink GetOrder()
        {
            return order;
        }

        /// <summary>
        /// Returns true if Customer is still in the bar
        /// </summary>
        public bool GetIfInBar()
        {
            return inBar;
        }

        #endregion
    }
}
