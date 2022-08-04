using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    public class Workout
    {
        private Exercise[] _exercises;
        private string _date;
        private int _workoutLength;
        private int _bodyWeight;
        private int _caloriesBurned;

        public Workout(string date, int workoutLength, int caloriesBurned, int bodyWeight, Exercise[] exercises)
        {
            Date = date;
            WorkoutLength = workoutLength;
            CaloriesBurned = caloriesBurned;
            BodyWeight = bodyWeight;
            Exercises = exercises;
        }

        public string Date { get => _date; set => _date = value; }
        public int WorkoutLength { get => _workoutLength; set => _workoutLength = value; }
        public int CaloriesBurned { get => _caloriesBurned; set => _caloriesBurned = value; }
        public int BodyWeight { get => _bodyWeight; set => _bodyWeight = value; }
        public Exercise[] Exercises { get => _exercises; set => _exercises = value; }



        internal static async void CreateWorkout()
        {

            // Get/store today's date
            string date = Convert.ToString(DateTime.Today);

            // Load the default menu/banner
            Menu.DefaultMenu();

            // Get duration from user
            Console.WriteLine("\tEnter workout duration (in minutes):");
            Console.Write("\t>>> ");
            // TODO: Add TryParse validation
            int workoutLength = Convert.ToInt32(Console.ReadLine()) / 60;

            // Load the default menu/banner
            Menu.DefaultMenu();

            // Get user's bodyweight
            Console.WriteLine("\tEnter your weight (in pounds):");
            Console.Write("\t>>> ");
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
            Workout theWorkout = new Workout(date, workoutLength, caloriesBurned, bodyWeight, exercises);

            // Send workout details to Data class for formatting
            string formattedWorkout = Data.FormatWorkout(theWorkout, exercises);

            // Display banner
            Menu.DefaultMenu();

            // Print the workout to the screen
            Console.Write(formattedWorkout);

            // Show the results to the user and wait
            Thread.Sleep(1000);

            Menu.SaveMenu(formattedWorkout);

        }

    }
}
