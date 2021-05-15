using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        public Guid UserId { get; set; }
        public string ExerciseName { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
