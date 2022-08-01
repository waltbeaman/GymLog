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


    }
}
