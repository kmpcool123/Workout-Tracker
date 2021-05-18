using System.ComponentModel.DataAnnotations;

namespace Workout_Tracker.Models.RoutineModel
{
    public class RoutineEdit
    {
        [Key]
        public int RoutineID { get; set; }
        public string NameofRoutine { get; set; }
        public string Description { get; set; }
    }
}
