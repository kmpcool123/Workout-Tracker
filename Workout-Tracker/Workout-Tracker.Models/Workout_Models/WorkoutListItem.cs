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
           
            public int WorkoutID { get; set; }

            [Display(Name = "Workout_Name")]
            public string WorkoutName { get; set; }

      }
}
