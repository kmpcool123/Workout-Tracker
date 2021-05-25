using System.ComponentModel.DataAnnotations;

namespace Workout_Tracker.Models.RoutineModel
{
    public class RoutineEdit
    {
        [Key]
        public int RoutineID { get; set; }
        public string RoutineName { get; set; }
        public string RoutineDescription { get; set; }
    }
}
