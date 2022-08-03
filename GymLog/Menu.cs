using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    internal static class Menu
    {

        public static string mainMenu = File.ReadAllText("MainMenu.txt");
        public static string intensityMenu = File.ReadAllText("IntensityMenu.txt");
        public static string otherMenu = File.ReadAllText("OtherMenu.txt");
        public static string defaultMenu = File.ReadAllText("DefaultMenu.txt");
        public static string banner = File.ReadAllText("Banner.txt");

        public static void MainMenu()
        {

            Console.Clear();
            Console.Write(banner + mainMenu);


            // Get menu option from user
            ConsoleKey key = Console.ReadKey(true).Key;

            // Call appropriate method based on user selection
            switch (key)
            {
                case ConsoleKey.D1:
                    Workout.CreateWorkout();
                    break;
                case ConsoleKey.D2:
                    // Test code
                    Menu.DefaultMenu();
                    Console.WriteLine("It works!");
                    break;
                case ConsoleKey.D3:
                    Menu.DefaultMenu();
                    Console.WriteLine("It works!");
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\t\tPlease make a valid selection!");
                    Thread.Sleep(1000);
                    MainMenu();
                    break;
            }
        }

        public static int IntensityMenu()
        {
            Console.Clear();
            Console.Write(banner + intensityMenu);

            int intensity = 0;

            ConsoleKey menuKey = Console.ReadKey(true).Key;

            switch (menuKey)
            {
                case ConsoleKey.D1:
                    intensity = 3;
                    break;
                case ConsoleKey.D2:
                    intensity = 5;
                    break;
                case ConsoleKey.D3:
                    intensity = 8;
                    break;
                default:
                    Console.WriteLine("\t\tInvalid selection. Please try again.");
                    Thread.Sleep(1000);
                    Menu.IntensityMenu();
                    break;
            }
            return intensity;
        }

        public static void DefaultMenu()
        {
            Console.Clear();
            Console.Write(banner + defaultMenu);
        }

        public static void OtherMenu()
        {
            Console.Clear();
            Console.Write(banner + otherMenu);
        }
    }

}
