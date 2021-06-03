using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data
{
    public class Routine_Exercise
    {
        [Key]
        public int RoutineExerciseId { get; set; }

        [ForeignKey(nameof(Routine))]
        public int RoutineId { get; set; }
        public virtual Routine Routine { get; set; }
        
        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }

        public virtual Exercise Exercise { get; set; }

        
    }
}
