using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    static internal class Menu
    {

        public static void GenerateMenu(int menu)
        {

            string banner = @"
    ╔═════════════════════════════════════════════════════════════════════════════════╗
    ║     ██████╗██╗   ██╗███╗   ███╗██╗      ██████╗  ██████╗      ██╗    ██████╗    ║
    ║    ██╔════╝╚██╗ ██╔╝████╗ ████║██║     ██╔═══██╗██╔════╝     ███║   ██╔═████╗   ║
    ║    ██║  ███╗╚████╔╝ ██╔████╔██║██║     ██║   ██║██║  ███╗    ╚██║   ██║██╔██║   ║
    ║    ██║   ██║ ╚██╔╝  ██║╚██╔╝██║██║     ██║   ██║██║   ██║     ██║   ████╔╝██║   ║
    ║    ╚██████╔╝  ██║   ██║ ╚═╝ ██║███████╗╚██████╔╝╚██████╔╝     ██║██╗╚██████╔╝   ║
    ║     ╚═════╝   ╚═╝   ╚═╝     ╚═╝╚══════╝ ╚═════╝  ╚═════╝      ╚═╝╚═╝ ╚═════╝    ║";

            // TODO: modify the code below to work with GymLog menu options
            // TODO: Combine the GenerateBanner() method with MainMenu() and rename "Menu()"
            string mainMenu = @"
    ╟─────────────────────────────────────────────────────────────────────────────────╢
    ║  SELECT AN OPTION                                                               ║
    ╟──────┬──────────────────────────────────────────────────────────────────────────╢
    ║   1  │  Create Workout                                                          ║
    ║   2  │  View Workout History                                                    ║
    ║   3  │  View One Rep Max                                                        ║
    ║   4  │  Placeholder                                                             ║
    ║  Esc │  Exit Application                                                        ║
    ╚══════╧══════════════════════════════════════════════════════════════════════════╝
    >>> ";
            string workoutMenu = @"
    ╟─────────────────────────────────────────────────────────────────────────────────╢
    ║  MENU TITLE HERE                                                                ║
    ╚═════════════════════════════════════════════════════════════════════════════════╝
";

            string intensityMenu = @"
    ╟─────────────────────────────────────────────────────────────────────────────────╢
    ║                           SELECT WORKOUT INTENSITY                              ║
    ╟──────┬──────────────────────────────────────────────────────────────────────────╢
    ║   1  │  Easy (No Sweat)                                                         ║
    ║   2  │  Moderate (Moist Brow)                                                   ║
    ║   3  │  Extreme (Sweat City)                                                    ║
    ╚══════╧══════════════════════════════════════════════════════════════════════════╝
    >>> ";
            
            
            string menuOptionDefault = @"
    ╚═════════════════════════════════════════════════════════════════════════════════╝
";
            Console.Clear();
            Console.Write(banner);

            switch (menu) // menu is int variable option received when calling the menu function from Main()
            {
                case 1:
                    Console.Write(mainMenu);
                    // Loop main menu until user quits
                    while (true)
                    {
                        // Get menu option from user
                        ConsoleKey key = Console.ReadKey(true).Key;

                        // Call appropriate method based on user selection
                        switch (key)
                        {
                            case ConsoleKey.D1:
                                Program.CreateWorkout();
                                break;
                            case ConsoleKey.D2:
                                Program.ViewWorkoutHistoryTest();
                                break;
                            case ConsoleKey.D3:
                                Program.View1RMTest();
                                break;
                            case ConsoleKey.Escape:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("\t\tPlease make a valid selection!");
                                Thread.Sleep(2000);
                                GenerateMenu(1);
                                break;
                        }
                    }
                    break;
                case 2:
                    Console.Write(workoutMenu);
                    break;
                case 4:
                    // TODO: Add code for intensity selection
                    // Get workout intensity

                    Console.Write(intensityMenu);

                    break;
                default:
                    Console.Write(menuOptionDefault);
                    break;
            }

        }
    }
}
