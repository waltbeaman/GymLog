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

        public int ExerciseID
        {
            get { return _exerciseID; }
            set { _exerciseID = value; }
        }
        public string ExerciseName
        {
            get { return _exerciseName; }
            set { _exerciseName = value; }
        }
        public Set[] ExerciseSets
        {
            get { return _exerciseSets; }
            set { _exerciseSets = value; }
        }

        // this method will generate an exercise, based on the exercise class and load it to memory

        public static Exercise[] AddExercises()
        {

            // Clear screen and load fresh banner
            Console.Clear();
            Program.GenerateBanner();

            // Request number of sets for current exercise from user
            Console.Write("\t\tHow many exercises would you like to add? ");
            int numOfExercises = Convert.ToInt32(Console.ReadLine());

            // Clear screen and load fresh banner
            Console.Clear();
            Program.GenerateBanner();

            Console.WriteLine($"\t\tOkay, adding {numOfExercises} exercises.\n");

            Console.Clear();
            Program.GenerateBanner();

            // Create an empty array for the sets using the input #
            Exercise[] exerciseArray = new Exercise[numOfExercises];

            int arrayPosition = 0;

            for (int i = 1; i <= numOfExercises; i++)
            {

                Console.Clear();
                Program.GenerateBanner();

                Console.WriteLine($"\t\tWhich was the {Calculator.AddOrdinal(i)} exercise you performed?");
                Console.Write("\t\t>>> ");
                string exerciseName = Console.ReadLine();

                Set[] sets = Set.AddSets(exerciseName);

                Exercise exercise = new(i, exerciseName, sets);

                exerciseArray[arrayPosition] = exercise;

                Console.WriteLine($"\t\t{Calculator.AddOrdinal(i)} exercise added!");
                Thread.Sleep(2000);

                arrayPosition++;

            }

            return exerciseArray;
        }

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

            public int SetNum
            {
                get { return _setNum; }
                set { _setNum = value; }
            }
            public int Weight
            {
                get { return _weight; }
                set { _weight = value; }
            }
            public int Reps
            {
                get { return _reps; }
                set { _reps = value; }
            }

            public static Set[] AddSets(string exerciseName)
            {

                string thisExercise = exerciseName;

                // Clear screen and load fresh banner
                Console.Clear();
                Program.GenerateBanner();

                // Request number of sets for current exercise from user
                Console.Write($"\t\tHow many sets of {thisExercise} would you like to add? ");
                int numOfSets = Convert.ToInt32(Console.ReadLine());

                // Clear screen and load fresh banner
                Console.Clear();
                Program.GenerateBanner();

                Console.WriteLine($"\t\tOkay, adding {numOfSets} sets of {thisExercise}.\n");
                Thread.Sleep(3000);

                // Create an empty array for the sets using the input #
                Set[] exerciseSetArray = new Set[numOfSets];

                int arrayPosition = 0;

                for (int i = 1; i <= numOfSets; i++)
                {

                    Console.Clear();
                    Program.GenerateBanner();

                    Console.Write($"\tHow much weight did you lift for your {Calculator.AddOrdinal(i)} set of {thisExercise}? ");
                    int Weight = Convert.ToInt32(Console.ReadLine());
                    //Console.Clear();
                    //Program.GenerateBanner();
                    Console.Write($"\tHow many reps did you complete for your {Calculator.AddOrdinal(i)} set of {thisExercise}? ");
                    int Reps = Convert.ToInt32(Console.ReadLine());
                    //Console.Clear();
                    //Program.GenerateBanner();
                    Console.WriteLine($"\t\t{Calculator.AddOrdinal(i)} set of {thisExercise} has been added!");
                    Thread.Sleep(2000);
                    //Console.Clear();
                    //Program.GenerateBanner();

                    Set exerciseSet = new(i, Weight, Reps);

                    exerciseSetArray[arrayPosition] = exerciseSet;
                    arrayPosition++;

                }
                PrintSets(exerciseSetArray);

                return exerciseSetArray;

            }

            public static void PrintSets(Set[] exerciseSetArray)
            {
                Console.WriteLine();
                Console.WriteLine("\t\tSet #:\tWeight:\tReps:");
                foreach (Set exerciseSet in exerciseSetArray)
                {
                    Console.WriteLine($"\t\t{exerciseSet.SetNum}\t{exerciseSet.Weight}\t{exerciseSet.Reps}");
                }
                Thread.Sleep(4000);

            }
        }

    }

}

