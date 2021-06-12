
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data

{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string ExerciseName { get; set; }
        [Required]
        public string ExerciseDescription { get; set; }

        [ForeignKey(nameof(Routine))]
        public int RoutineId { get; set; }
        public virtual Routine Routine { get; set; }

        public virtual Workout Workout { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
