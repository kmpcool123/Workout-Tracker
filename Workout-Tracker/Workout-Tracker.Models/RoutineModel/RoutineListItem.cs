using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.RoutineModel
{
    public class RoutineListItem
    {
        public int RoutineId { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
        public string WorkoutName { get; set; }
        public string ExerciseName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
