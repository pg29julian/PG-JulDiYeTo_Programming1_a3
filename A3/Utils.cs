using System;

namespace A3
{
    /// <summary>
    /// Utility class, contains multiple static helper functions
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Prints text with color in the console
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void Print(string text, ETextColor color)
        {
            // Change console text color
            switch (color)
            {
                case ETextColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ETextColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ETextColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ETextColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
            // Print text, then return console color to org
            Console.Write(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints text with color and a line jump in the console
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void PrintLn(string text, ETextColor color)
        {
            // Change console text color
            switch (color)
            {
                case ETextColor.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case ETextColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case ETextColor.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case ETextColor.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case ETextColor.White:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            // Print text with a line, then return console color to org
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Prints an empty line in the console
        /// </summary>
        public static void PrintEmptyLn()
        {
            // Print an empty line
            Console.WriteLine();
        }

        /// <summary>
        /// Receives an int input and checks its usability
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="minRange"></param>
        /// <param name="maxRange"></param>
        /// <returns></returns>
        public static int Input(string text, ETextColor color, int minRange = -1, int maxRange = -1)
        {
            int newInput = 0;

            do
            {
                PrintLn(text, color);

                var userInput = Console.ReadLine();
                if (userInput != null && IsDigitsOnly(userInput) && userInput != "")
                {
                    newInput = int.Parse(userInput);

                    if (minRange == -1 && maxRange == -1)
                    {
                        break;
                    }
                    else if (newInput >= minRange && newInput <= maxRange)
                    {
                        break;
                    }
                    else
                    {
                        PrintLn("[WARNING] Please input a value in the given range!", ETextColor.Red);
                    }
                }
                else PrintLn("[WARNING] Please write a valid input!", ETextColor.Red);
            }
            while (true);

            return newInput;
        }

        /// <summary>
        /// Receives an string input and checks its usability
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string Input(string text, ETextColor color)
        {
            string newInput = "";

            do
            {
                PrintLn(text, color);

                var userInput = Console.ReadLine();
                if (userInput != null && IsCharactersOnly(userInput) && userInput != "")
                {
                    newInput = userInput;
                    break;
                }
                else PrintLn("[WARNING] Please write a valid input!", ETextColor.Red);
            }
            while (true);

            return newInput;
        }

        /// <summary>
        /// Receives a bool input and checks its usability
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        /// <param name="specificWordOne"></param>
        /// <param name="specificWordTwo"></param>
        /// <returns></returns>
        public static bool Input(string text, ETextColor color, string specificWordOne, string specificWordTwo)
        {
            do
            {
                PrintLn(text, color);

                var userInput = Console.ReadLine();
                if (userInput != null && IsCharactersOnly(userInput) && userInput != "")
                {
                    if (userInput == specificWordOne) return true;
                    else if (userInput == specificWordTwo) return false;
                }
                else PrintLn("[WARNING] Please write a valid input!", ETextColor.Red);
            }
            while (true);
        }

        /// <summary>
        /// Receives an empty input, used for controlling the game timing
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public static void EmptyInput(string text, ETextColor color)
        {
            PrintLn(text, color);
            Console.ReadLine();
        }

        /// <summary>
        /// Returns true if the given string is all digits
        /// </summary>
        /// <param name="givenStr"></param>
        /// <returns></returns>
        public static bool IsDigitsOnly(string givenStr)
        {
            foreach (char c in givenStr)
                if (c < '0' || c > '9')
                    return false;
            return true;
        }

        /// <summary>
        /// Returns true if given string is all characters
        /// </summary>
        /// <param name="givenStr"></param>
        /// <returns></returns>
        public static bool IsCharactersOnly(string givenStr)
        {
            foreach (char c in givenStr)
            {
                if (!Char.IsLetter(c))
                    return false;
            }
            return true;
        }
    }

    #region Definitions

    // Holds the possible text colors to be used during the game
    public enum ETextColor
    {
        Green,
        Red,
        Yellow,
        Blue,
        White
    }

    #endregion
}
