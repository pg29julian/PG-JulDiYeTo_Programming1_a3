namespace A3
{
    public class GameManager
    {
        private Bartender bartender; // bartender instance
        private Inventory inventory; // inventory instance
        private UIManager uiManager;

        private int score;
        private const int AngryCustomerLimit = 5; // The limit that marks the amount of angry customers a player can have before losing
        private int angryCustomerCounter; // The current amount of angry customers a player has in their record

        private bool isGameOver;

        // Constructor
        public GameManager(UIManager uiManager)
        {
            inventory = new Inventory();
            this.uiManager = uiManager;

            var startingCustomers = new Customer[3];
            for (int i = 0; i < startingCustomers.Length; i++)
            {
                startingCustomers[i] = new Customer(inventory);
            }

            bartender = new Bartender(startingCustomers);
        }

        /// <summary>
        /// Core gameplay loop function
        /// </summary>
        public void GameLoop()
        {
            while (true)
            {
                // Print current orders
                Utils.PrintLn("Your current orders:", ETextColor.Yellow);
                Utils.PrintEmptyLn();

                var customers = bartender.GetCustomers();
                var ingredients = new List<EIngredient>();
                var moods = new List<int>();
                foreach (var customer in customers)
                {
                    ingredients.AddRange(customer.GetOrder().GetRequiredIngredients());
                    moods.Add(customer.GetMoodLevel());
                }
                
                uiManager.PrintOrders(ingredients, moods);
                Utils.PrintEmptyLn();
                
                // Wait 5 seconds, then clear console
                Thread.Sleep(5000);
                Console.Clear();
                Thread.Sleep(500);

                // Select the customer to serve
                var selectedCustomer = Utils.Input("User please select the customer to serve. Type '1', '2' or '3'.", ETextColor.Yellow, 1, 3);
                var actualSelectedCustomer = selectedCustomer - 1;
                bartender.SelectCustomer(actualSelectedCustomer);
                
                // Make a drink
                bartender.MakeDrink(bartender.GetCustomers()[actualSelectedCustomer].GetOrder(), inventory, uiManager);
                
                // Deliver the drink
                var bSuccess = bartender.DeliverDrink();
                if (bSuccess) AddToScore(500);
                Utils.PrintLn("Your score: " + score, ETextColor.Yellow);
                
                Utils.EmptyInput("Press ENTER to continue...", ETextColor.Blue);

                // Decrease mood level of all other costumers
                foreach (var customer in customers)
                {
                    if (customer != customers[actualSelectedCustomer])
                        customer.DecreaseMoodLevel();
                }
                TryAddNewCustomer();
                
                // End the game if angry customer counter is at limit
                if (angryCustomerCounter < AngryCustomerLimit) continue;
                FireBartender();
                break;
            }
        }

        /// <summary>
        /// Returns a new customer instance
        /// </summary>
        private void TryAddNewCustomer()
        {
            var customers = bartender.GetCustomers();

            for (int i = 0; i < customers.Length; i++) 
            {
                if (!customers[i].GetIfInBar())
                {
                    bartender.ReplaceCustomer(new Customer(inventory), i);
                    
                    // If not served correctly, add to Angry Customers
                    if (!customers[i].GetSuccessfullyServed())
                    {
                        AddToAngryCustomers();
                    }
                }
            }
        }

        #region Utility Functions

        /// <summary>
        /// Fires the current Bartender instance
        /// </summary>
        public void FireBartender()
        {
            isGameOver = true;
        }

        /// <summary>
        /// Resets the current bartender
        /// </summary>
        public void ResetBartender()
        {
            var customers = bartender.GetCustomers();
            for (int i = 0; i < customers.Length; i++)
            {
                bartender.ReplaceCustomer(new Customer(inventory), i);
            }

            isGameOver = false;
            score = 0;
            angryCustomerCounter = 0;
        }

        /// <summary>
        /// Adds a defined amount to the angry customer counter, can't be less or equal to 0
        /// </summary>
        private void AddToAngryCustomers()
        {
            angryCustomerCounter += 1;
        }

        /// <summary>
        /// Returns the Angry Customer Limit
        /// </summary>
        /// <returns></returns>
        public int GetAngryCustomerLimit()
        {
            return AngryCustomerLimit;
        }

        /// <summary>
        /// Returns the Angry Customer Count
        /// </summary>
        public int GetAngryCustomerCounter()
        {
            return angryCustomerCounter;
        }

        /// <summary>
        /// Adds the given value to score
        /// </summary>
        public void AddToScore(int scoreToAdd)
        {
            if (scoreToAdd <= 0) scoreToAdd = 0;
            score += scoreToAdd;
        }

        /// <summary>
        /// Returns actual game score
        /// </summary>
        public int GetScore()
        {
            return score;
        }

        /// <summary>
        /// Returns true if game is over
        /// </summary>
        public bool GetGameOver()
        {
            return isGameOver;
        }

        #endregion
    }
}