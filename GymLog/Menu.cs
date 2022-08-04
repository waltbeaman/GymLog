using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region TestCode
// ---------ORION'S MENU CODE---------

// ---------TO BUILD---------
//var menu = new YourNamespace.Menu()
//                .Add(" Create Student", () => yourFunctionHere())
//                .Add(" Create Instructor", () => yourFunctionHere())
//                .Add(" Save Contents", () => yourFunctionHere())
//                .Add(" Read Contents", () => yourFunctionHere())
//                .Add(" Tip Calculator", () => yourFunctionHere())
//                .Add(" Quit", () => Environment.Exit(0));

// ---------CLASS---------
//public class Menu
//{
//    private IList<Option> Options { get; set; }

//    public Menu()
//    {
//        Options = new List<Option>();
//    }

//    public void Display()
//    {
//        Console.Clear();
//        for (int i = 0; i < Options.Count; i++)
//        {
//            Console.WriteLine($"{i + 1}{Options[i].Name}");
//        }
//        Console.WriteLine("Choose an option (corresponding Number): ");
//        int choice;
//        int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out choice);
//        if (choice <= Options.Count && choice > 0)
//        {
//            Options[choice - 1].CallBack();
//        }
//        else
//        {
//            Console.WriteLine("Selection out of range... Try Again");
//            Thread.Sleep(2000);
//            Console.Clear();
//            Display();
//        }
//    }
//    public Menu Add(string option, Action callback)
//    {
//        return Add(new Option(option, callback));
//    }

//    public Menu Add(Option option)
//    {
//        Options.Add(option);
//        return this;
//    }

//}

//public struct Option
//{
//    public string Name { get; set; }
//    public Action CallBack { get; set; }

//    public Option(string name, Action callTo)
//    {
//        Name = name;
//        CallBack = callTo;
//    }

//    public override string ToString()
//    {
//        return Name;
//    }
//}
#endregion

namespace GymLog
{
    public class Menu
    {
        public string Banner { get; set; } = File.ReadAllText("Banner.txt");
        public string Bottom { get; set; }

        public Menu(Menus menuOption)
        {
            Bottom = File.ReadAllText($"{menuOption.ToString()}.txt");
        }

        public enum Menus
        {
            MainMenu,
            IntensityMenu,
            DefaultMenu,
            OtherMenu,
            SaveMenu
        }

        public string Display() => Banner + Bottom;

        public static void MainMenu()
        {

            Console.Clear();
            Menu mainMenu = new Menu(Menus.MainMenu);
            Console.Write(mainMenu.Display());


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
                    DefaultMenu();
                    Console.WriteLine("It works!");
                    break;
                case ConsoleKey.D3:
                    DefaultMenu();
                    Console.WriteLine("It works!");
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

        public static void DefaultMenu()
        {
            Console.Clear();
            Menu defaultMenu = new Menu(Menus.DefaultMenu);
            Console.Write(defaultMenu.Display());
        }

        public static void OtherMenu()
        {
            Console.Clear();
            Menu otherMenu = new Menu(Menus.OtherMenu);
            Console.Write(otherMenu.Display());
        }

        public static void SaveMenu(string formattedWorkout)
        {
            Console.Clear();
            Menu saveMenu = new Menu(Menus.DefaultMenu);
            Console.Write(saveMenu.Display());
            
            Console.WriteLine("\tWould you like to save your workout to a file? (y/n)");
            Console.Write("\t>>> ");

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
                DefaultMenu();
                Console.WriteLine("Please make a valid selection. Press 'Y' key to save or 'N' key to quit without saving.");
                Thread.Sleep(3000);
                SaveMenu(formattedWorkout);
            }
        }
    }
}
