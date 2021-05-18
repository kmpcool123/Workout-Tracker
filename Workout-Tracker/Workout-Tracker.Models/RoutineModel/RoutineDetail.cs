using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.RoutineModel
{
    public class RoutineDetail
    {
        public string NameofRoutine { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Workout))]
        public int WorkoutID { get; set; }
        public virtual List<Workout> ListOfWorkouts { get; set; }
        [ForeignKey(nameof(Exercise))]
        public virtual List<Exercise> ListofExercises { get; set; }
    }
}
