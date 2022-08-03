using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    internal class Calculator
    {
        // Turn numerals into ordinals
        public static string AddOrdinal(int num)
        {
            switch (num)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        // Take user inputs to calculate calories burned
        public static int CaloriesBurned(int intensity, decimal bodyWeight, decimal workoutLength)
        {
            int caloriesBurned = Convert.ToInt32((bodyWeight / 2.205m) * intensity * workoutLength);
            // Console.WriteLine(caloriesBurned);
            return caloriesBurned;

        }

        // TODO: Write code for 1RM calculator

        // TODO: Write code for workout volume calculator
    }
}
