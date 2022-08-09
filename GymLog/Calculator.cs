using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    internal static class Calculator
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

        // TODO: Finish code for 1RM calculator
        public static int OneRepMax(Exercise.Set[] sets)
        {
            int oneRepMax = 0;
            double tempWeight = 0;
            for (int i = 0; i <= sets.Length - 1; i++)
            {
                if (tempWeight > oneRepMax)
                {                    
                    oneRepMax = Convert.ToInt32(tempWeight);
                }
                else
                {
                    tempWeight = sets[i].Weight / (1.0278 - 0.0278 * sets[i].Reps); // weight / ( 1.0278 – 0.0278 × reps )
                }
                
            }

            return oneRepMax;
        }

        // TODO: Finish workout volume calculator
        public static int VolumeCalc(Exercise[] exercises)
        {
            int totalVolume = 0;
            foreach (Exercise exercise in exercises)
            {
                foreach (Exercise.Set set in exercise.ExerciseSets)
                {
                    totalVolume += set.Weight * set.Reps;
                }
            }
            return totalVolume;
        }
    }
}
