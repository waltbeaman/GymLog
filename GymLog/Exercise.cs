using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    public class Exercise
    {
        private int _exerciseID;
        private string _exerciseName;
        private Set[] _exerciseSets;

        public Exercise(int exerciseID, string exerciseName, Set[] exerciseSets)
        {
            ExerciseID = exerciseID;
            ExerciseName = exerciseName;
            ExerciseSets = exerciseSets;
        }

        public int ExerciseID { get => _exerciseID; set => _exerciseID = value; }
        public string ExerciseName { get => _exerciseName; set => _exerciseName = value; }
        public Set[] ExerciseSets { get => _exerciseSets; set => _exerciseSets = value; }
        
        public class Set
        {
            private int _setNum;
            private int _weight;
            private int _reps;

            public Set(int setNum, int weight, int reps)
            {
                SetNum = setNum;
                Weight = weight;
                Reps = reps;
            }

            public int SetNum { get => _setNum; set => _setNum = value; }
            public int Weight { get => _weight; set => _weight = value; }
            public int Reps { get => _reps; set => _reps = value; }

        }

        public static Exercise[] AddExercises()
        {

            // Clear screen and load fresh banner
            Menu.DefaultMenu();

            // Request number of sets for current exercise from user
            Console.WriteLine("\tHow many exercises would you like to add?");
            Console.Write("\t>>> ");
            int numOfExercises = Convert.ToInt32(Console.ReadLine());
            
            Menu.DefaultMenu();
            
            Console.WriteLine($"\tOkay, adding {numOfExercises} exercises.\n");

            // Create an empty array for the sets using the input #
            Exercise[] exerciseArray = new Exercise[numOfExercises];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfExercises; i++)
            {

                Menu.DefaultMenu();

                Console.WriteLine($"\tWhat was the {Calculator.AddOrdinal(i)} exercise you performed?");
                Console.Write("\t>>> ");
                string exerciseName = Console.ReadLine();

                Set[] sets = AddSets(exerciseName);

                Exercise exercise = new(i, exerciseName, sets);

                exerciseArray[arrayPosition] = exercise;

                Console.WriteLine($"\t{Calculator.AddOrdinal(i)} exercise added!");
                Thread.Sleep(500);

                arrayPosition++;

            }

            return exerciseArray;
        }


        public static Set[] AddSets(string exerciseName)
        {

            string thisExercise = exerciseName;

            // Clear screen and load fresh banner
            Menu.DefaultMenu();

            // Request number of sets for current exercise from user
            Console.WriteLine($"\tHow many sets of {thisExercise} would you like to add?");
            Console.Write("\t>>> ");
            // TODO: Add TryParse validation
            int numOfSets = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"\tOkay, adding {numOfSets} sets of {thisExercise}.\n");

            // Create an empty array for the sets using the input #
            Exercise.Set[] exerciseSetArray = new Exercise.Set[numOfSets];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfSets; i++)
            {

                Menu.DefaultMenu();

                Console.WriteLine($"\tHow much weight did you lift for your {Calculator.AddOrdinal(i)} set of {thisExercise}?");
                Console.Write("\t>>> ");
                // TODO: Add TryParse validation
                int Weight = Convert.ToInt32(Console.ReadLine());

                Menu.DefaultMenu();

                Console.WriteLine($"\tHow many reps did you complete for your {Calculator.AddOrdinal(i)} set of {thisExercise}? ");
                Console.Write("\t>>> ");
                // TODO: Add TryParse validation
                int Reps = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine($"\t{Calculator.AddOrdinal(i)} set of {thisExercise} has been added!");
                Thread.Sleep(500);

                Set exerciseSet = new Set(i, Weight, Reps);

                exerciseSetArray[arrayPosition] = exerciseSet;
                arrayPosition++;

            }
            PrintSets(exerciseSetArray);

            return exerciseSetArray;

        }


        public static void PrintSets(Set[] exerciseSetArray)
        {
            Console.WriteLine();
            Console.WriteLine("\tSet #:\tWeight:\tReps:");
            foreach (Set exerciseSet in exerciseSetArray)
            {
                Console.WriteLine($"\t{exerciseSet.SetNum}\t{exerciseSet.Weight}\t\t{exerciseSet.Reps}");
            }
            Thread.Sleep(1000);

        }

    }

}

