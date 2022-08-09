using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    public class Workout
    {
        public string Date { get; set; } = Convert.ToString(DateTime.Now); // Always use today's date for new workouts
        public decimal WorkoutLength { get; set; }
        public int CaloriesBurned { get; set; }
        public int BodyWeight { get; set; }
        public int TotalVolume { get; set; }
        public Exercise[] Exercises { get; set; }

        public Workout(decimal workoutLength, int caloriesBurned, int bodyWeight, Exercise[] exercises)
        {
            WorkoutLength = workoutLength;
            CaloriesBurned = caloriesBurned;
            BodyWeight = bodyWeight;
            Exercises = exercises;
            TotalVolume = Calculator.VolumeCalc(exercises); // Calculate the total volume from constructor
        }


        public static void CreateWorkout()
        {
            // Load the default menu/banner
            Menu.DefaultMenu("Enter workout duration (in minutes):  >>> ");

            // Get duration from user
            // TODO: Add TryParse validation
            decimal workoutLength = Convert.ToDecimal(Console.ReadLine()) / 60;


            // Load the default menu/banner
            Menu.DefaultMenu("Enter your weight (in pounds):  >>> ");

            // Get user's bodyweight
            // TODO: Add TryParse validation
            int bodyWeight = Convert.ToInt32(Console.ReadLine());

            // Declare and initialize intensity variable
            int intensity = Menu.IntensityMenu();

            // Call method to calculate calories burned and store in variable
            int caloriesBurned = Calculator.CaloriesBurned(intensity, bodyWeight, workoutLength);

            // Add exercises
            Exercise[] exercises = Exercise.AddExercises();

            // Instantiate the new workout
            // Load functions to calculate workout data or gather it from user as applicable
            Workout theWorkout = new Workout(workoutLength, caloriesBurned, bodyWeight, exercises);

            // Send workout details to Data class for formatting
            string printWorkoutToFile = Data.FormatWorkout(theWorkout, Data.PrintType.ToFile);
            string printWorkoutToConsole = Data.FormatWorkout(theWorkout, Data.PrintType.ToConsole);

            // Display banner
            Menu.DefaultMenu("WORKOUT SUMMARY");

            // Print the workout to the screen
            Console.WriteLine("\n\n\n");
            Console.SetWindowSize(92, 50);
            Console.Write($"{printWorkoutToConsole}");
            Thread.Sleep(2000);
            Console.WriteLine("\n\tPress any key to continue.");
            Console.ReadKey();
            Menu.SaveMenu(printWorkoutToFile);

        }

    }
}
