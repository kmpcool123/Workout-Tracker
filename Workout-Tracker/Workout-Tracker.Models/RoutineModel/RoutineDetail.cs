using System;
using System.ComponentModel.DataAnnotations;

namespace Workout_Tracker.Models
{
      public class RoutineDetail
      {
            public int RoutineID { get; set; }

            public string RoutineName { get; set; }

            public string RoutineDescription { get; set; }

            public string WorkoutName { get; set; }

            public string ExerciseName { get; set; }

            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset? ModifiedUtc { get; set; }
      }
}
