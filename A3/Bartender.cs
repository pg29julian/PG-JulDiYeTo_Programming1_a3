
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
        /// Fills the ingredients batch with a new set of ingredients depending on the ordered drink
        /// </summary>
        public void MakeDrink(Drink orderedDrink, Inventory inventory, UIManager ui)
        {
            for (int i = 0; i < orderedDrink.GetRequiredIngredients().Count; i++) 
            {
                Console.Clear();
                ui.PrintMenu();
                ingredientsBatch.Add(inventory.GetIngredient(Utils.Input("Select one ingredient to add", ETextColor.Blue, 1, 10)));
                ui.PrintCup(i + 1);
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Delivers drink to customer
        /// </summary>
        public bool DeliverDrink()
        {
            Console.Clear();
            Utils.PrintLn("You delivered the drink to the customer...", ETextColor.Yellow);
            
            bool success = actualCustomer.ReceiveDrink(ingredientsBatch);
            ingredientsBatch.Clear();

            if (success) return true;
            return false;
        }
        
        /// <summary>
        /// Chooses the customer to serve
        /// </summary>
        public void SelectCustomer(int selectedCustomer)
        {
            actualCustomer = customers[selectedCustomer];
        }

        /// <summary>
        /// Replace an old customer with a new one
        /// </summary>
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