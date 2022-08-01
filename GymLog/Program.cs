// References:
//  - Calories burned: https://www.health.harvard.edu/diet-and-weight-loss/calories-burned-in-30-minutes-for-people-of-three-different-weights
//  - Calculate 1RM: https://www.athlegan.com/calculate-1rm

// TODO LIST:
//   1. Move all Console.* functions to Program and Menu classes to make code more reusable.--DONE
//   2. Instantiate workout and exercise objects from Program class.--DONE
//   3. Write code the 1RM calculator.
//   4. Write code for SQL/JSON database connection.
//   5. Add exception handling.
//   6. Modify menus to be called from the GenerateMenu() method.--DONE
//   7. Add improved design elements if sufficient time:
//          a. Set cursor position to be inside a box.
//          b. Create more aesthetic formatting of workout data.
//          c. Improve menu design.

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

            Menu.GenerateMenu(1);

        }


        internal static void CreateWorkout()
        {

            // Get/store today's date
            string date = Convert.ToString(DateTime.Today);

            Menu.GenerateMenu(1000);

            // Get duration from user
            Console.Write("\t\tEnter workout duration (in minutes): ");
            int workoutLength = Convert.ToInt32(Console.ReadLine()) / 60;

            // Get user's bodyweight
            Console.Write("\t\tEnter your weight (in pounds): ");
            int bodyWeight = Convert.ToInt32(Console.ReadLine());

            int intensity = 0;
            bool state = true;

            while (state)
            {

                Menu.GenerateMenu(4);


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
            Exercise[] exercises = AddExercises();


            // Instantiate the new workout
            // Load functions to calculate workout data or gather it from user as applicable
            Workout theWorkout = new Workout(date, workoutLength, caloriesBurned, bodyWeight, exercises);

            // TODO: Print workout results to text/JSON files and/or SQL DB
            Console.WriteLine("\t\tWorkout complete! Here are your results:");
            Console.WriteLine();
            Console.WriteLine($"\t\tWorkout date: {theWorkout.Date}");
            Console.WriteLine($"\t\tWorkout duration: {theWorkout.WorkoutLength}");
            Console.WriteLine($"\t\tCalories burned: {theWorkout.CaloriesBurned}");
            Console.WriteLine($"\t\tBodyweight: {theWorkout.BodyWeight}");

            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine();

                Console.WriteLine($"\t\tExercise #: {exercise.ExerciseID}");
                Console.WriteLine($"\t\tExercise Name: {exercise.ExerciseName}");

                Console.WriteLine();

                // TODO: Improve results formatting
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

            Menu.GenerateMenu(1);

        }


        // this method will generate an exercise, based on the exercise class and load it to memory

        public static Exercise[] AddExercises()
        {

            // Clear screen and load fresh banner
            Menu.GenerateMenu(1000);

            // Request number of sets for current exercise from user
            Console.Write("\t\tHow many exercises would you like to add? ");
            int numOfExercises = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\t\tOkay, adding {numOfExercises} exercises.\n");

            // Create an empty array for the sets using the input #
            Exercise[] exerciseArray = new Exercise[numOfExercises];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfExercises; i++)
            {

                Menu.GenerateMenu(1000);

                Console.WriteLine($"\t\tWhat was the {Calculator.AddOrdinal(i)} exercise you performed?");
                Console.Write("\t\t>>> ");
                string exerciseName = Console.ReadLine();

                Exercise.Set[] sets = AddSets(exerciseName);

                Exercise exercise = new(i, exerciseName, sets);

                exerciseArray[arrayPosition] = exercise;

                Console.WriteLine($"\t\t{Calculator.AddOrdinal(i)} exercise added!");
                Thread.Sleep(2000);

                arrayPosition++;

            }

            return exerciseArray;
        }


        public static Exercise.Set[] AddSets(string exerciseName)
        {

            string thisExercise = exerciseName;

            // Clear screen and load fresh banner
            Menu.GenerateMenu(1000);

            // Request number of sets for current exercise from user
            Console.Write($"\t\tHow many sets of {thisExercise} would you like to add? ");
            int numOfSets = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\t\tOkay, adding {numOfSets} sets of {thisExercise}.\n");

            // Create an empty array for the sets using the input #
            Exercise.Set[] exerciseSetArray = new Exercise.Set[numOfSets];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfSets; i++)
            {

                Menu.GenerateMenu(1000);

                Console.Write($"\t\tHow much weight did you lift for your {Calculator.AddOrdinal(i)} set of {thisExercise}? ");
                int Weight = Convert.ToInt32(Console.ReadLine());
                //Console.Clear();
                //Program.GenerateBanner();
                Console.Write($"\t\tHow many reps did you complete for your {Calculator.AddOrdinal(i)} set of {thisExercise}? ");
                int Reps = Convert.ToInt32(Console.ReadLine());
                //Console.Clear();
                //Program.GenerateBanner();
                Console.WriteLine($"\t\t{Calculator.AddOrdinal(i)} set of {thisExercise} has been added!");
                Thread.Sleep(2000);
                //Console.Clear();
                //Program.GenerateBanner();

                Exercise.Set exerciseSet = new(i, Weight, Reps);

                exerciseSetArray[arrayPosition] = exerciseSet;
                arrayPosition++;

            }
            PrintSets(exerciseSetArray);

            return exerciseSetArray;

        }


        public static void PrintSets(Exercise.Set[] exerciseSetArray)
        {
            Console.WriteLine();
            Console.WriteLine("\t\tSet #:\tWeight:\tReps:");
            foreach (Exercise.Set exerciseSet in exerciseSetArray)
            {
                Console.WriteLine($"\t\t{exerciseSet.SetNum}\t{exerciseSet.Weight}\t{exerciseSet.Reps}");
            }
            Thread.Sleep(4000);

        }


        // Test methods for main menu
        // TODO: DELETE THESE!
        public static void CreateWorkoutTest()
        {
            Menu.GenerateMenu(1000);
            Console.WriteLine("\t\tIt works!");
            Thread.Sleep(2000);
        }


        public static void ViewWorkoutHistoryTest()
        {
            Menu.GenerateMenu(1000);
            Console.WriteLine("\t\tIt works!");
            Thread.Sleep(2000);
        }

        public static void View1RMTest()
        {
            Menu.GenerateMenu(1000);
            Console.WriteLine("\t\tIt works!");
            Thread.Sleep(2000);
        }

    }
}