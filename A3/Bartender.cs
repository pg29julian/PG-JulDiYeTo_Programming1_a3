using System;

namespace A3
{
    public class Bartender
    {
        List<Customer> _customers;
        EIngredient[] currentPreparation = new EIngredient[3];

        public void MakeDrink(Inventory inv, UIManager ui)
        {
            Drink currentDrink = new Drink(inv);
            EIngredient[] drinkMade = new EIngredient[3];

            for (int i = 0; i < 3; i++)
            {
                ui.PrintMenu();
                drinkMade[i] = (EIngredient)(Convert.ToInt16(Utils.Input("Select one item to add:", ETextColor.White)) - 1);

                ui.PrintCup(i);
            }

            currentPreparation = drinkMade;
        }

        public void DeliverDrink()
        {
            int selectedCustomer;
            // IMPORTANTE
            // Hay que añadir un método en la UI para mostrar los diferentes clientes
            selectedCustomer = (Convert.ToInt16(Utils.Input("Select a customer to deliver this drink:", ETextColor.White)) - 1);
            _customers[selectedCustomer].ReceiveDrink(currentPreparation);
            RemoveCustomer(_customers[selectedCustomer]);
            currentPreparation = null;
        }

        public void ReceiveCustomer(Customer c)
        {
            _customers.Add(c);
        }

        public void RemoveCustomer(Customer c)
        {
            _customers.Remove(c);
        }
    }
}
