using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;

namespace Workout_Tracker.Models.RoutineModel
{
    public class RoutineDetail
    {
        public string RoutineName { get; set; }
        public string Description { get; set; }
        [ForeignKey(nameof(Workout))]
        public int WorkoutID { get; set; }
        public virtual Workout Workouts { get; set; }
        [ForeignKey(nameof(Exercise))]
        public virtual Exercise Exercises { get; set; }
    }
}
