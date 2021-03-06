using System;
using System.ComponentModel.DataAnnotations;

namespace Workout_Tracker.Models
{

    public class RoutineCreate
    {
        public int RoutineId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string RoutineName { get; set; }
        [MaxLength(2000)]
        public string RoutineDescription { get; set; }
        public int WorkoutID { get; set; }
        public int ExerciseID { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }

      
}
