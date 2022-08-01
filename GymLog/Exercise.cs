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

        }

    }

}

