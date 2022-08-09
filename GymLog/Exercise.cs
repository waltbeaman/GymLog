using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    public class Exercise
    {
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public Set[] ExerciseSets { get; set; }
        public int EstOneRepMax { get; set; }

        public Exercise(int exerciseID, string exerciseName, Set[] exerciseSets)
        {
            ExerciseID = exerciseID;
            ExerciseName = exerciseName;
            ExerciseSets = exerciseSets;
            EstOneRepMax = Calculator.OneRepMax(ExerciseSets);
        }

        public class Set
        {
            public int SetNum { get; set; }
            public int Weight { get; set; }
            public int Reps { get; set; }

            public Set(int setNum, int weight, int reps)
            {
                SetNum = setNum;
                Weight = weight;
                Reps = reps;
            }
        }

        public static Exercise[] AddExercises()
        {

            // Clear screen and load fresh banner
            Menu.DefaultMenu("How many exercises would you like to add ?  >>> ");

            // Request number of sets for current exercise from user
            int numOfExercises = Convert.ToInt32(Console.ReadLine());
            
            //Menu.DefaultMenu($"Okay, adding {numOfExercises} exercises.");

            // Create an empty array for the sets using the input #
            Exercise[] exerciseArray = new Exercise[numOfExercises];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfExercises; i++)
            {

                Menu.DefaultMenu($"What was the {Calculator.AddOrdinal(i)} exercise you performed?  >>> ");

                string exerciseName = Console.ReadLine();

                Set[] sets = AddSets(exerciseName);

                Exercise exercise = new(i, exerciseName, sets);

                exerciseArray[arrayPosition] = exercise;

                Menu.DefaultMenu($"{Calculator.AddOrdinal(i)} exercise added!");
                Thread.Sleep(500);

                arrayPosition++;

            }

            return exerciseArray;
        }


        public static Set[] AddSets(string exerciseName)
        {

            string thisExercise = exerciseName;

            // Clear screen and load fresh banner
            Menu.DefaultMenu($"How many sets of {thisExercise} would you like to add?  >>> ");

            // Request number of sets for current exercise from user
            // TODO: Add TryParse validation
            int numOfSets = Convert.ToInt32(Console.ReadLine());

            Menu.DefaultMenu($"Okay, adding {numOfSets} sets of {thisExercise}.");

            // Create an empty array for the sets using the input #
            Set[] exerciseSetArray = new Set[numOfSets];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfSets; i++)
            {

                Menu.DefaultMenu($"How much weight did you lift for your {Calculator.AddOrdinal(i)} set of {thisExercise}?  >>> ");

                // TODO: Add TryParse validation
                int Weight = Convert.ToInt32(Console.ReadLine());

                Menu.DefaultMenu($"How many reps did you complete for your {Calculator.AddOrdinal(i)} set of {thisExercise}?  >>> ");

                // TODO: Add TryParse validation
                int Reps = Convert.ToInt32(Console.ReadLine());

                Menu.DefaultMenu($"{Calculator.AddOrdinal(i)} set of {thisExercise} has been added!");
                Thread.Sleep(500);

                Set exerciseSet = new Set(i, Weight, Reps);

                exerciseSetArray[arrayPosition] = exerciseSet;
                arrayPosition++;

            }
            PrintSetsToConsole(exerciseSetArray);

            return exerciseSetArray;

        }


        public static void PrintSetsToConsole(Set[] exerciseSetArray)
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tSet #:\tWeight:\tReps:");
            foreach (Set exerciseSet in exerciseSetArray)
            {
                Console.WriteLine($"\t{exerciseSet.SetNum}\t{exerciseSet.Weight}\t\t{exerciseSet.Reps}");
            }
            Thread.Sleep(1000);

        }

    }

}

