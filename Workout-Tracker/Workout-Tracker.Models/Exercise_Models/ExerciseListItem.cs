using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
    public class ExerciseListItem
    {
        public  int ExerciseId { get; set; }

        public string ExerciseName { get; set; }

        public string RoutineID { get; set; }

        public string WorkoutId { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
