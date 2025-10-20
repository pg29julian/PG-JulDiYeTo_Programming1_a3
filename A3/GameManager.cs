using System;
using System.Reflection;

namespace A3
{
    public class GameManager
    {
        private Bartender bartender; // bartender instance
        private Inventory inventory; // inventory instance

        private int score = 0;
        private const int angryCustomerLimit = 5; // The limit that marks the amount of angry customers a player can have before losing
        private int angryCustomerCounter = 0; // The current amount of angry customers a player has in their record

        private bool isGameOver = false;

        public GameManager()
        {
            inventory = new Inventory();

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
            //while (true)
            //{
            //}
        }

        /// <summary>
        /// Returns a new customer instance
        /// </summary>
        /// <returns></returns>
        public bool TryAddNewCustomer(int index)
        {
            bool bSucess = false;

            var customers = bartender.GetCustomers();

            for (int i = 0; i < customers.Length; i++) 
            {
                if (!customers[i].GetIfInBar())
                {
                    bartender.ReplaceCustomer(new Customer(inventory), index);
                    AddToAngryCustomers();
                    bSucess = true;
                }
            }

            return bSucess;
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
        /// <param name="angryCustomersToAdd"></param>
        public void AddToAngryCustomers()
        {
            angryCustomerCounter += 1;
        }

        /// <summary>
        /// Returns the Angry Customer Limit
        /// </summary>
        /// <returns></returns>
        public int GetAngryCustomerLimit()
        {
            return angryCustomerLimit;
        }

        /// <summary>
        /// Returns the Angry Customer Count
        /// </summary>
        /// <returns></returns>
        public int GetAngryCustomerCounter()
        {
            return angryCustomerCounter;
        }

        /// <summary>
        /// Adds the given value to score
        /// </summary>
        /// <param name="scoreToAdd"></param>
        public void AddToScore(int scoreToAdd)
        {
            if (scoreToAdd <= 0) scoreToAdd = 0;
            score += score;
        }

        /// <summary>
        /// Returns actual game score
        /// </summary>
        /// <returns></returns>
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