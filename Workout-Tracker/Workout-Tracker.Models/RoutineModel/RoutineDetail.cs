using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;

namespace Workout_Tracker.Models.RoutineModel
{
    public class RoutineDetail
    {
        public int RoutineID { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
        public string WorkoutName { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
