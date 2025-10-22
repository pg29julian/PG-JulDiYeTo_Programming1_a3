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
            UIManager uiManager = new UIManager();
            GameManager gameManager = new GameManager(uiManager);
            bool gameOn = true;

            while (gameOn) 
            {
                uiManager.PrintInstruction();

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