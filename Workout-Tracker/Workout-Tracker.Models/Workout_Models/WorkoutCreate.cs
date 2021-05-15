using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
      public class WorkoutCreate
      {
            [Required]
            public Guid UserID { get; set; }

            [Required]
            [Display(Name ="Workout Name")]
            [MinLength(2,ErrorMessage ="Please enter at least 2 characters in this field")]
            [MaxLength(100,ErrorMessage ="There are too many characters in this field.")]
            public string NameOfWorkout { get; set; }

            
            [Required]
            [Display(Name ="Description")]
            [MaxLength(1000)]
            public string Description { get; set; }

            [Required]
            [Display(Name ="Created")]
            public DateTimeOffset CreatedUtc { get; set; }
      }
}
