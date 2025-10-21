using System;
using System.Xml.Serialization;

namespace A3
{
    public class UIManager
    {
        public void PrintInstruction()
        {
            Console.WriteLine($"""
            ==============================================================================================
                                                 INSTRUCTIONS
            
                     Congratulations on your new job as a bartender at the bar "The Happy Cup"!



            Your goal is to serve drinks to your customers based on their recipe cards.

            Each recipe card contains 3 ingredients that must be added to the cup in order to satisfy the 
            customer, they will be appearing 3 at a time for 5 seconds. You have to select and memorize 
            the ingredients for a recipe and then add them to the cup one by one to create the drink.

            Each customer has a mood level that will be affected by how well you serve them.

            If 3 customers leave angry, you'll be fired!

            ==============================================================================================

            Press ENTER to start the game...

            """);
        }

        /// <summary>
        /// Helper method that prints the ingredient selection menu
        /// </summary>
        public void PrintMenu()
        {
            Console.WriteLine("""
            ===================================================================
                        Select an ingredient to add to your cup:

               1. Rum      2. Vodka     3. Tequila     4. Gin      5. Whiskey
               6. Lemon    7. Sugar     8. Ice         9. Soda     10. Mint
            ===================================================================


            """);
        }

        /// <summary>
        /// Helper method that prints the cup depending on its current level to indicate how full it is
        /// </summary>
        public void PrintCup(int level)
        {
            switch (level)
            {
                case 0: /// If the level is 0, the cup is empty
                   Console.WriteLine("""
                    \           /
                     \         /
                      \       /
                       \     /
                        \___/
                    """);
                    break;

                case 1: /// If the level is 1, the cup has just one ingredient
                    Console.WriteLine("""
                     \           /
                      \         /
                       \       /
                        \-----/
                         \___/ 
                    """);
                    break;
                case 2: /// If the level is 2, the cup has two ingredients
                    Console.WriteLine("""
                    \           /
                     \         /
                      \-------/
                       \     /
                        \___/ 
                    """);
                    break;
                case 3: /// If the level is 3, the cup is full
                    Console.WriteLine("""
                    \           /
                     \---------/
                      \       /
                       \     /
                        \___/ 
                    """);
                    break;
                default: /// If the's any other value, it's invalid
                    Console.WriteLine("Invalid cup level.");
                    break;
            }
        }

        /// <summary>
        /// Helper method that prints the recipe cards of the three customers
        /// </summary>
        /// The method receives three lists of ingredients and a list of mood levels, one for each customer
        public void PrintRecipe(List<EIngredient> ingredients1, List<EIngredient> ingredients2, List<EIngredient> ingredients3,
            List<int> moods)
        {
            Console.WriteLine($"""
             ________________________________        ________________________________         ________________________________
            |                                |      |                                |       |                                |
            |{Center(PrintEmotion(moods[0]),32)}|      |{Center(PrintEmotion(moods[1]),32)}|       |{Center(PrintEmotion(moods[2]),32)}|
            |                                |      |                                |       |                                |
            |                                |      |                                |       |                                |
            |        1.  {ingredients1[0],-20}|      |        1.  {ingredients2[0],-20}|       |        1.  {ingredients3[0],-20}|
            |                                |      |                                |       |                                |
            |        2.  {ingredients1[1],-20}|      |        2.  {ingredients2[1],-20}|       |        1.  {ingredients3[1],-20}|
            |                                |      |                                |       |                                |
            |        3.  {ingredients1[2],-20}|      |        3.  {ingredients2[2],-20}|       |        3.  {ingredients3[2],-20}|
            |                                |      |                                |       |                                | 
            |________________________________|      |________________________________|       |________________________________|
            """);
        }

        /// <summary>
        /// Helper method that returns an emotion string depending on the mood level provided
        /// </summary>
        public string PrintEmotion(int moodLevel)
        {
            if (moodLevel == 3) return ":)"; /// If the mood is 3, the client is happy
            else if (moodLevel == 2)return ":|"; /// If the mood is 2, the client is neutral
            else if (moodLevel == 1) return ">:("; /// If the mood is 1, the client is angry
            else return "X("; /// If the mood is 0, the client is very angry and is now gone
        }

        /// <summary>
        /// Helper method that centers a string within a given width
        /// </summary>
        static string Center(string s, int width)
        {
            if (string.IsNullOrEmpty(s)) return new string(' ', width);
            if (s.Length >= width) return s.Substring(0, width);
            int left = (width - s.Length) / 2;
            return new string(' ', left) + s + new string(' ', width - left - s.Length);
        }
    }
}
