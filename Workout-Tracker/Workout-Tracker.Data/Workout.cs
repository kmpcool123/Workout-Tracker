using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data

{
      public class Workout
      {
            [Key]
            public int WorkoutID { get; set; }           

            [Required]
            public Guid UserID { get; set; }

            [Required]
            public string WorkoutName { get; set; }

            [Required]
            public string Workout_Description { get; set; }

            [Required]
            public DateTimeOffset CreatedUtc { get; set; }

            public DateTimeOffset? ModifiedUtc { get; set; }

          //  [ForeignKey(nameof(Routine))]
          //  public int RoutineID { get; set; }

          //  public virtual Routine Routine { get; set; }
      }
}
