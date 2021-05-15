using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.RoutineModel
{
    class RoutineEdit
    {
        [Key]
        public int RoutineID { get; set; }
        public string NameofRoutine { get; set; }
        public string Description { get; set; }
    }
}
