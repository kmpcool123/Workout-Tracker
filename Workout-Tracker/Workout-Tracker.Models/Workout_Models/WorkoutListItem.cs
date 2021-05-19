using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
      public class WorkoutListItem
      {
            [Display(Name = "Workout_ID")]
            public int WorkoutID { get; set; }

            [Display(Name = "Workout Name")]
            public string WorkoutName { get; set; }

      }
}
