using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
      public class WorkoutDetails
      {
            
            public int WorkoutID { get; set; }

            [Display(Name = "Workout_Name")]
            public string WorkoutName { get; set; }

            [Display(Name = "Workout_Description")]
            public string Workout_Description { get; set; }


            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name = "Modified")]
            public DateTimeOffset? ModifiedUtc { get; set; }

      }
}
