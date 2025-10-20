using System;

namespace A3 
{
    /// <summary>
    /// Source
    /// </summary>
    public class Program 
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            bool gameOn = true;

            while (gameOn) 
            {
                // TODO Print introduction to game an tutorial

                // Start game loop
                while (!gameManager.GetGameOver())
                {
                    gameManager.GameLoop();
                }

                // Ask player if he wants to play again
                if (!Utils.Input("Do you wish to start a new game? type 'yes' or 'no'.", ETextColor.Yellow, "yes", "no"))
                {
                    gameOn = false;
                }

                // Reset game logic
                gameManager.ResetBartender();
            }

        }
    }
}