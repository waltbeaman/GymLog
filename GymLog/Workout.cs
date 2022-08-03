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

        public string Date
        {
            get { return _date; }
            set { _date = value; }
        }
        public int WorkoutLength
        {
            get { return _workoutLength; }
            set { _workoutLength = value; }
        }
        public int CaloriesBurned
        {
            get { return _caloriesBurned; }
            set { _caloriesBurned = value; }
        }
        public int BodyWeight
        {
            get { return _bodyWeight; }
            set { _bodyWeight = value; }
        }
        public Exercise[] Exercises
        {
            get { return _exercises; }
            set { _exercises = value; }
        }

        internal static async void CreateWorkout()
        {

            // Get/store today's date
            string date = Convert.ToString(DateTime.Today);

            // Load the default menu/banner
            Menu.DefaultMenu();

            // Get duration from user
            Console.Write("\t\tEnter workout duration (in minutes): ");
            int workoutLength = Convert.ToInt32(Console.ReadLine()) / 60;

            // Get user's bodyweight
            Console.Write("\t\tEnter your weight (in pounds): ");
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

            string formattedWorkout = Data.FormatWorkout(theWorkout, exercises);

            // Clear the console and display banner
            Console.Clear();
            Menu.DefaultMenu();

            // Print the workout to the screen
            Console.Write(formattedWorkout);

            // Show the results to the user and wait
            Thread.Sleep(1000);
            Console.Write("\t\tWould you like to save your workout to a file? (y/n)");

            //// TODO: Print workout results to text/JSON files and/or SQL DB
            ConsoleKey saveKey = Console.ReadKey(true).Key;

            Data.SaveToTextFile(saveKey, formattedWorkout);

        }

    }
}
