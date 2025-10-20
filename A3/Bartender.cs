using System;
using System.Reflection;

namespace A3
{
    public class Bartender
    {
        private Customer[] customers = new Customer[3]; // List of customers in bar

        private List<EIngredient> ingredientsBatch; // Actual ingredients batch
        private Customer actualCustomer; // Actual customer to be served

        // Constructor
        public Bartender(Customer[] customers)
        {
            this.customers = customers;
            ingredientsBatch = new List<EIngredient>();
        }

        /// <summary>
        /// Chooses the customer to serve
        /// </summary>
        public void SelectCustomer()
        {
            int selectedCustomer = Utils.Input("Select the customer", ETextColor.Blue, 1, 3);
            actualCustomer = customers[selectedCustomer];
        }

        /// <summary>
        /// Fills the ingredients batch with a new set of ingredients depending on the ordered drink
        /// </summary>
        /// <param name="orderedDrink"></param>
        /// <param name="inventory"></param>
        /// <param name="ui"></param>
        public void MakeDrink(Drink orderedDrink, Inventory inventory, UIManager ui)
        {
            for (int i = 0; i < orderedDrink.GetRequiredIngredients().Count; i++) 
            {
                ui.PrintMenu();
                ingredientsBatch.Add(inventory.GetIngredient(Utils.Input("Select one ingredient to add", ETextColor.Blue, 1, 10)));
                ui.PrintCup(i);
            }
        }

        /// <summary>
        /// Delivers drink to customer
        /// </summary>
        /// <param name="ui"></param>
        /// <returns></returns>
        public bool DeliverDrink(UIManager ui)
        {
            bool success = actualCustomer.ReceiveDrink(ingredientsBatch);

            ingredientsBatch.Clear();

            if (success) return true;
            return false;
        }

        /// <summary>
        /// Replace an old customer with a new one
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="index"></param>
        public void ReplaceCustomer(Customer customer, int index)
        {
            customers[index] = customer;
        }

        /// <summary>
        /// Return the customers
        /// </summary>
        public Customer[] GetCustomers()
        {
            return customers;
        }
    }
}