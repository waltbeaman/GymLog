using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    public class Menu
    {
        public string Banner { get; set; } = File.ReadAllText("Banner.txt");
        public string Bottom { get; set; }

        public enum Menus
        {
            MainMenu,
            IntensityMenu,
            DefaultMenu,
            BannerOnly,
            SaveMenu
        }

        public Menu(Menus menuOption)
        {
            Bottom = File.ReadAllText($"{menuOption}.txt");
        }

        public string Display() => Banner + Bottom;

        public static void MainMenu()
        {

            Console.Clear();
            Menu mainMenu = new Menu(Menus.MainMenu);
            Console.Write(mainMenu.Display());
            Console.SetCursorPosition(12, 16);

            // Get menu option from user
            ConsoleKey key = Console.ReadKey(true).Key;

            // Call appropriate method based on user selection
            switch (key)
            {
                case ConsoleKey.D1:
                    Workout.CreateWorkout();
                    break;
                case ConsoleKey.D2:
                    // TODO: add user functionality
                    DefaultMenu("It works!");
                    break;
                case ConsoleKey.D3:
                    // TODO: add user functionality
                    DefaultMenu("It works!");
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\tPlease make a valid selection!");
                    Thread.Sleep(1000);
                    MainMenu();
                    break;
            }
        }

        public static int IntensityMenu()
        {
            Console.Clear();
            Menu intensityMenu = new Menu(Menus.IntensityMenu);
            Console.Write(intensityMenu.Display());
            Console.SetCursorPosition(11, 14);

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
                    Console.WriteLine("\tInvalid selection. Please try again.");
                    Thread.Sleep(1000);
                    Menu.IntensityMenu();
                    break;
            }
            return intensity;
        }

        public static void DefaultMenu(string text)
        {
            Console.Clear();
            Menu defaultMenu = new Menu(Menus.DefaultMenu);
            Console.Write(defaultMenu.Display());
            Console.SetCursorPosition(7, 8);
            Console.Write($"{text}");
        }

        public static void BannerOnly()
        {
            Console.Clear();
            Menu bannerOnly = new Menu(Menus.BannerOnly);
            Console.Write(bannerOnly.Display());
        }

        public static void SaveMenu(string formattedWorkout)
        {
            Console.Clear();
            Menu saveMenu = new Menu(Menus.DefaultMenu);
            Console.Write(saveMenu.Display());
            Console.SetWindowSize(92, 20);
            Console.SetCursorPosition(7, 8);
            Console.Write("\tWould you like to save your workout to a file? (y/n) ");

            //// TODO: Print workout results to text/JSON files and/or SQL DB
            ConsoleKey saveKey = Console.ReadKey(true).Key;
            if (saveKey == ConsoleKey.Y)
            {
                Data.SaveToTextFile(saveKey, formattedWorkout);
                Console.WriteLine("File saved! Goodbye.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else if (saveKey == ConsoleKey.N)
            {
                Environment.Exit(0);
            }
            else
            {
                DefaultMenu("Please make a valid selection. Press 'Y' key to save or 'N' key to quit without saving.");
                //Console.WriteLine("Please make a valid selection. Press 'Y' key to save or 'N' key to quit without saving.");
                Thread.Sleep(2000);
                SaveMenu(formattedWorkout);
            }
        }
    }
}
