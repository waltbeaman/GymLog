using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymLog
{
    internal class Data
    {
        public static string FormatWorkout(Workout theWorkout, Exercise[] exercises)
        {
            // TODO: Fix formatting and create separate options for printing to console and file
            StringBuilder fileHeaderString = new StringBuilder();
            fileHeaderString.Append("╔══════════════════════════════════════════════╗").AppendLine();
            fileHeaderString.Append("║          GYMLOG WORKOUT SHEET           ║").AppendLine();
            fileHeaderString.Append("╚══════════════════════════════════════════════╝").AppendLine();
            fileHeaderString.Append($"Workout date: {theWorkout.Date} \n" +
                                    $"Workout duration: {theWorkout.WorkoutLength} \n" +
                                    $"Bodyweight: {theWorkout.BodyWeight} \n" +
                                    $"Calories burned: { theWorkout.CaloriesBurned} \n" +
                                    $"Bodyweight: {theWorkout.BodyWeight} \n").AppendLine();


            StringBuilder exerciseString = new();

            foreach (Exercise exercise in exercises)
            {
                exerciseString.AppendLine();

                exerciseString.Append($"Exercise #: {exercise.ExerciseID}\n" +
                                      $"Exercise Name: {exercise.ExerciseName}").AppendLine();

                exerciseString.AppendLine();

                // TODO: Improve results formatting: 
                exerciseString.Append("Set #:\tWeight:\t\tReps:").AppendLine();
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
                    Console.WriteLine("\t\tInvalid selection. Please try again.");
                    SaveToTextFile(saveKey, formattedWorkout);
                    break;

            }
        }
    }
}
