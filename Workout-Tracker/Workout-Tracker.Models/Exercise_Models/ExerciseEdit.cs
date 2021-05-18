using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.Exercise_Models
{
    public class ExerciseEdit
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseDescription { get; set; }
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public string WorkoutName { get; set; }
    }
}
