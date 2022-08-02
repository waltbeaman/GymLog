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
            StringBuilder fileHeaderString = new StringBuilder();
            fileHeaderString.Append($"Workout date: {theWorkout.Date} \n" +
                                    $"Workout duration: {theWorkout.WorkoutLength} \n" +
                                    $"Bodyweight: {theWorkout.BodyWeight} \n" +
                                    $"Calories burned: { theWorkout.CaloriesBurned} \n" +
                                    $"Bodyweight: {theWorkout.BodyWeight} \n").AppendLine();


            StringBuilder exerciseString = new StringBuilder();

            foreach (Exercise exercise in exercises)
            {
                exerciseString.AppendLine();

                exerciseString.Append($"Exercise #: {exercise.ExerciseID}" +
                                      $"Exercise Name: {exercise.ExerciseName}").AppendLine();

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
    }
}
