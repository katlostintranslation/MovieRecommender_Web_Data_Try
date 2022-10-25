namespace MovieRecommender2022.Web.MovieRecFunctions
{
    internal static class Menu //static, so we could call it
    {
        public static readonly string Dash = "**************************************";
        internal static string GetUserMenuSelection()
        {
            while (true)
            {
                Console.WriteLine(Dash);
                Console.WriteLine("1 - Add a new movie [A]");
                Console.WriteLine("2 - Delete a movie [D]");
                Console.WriteLine("3 - Find a movie recommendation [F]");
                Console.WriteLine("4 - Exit [E]");
                Console.WriteLine(Dash);

                Console.Write("Please select a menu item: ");

                var input = Console.ReadLine();

                //if (input.Equals("A", StringComparison.InvariantCultureIgnoreCase)
                //    || input.Equals("D", StringComparison.InvariantCultureIgnoreCase)
                //    || input.Equals("F", StringComparison.InvariantCultureIgnoreCase)
                //    || input.Equals("E", StringComparison.InvariantCultureIgnoreCase))
                //{

                //}

                if (IsMenuSelectionValid(input))
                {
                    return input.ToUpper();
                }
            }

        }

        private static bool IsMenuSelectionValid(string userInput) //if item which user selected is valid or not. Access readline value
        {
            var validMenuSelection = new string[] { "A", "D", "F", "E" };

            return validMenuSelection.Contains(userInput.ToUpper()); //if contains, we will get bool true
        }
    }
}
