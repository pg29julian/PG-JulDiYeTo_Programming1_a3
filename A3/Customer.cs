using System;

namespace A3
{
    public class Customer
    {
        int _moodLevel;
        Drink _order;

        public Drink Order { get => _order; set => _order = value; }

        public Customer() 
        {
            _moodLevel = 3;
        }

        public Drink OrderDrink(Inventory inv)
        {
            Order = new Drink(inv);
            return Order;
        }

        public void ReceiveDrink(EIngredient[] ingredients)
        {
            _order.FillIngredients(ingredients); // _order drink is filled with the actual ingredients the bartender added

            if (!_order.CheckDrink())
            {
                DecreaseMoodLevel();
                Utils.PrintLn("You have delivered a bad drink to the customer", ETextColor.Red);
            }
        }

        public void DecreaseMoodLevel()
        {
            _moodLevel--;
        }
    }
}
