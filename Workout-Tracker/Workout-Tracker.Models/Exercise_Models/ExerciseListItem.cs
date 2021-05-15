using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
    public class ExerciseListItem
    {
        public  int ExerciseId { get; set; }

        public string Name { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
