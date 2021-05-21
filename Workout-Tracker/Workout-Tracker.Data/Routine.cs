using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workout_Tracker.Data
{

    public class Routine
    {
        [Key]
        public int RoutineId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
        [ForeignKey(nameof(Workout))]
        public int WorkoutID { get; set; }

        public virtual Workout Workout { get; set; }
        [ForeignKey(nameof(Exercise))]
        public int ExerciseID { get; set; }
        public virtual Exercise Exercise { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
