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
            [Display(Name ="Workout_ID")]
            public int WorkoutID { get; set; }

            [Display(Name ="Name of Workout")]
            public string NameOfWorkout { get; set; }

            [Display(Name ="Descriptoin")]
            public string  Description { get; set; }

            [Display(Name ="Created")]
            public DateTimeOffset CreatedUtc { get; set; }

            [Display(Name ="Modified")]
            public DateTimeOffset ModifiedUtc { get; set; }


      }
}
