// References:
//  - Calories burned: https://www.health.harvard.edu/diet-and-weight-loss/calories-burned-in-30-minutes-for-people-of-three-different-weights
//  - Calculate 1RM: https://www.athlegan.com/calculate-1rm

// TODO LIST:
//   1. Move all Console.* functions to Program and Menu classes to make code more reusable.--DONE
//   2. Move methods to appropriate classes (outside of Program)
//   3. Write code the 1RM calculator.
//   4. Write code for SQL/JSON database connection.
//   5. Add exception handling.
//   6. Modify menus to be called from the Menu class.--DONE
//   7. Add improved design elements if sufficient time:
//          a. Set cursor position to be inside a box.
//          b. Create more aesthetic formatting of workout data.
//          c. Improve menu design.
using System.Text;

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

            // Load main menu
            Menu.MainMenu();

        }
    }
}