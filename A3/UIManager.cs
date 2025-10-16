using System;
using System.Xml.Serialization;

namespace A3
{
    public class UIManager
    {
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

        public void PrintCup(int level)
        {
            switch (level)
            {
                case 0:
                   Console.WriteLine("""
                    \           /
                     \         /
                      \       /
                       \     /
                        \___/
                    """);
                    break;

                case 1:
                    Console.WriteLine("""
                     \           /
                      \         /
                       \       /
                        \-----/
                         \___/ 
                    """);
                    break;
                case 2:
                    Console.WriteLine("""
                    \           /
                     \         /
                      \-------/
                       \     /
                        \___/ 
                    """);
                    break;
                case 3:
                    Console.WriteLine("""
                    \           /
                     \---------/
                      \       /
                       \     /
                        \___/ 
                    """);
                    break;
                default:
                    Console.WriteLine("Invalid cup level.");
                    break;
            }
        }

        //public void PrintAllCups()
        //{
        //    for (int level = 0; level <= 3; level++)
        //    {
        //        Console.WriteLine($"=== Cup level {level} ===");
        //        PrintCup(level);
        //    }
        //}

        public void PrintRecipe(List<EIngredient> ingredients) // TODO: agregar nivel de felicidad del cliente
        {
            //Console.WriteLine($"""
            // ________________________________
            //|                                |  
            //|            Feliz               | 
            //|                                | 
            //|                                | 
            //|     1.  {ingredients[0]}\t| 
            //|                                | 
            //|     2.  {ingredients[1]}\t| 
            //|                                | 
            //|     3.  {ingredients[2]}\t| 
            //|                                | 
            //---------------------------------
            //""");
        }
    }
}
