using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.WSummary
{
      public class WSDetails
      {
            public int WSID { get; set; }

            public int WorkoutID { get; set; }

            public int RoutineID { get; set; }

            // public int EquipmentID { get; set; }

            public int ExerciseID { get; set; }
      }
}
