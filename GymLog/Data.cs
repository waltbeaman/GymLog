using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    public static class Data
    {
        public enum PrintType
        {
            ToFile,
            ToConsole
        }

        public static string FormatWorkout(Workout theWorkout, PrintType printType)
        {
            StringBuilder fileHeaderString = new StringBuilder();
            // Add title line if printing to file
            if (printType == PrintType.ToFile)
            {
                fileHeaderString.Append("════════════ GYMLOG WORKOUT SHEET ════════════").AppendLine();
            }
            
            fileHeaderString.Append($"Workout date: {theWorkout.Date}\n" +
                                    $"Workout duration: {Math.Round(theWorkout.WorkoutLength, 2)} hours\n" +
                                    $"Bodyweight: {theWorkout.BodyWeight} pounds\n" +
                                    $"Calories burned: { theWorkout.CaloriesBurned} calories\n" +
                                    $"Total volume: { theWorkout.TotalVolume} pounds\n").AppendLine();


            StringBuilder exerciseString = new StringBuilder();

            foreach (Exercise exercise in theWorkout.Exercises)
            {
                exerciseString.AppendLine();

                exerciseString.Append($"Exercise #: {exercise.ExerciseID}\n" +
                                      $"Exercise Name: {exercise.ExerciseName}\n" +
                                      $"Est. 1RM: {exercise.EstOneRepMax} pounds").AppendLine();

                exerciseString.AppendLine();

                // TODO: Improve results formatting: 
                exerciseString.Append("Set #:\t\tWeight:\t\tReps:").AppendLine();
                foreach (Exercise.Set exerciseSet in exercise.ExerciseSets)
                {
                    exerciseString.Append($"{exerciseSet.SetNum}\t\t{exerciseSet.Weight}\t\t{exerciseSet.Reps}").AppendLine();
                }

                exerciseString.AppendLine();
            }
            string completeString = fileHeaderString.ToString() + exerciseString.ToString();

            return completeString.ToString();
        }

        public static async void SaveToTextFile(ConsoleKey saveKey, string formattedWorkout)
        {
            switch (saveKey)
            {
                case ConsoleKey.Y:
                    await File.WriteAllTextAsync("SavedWorkout.txt", formattedWorkout);
                    Environment.Exit(0);
                    break;
                case ConsoleKey.N:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\tInvalid selection. Please try again.");
                    SaveToTextFile(saveKey, formattedWorkout);
                    break;

            }
        }
    }
}
