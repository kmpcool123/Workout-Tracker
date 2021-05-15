using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data
{
    public class Routine
    {
        [Key]
        public int RoutineID { get; set; }
        public string NameofRoutine { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Workout))]
        public int WorkoutID { get; set; }
        public virtual List<Workout> ListOfWorkouts { get; set; }
        [ForeignKey(nameof(Exercise))]
        public virtual List<Exercise> ListofExercises { get; set; }

    }
}
