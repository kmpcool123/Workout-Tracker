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
            [Display(Name = "Workout_Name")]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters in this field")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string WorkoutName { get; set; }


            [Required]
            [Display(Name = "Workout_Description")]
            [MaxLength(1000)]
            public string Workout_Description { get; set; }

      }
}
