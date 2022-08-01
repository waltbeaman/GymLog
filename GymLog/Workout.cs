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

        internal static void CreateWorkout()
        {

            // Get/store today's date
            string date = Convert.ToString(DateTime.Today);

            Console.Clear();
            Program.GenerateBanner();

            // Get duration from user
            Console.Write("\t\tEnter workout duration (in minutes): ");
            int workoutLength = Convert.ToInt32(Console.ReadLine()) / 60;

            Console.Clear();
            Program.GenerateBanner();

            // Get user's bodyweight
            Console.Write("\t\tEnter your weight (in pounds): ");
            int bodyWeight = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Program.GenerateBanner();


            int intensity = 0;
            bool state = true;

            while (state)
            {

                Console.Clear();
                Program.GenerateBanner();

                // Get workout intensity
                Console.WriteLine("\t\t╔════════════════════════════════╗");
                Console.WriteLine("\t\t║    SELECT WORKOUT INTENSITY    ║");
                Console.WriteLine("\t\t╟──────┬─────────────────────────╢");
                Console.WriteLine("\t\t║   1  │  Easy (No Sweat)        ║");
                Console.WriteLine("\t\t║   2  │  Moderate (Moist Brow)  ║");
                Console.WriteLine("\t\t║   3  │  Extreme (Sweat City)   ║");
                Console.WriteLine("\t\t╚══════╧═════════════════════════╝");
                Console.Write("\t\t>>> ");
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.D1:
                        intensity = 3;
                        state = false;
                        break;
                    case ConsoleKey.D2:
                        intensity = 5;
                        state = false;
                        break;
                    case ConsoleKey.D3:
                        intensity = 8;
                        state = false;
                        break;
                    default:
                        Console.WriteLine("\t\tInvalid selection. Please try again.");
                        state = true;
                        break;
                }
            }

            // Call method to calculate calories burned and store in variable
            int caloriesBurned = Calculator.CaloriesBurned(intensity, bodyWeight, workoutLength);

            // Add exercises
            Exercise[] exercises = Exercise.AddExercises();


            // Instantiate the new workout
            // Load functions to calculate workout data or gather it from user as applicable
            Workout theWorkout = new(date, workoutLength, caloriesBurned, bodyWeight, exercises);

            Console.Clear();
            Program.GenerateBanner();

            // TODO: Print generic workout title to printable & JSON file
            Console.WriteLine("\t\tWorkout complete! Here are your results:");
            Console.WriteLine();

            // TODO: Print workout date to printable & JSON file
            Console.WriteLine($"\t\tWorkout date: {theWorkout.Date}");

            // TODO: Print duration to printable & JSON file
            Console.WriteLine($"\t\tWorkout duration: {theWorkout.WorkoutLength}");

            // TODO: Print calories to printable & JSON file
            Console.WriteLine($"\t\tCalories burned: {theWorkout.CaloriesBurned}");

            // TODO: Print bodyweight to printable & JSON file
            Console.WriteLine($"\t\tBodyweight: {theWorkout.BodyWeight}");

            // TODO: Print exercises to printable & JSON file
            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine();

                Console.WriteLine($"\t\tExercise #: {exercise.ExerciseID}");
                Console.WriteLine($"\t\tExercise Name: {exercise.ExerciseName}");

                Console.WriteLine();

                Console.WriteLine("\t\tSet #:\tWeight:\tReps:");
                foreach (Exercise.Set exerciseSet in exercise.ExerciseSets)
                {
                    Console.WriteLine($"\t\t{exerciseSet.SetNum}\t{exerciseSet.Weight}\t{exerciseSet.Reps}");
                }

                Console.WriteLine();
            }

            // Show the results to the user and wait
            Thread.Sleep(4000);
            Console.Write("Do you need more time? ");
            Console.ReadLine();

        }

    }
}
