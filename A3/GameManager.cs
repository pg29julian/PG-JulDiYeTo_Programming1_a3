using System;

namespace A3
{
    /// <summary>
    /// Handles the game's main components and flow
    /// </summary>
    public class GameManager
    {
        #region Variables

        // The limit that marks the amount of angry customers a player can have before losing
        private const int angryCustomerLimit = 5;

        // The current amount of angry customers a player has in their record
        private int angryCustomerCounter;

        #endregion

        #region Constructor

        public GameManager() 
        {
            angryCustomerCounter = 0;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Adds a defined amount to the angry customer counter, can't be less or equal to 0
        /// </summary>
        /// <param name="angryCustomersToAdd"></param>
        public void AddAngryCustomers(int angryCustomersToAdd)
        {
            if (angryCustomersToAdd <= 0) angryCustomersToAdd = 0;
            angryCustomerCounter += angryCustomersToAdd;
        }

        /// <summary>
        /// Returns a new customer instance
        /// </summary>
        /// <returns></returns>
        public Customer CreateCustomer()
        {
            return new Customer();
        }

        /// <summary>
        /// Returns a new Bartender instance
        /// </summary>
        /// <returns></returns>
        public Bartender CreateBartender()
        {
            return new Bartender();
        }

        /// <summary>
        /// Fires the current Bartender instance
        /// </summary>
        public void FireBartender()
        {

        }

        #endregion

        #region Utility Functions

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
        /// Resets the Angry Customer Counter
        /// </summary>
        public void ResetAngryCustomerCounter()
        {
            angryCustomerCounter = 0;
        }

        #endregion
    }
}
