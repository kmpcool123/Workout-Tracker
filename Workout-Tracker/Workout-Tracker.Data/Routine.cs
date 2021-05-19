using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workout_Tracker.Data
{

    public class Routine
    {
        [Key]
        public int RoutineID { get; set; }
        public string RoutineName { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Workout))]
        public int WorkoutID { get; set; }

        public virtual Workout Workout { get; set; }
        


    }
}
