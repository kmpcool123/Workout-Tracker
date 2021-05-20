using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
      public class RoutineListItem
      {
            public int RoutineID { get; set; }

            public string RoutineName { get; set; }

            public string RoutineDescription { get; set; }

            [Display(Name = "Created")]
            public DateTimeOffset CreatedUtc { get; set; }
      }
}
