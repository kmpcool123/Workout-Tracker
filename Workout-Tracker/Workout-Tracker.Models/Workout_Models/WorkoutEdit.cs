using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
      public class WorkoutEdit
      {
            [Display(Name ="Workout_ID")]
            public int WorkoutID { get; set; }

            
            [Display(Name = "Workout_Name")]
            [MinLength(2, ErrorMessage = "Please enter at least 2 characters in this field")]
            [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
            public string NameOfWorkout { get; set; }


           
            [Display(Name = "Description")]
            [MaxLength(1000)]
            public string Description { get; set; }
      }
}
