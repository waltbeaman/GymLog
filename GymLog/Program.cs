// References:
//  - Calories burned: https://www.health.harvard.edu/diet-and-weight-loss/calories-burned-in-30-minutes-for-people-of-three-different-weights
//  - Calculate 1RM: https://www.athlegan.com/calculate-1rm

// TODO LIST:
//   1. Move all Console.* functions to Program class to make code more reusable.
//   2. Instantiate workout and exercise objects from Program class.
//   3. Write code the 1RM calculator.
//   4. Write code for SQL/JSON database connection.
//   5. Modify menus to be called from the MainMenu() method.
//   6. Add improved design elements if sufficient time:
//          a. Set cursor position to be inside a box.
//          b. Create more aesthetic formatting of workout data.
//          c. Improve menu design.

namespace GymLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set console parameters
            Console.Title = "GymLog 1.0";
            Console.SetWindowSize(92, 30);
            Console.BackgroundColor = ConsoleColor.DarkBlue;

            MainMenu();

        }

        public static void MainMenu()
        {

            // Loop main menu until user quits
            while (true)
            {
                // Create menu
                Console.Clear();
                GenerateBanner();
                Console.Write(@"
                            ╔═════════════════════════════╗
                            ║   PLEASE MAKE A SELECTION   ║
                            ╟─────┬───────────────────────╢
                            ║  1  │ Create Workout        ║
                            ║  2  │ View Workout History  ║
                            ║  3  │ View One-Rep Max      ║
                            ║ Esc │ Exit Application      ║
                            ╚═════╧═══════════════════════╝
                            >>> ");

                // Get menu option from user
                ConsoleKey key = Console.ReadKey(true).Key;

                // Call appropriate method based on user selection
                switch (key)
                {
                    case ConsoleKey.D1:
                        Workout.CreateWorkout();
                        break;
                    case ConsoleKey.D2:
                        ViewWorkoutHistoryTest();
                        break;
                    case ConsoleKey.D3:
                        View1RMTest();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        GenerateBanner();
                        Console.WriteLine("\t\tPlease make a valid selection!");
                        Thread.Sleep(2000);
                        break;
                }
            }



        }

        public static void GenerateBanner()
        {

            Console.WriteLine(@"
    ╔═════════════════════════════════════════════════════════════════════════════════╗
    ║     ██████╗██╗   ██╗███╗   ███╗██╗      ██████╗  ██████╗      ██╗    ██████╗    ║
    ║    ██╔════╝╚██╗ ██╔╝████╗ ████║██║     ██╔═══██╗██╔════╝     ███║   ██╔═████╗   ║
    ║    ██║  ███╗╚████╔╝ ██╔████╔██║██║     ██║   ██║██║  ███╗    ╚██║   ██║██╔██║   ║
    ║    ██║   ██║ ╚██╔╝  ██║╚██╔╝██║██║     ██║   ██║██║   ██║     ██║   ████╔╝██║   ║
    ║    ╚██████╔╝  ██║   ██║ ╚═╝ ██║███████╗╚██████╔╝╚██████╔╝     ██║██╗╚██████╔╝   ║
    ║     ╚═════╝   ╚═╝   ╚═╝     ╚═╝╚══════╝ ╚═════╝  ╚═════╝      ╚═╝╚═╝ ╚═════╝    ║
    ╚═════════════════════════════════════════════════════════════════════════════════╝
");

            // TODO: modify the code below to work with GymLog menu options
            // TODO: Combine the GenerateBanner() method with MainMenu() and rename "Menu()"
            //            string menuOption1 = @"
            // ║        MENU TITLE HERE          ║
            // ╚═════════════════════════════════════════════════════════════════════════════════╝
            //";
            //            string menuOption2 = @"
            // ║        MENU TITLE HERE          ║
            // ╚═════════════════════════════════════════════════════════════════════════════════╝
            //";
            //            string menuOptionDefault = @"
            // ║        MENU TITLE HERE          ║
            // ╚═════════════════════════════════════════════════════════════════════════════════╝
            //";
            //            switch (menu) // menu is int variable option received when calling the menu function from Main()
            //            {
            //                case 1:
            //                    Console.Write();
            //                    break;
            //                case 2:
            //                    Console.Write();
            //                    break;
            //                default:
            //                    Console.Write();
            //                    break;
            //            }

        }


        // Test methods for main menu
        public static void CreateWorkoutTest()
        {
            Console.Clear();
            GenerateBanner();
            Console.WriteLine("\t\tIt works!");
            Thread.Sleep(2000);
        }


        public static void ViewWorkoutHistoryTest()
        {
            Console.Clear();
            GenerateBanner();
            Console.WriteLine("\t\tIt works!");
            Thread.Sleep(2000);
        }

        public static void View1RMTest()
        {
            Console.Clear();
            GenerateBanner();
            Console.WriteLine("\t\tIt works!");
            Thread.Sleep(2000);
        }

    }
}