using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workout_Tracker.Data
{

<<<<<<< HEAD
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
            public int ExerciseId { get; set; }

            public virtual Exercise Exercise { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }


      }
=======
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
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }


    }
>>>>>>> b763e21d790c1d42d13ee48cdec2a935a25cbb5e
}
