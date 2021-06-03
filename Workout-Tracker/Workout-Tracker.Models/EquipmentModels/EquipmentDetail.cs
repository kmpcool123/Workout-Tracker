using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.EquipmentModels
{
    public class EquipmentDetail
    {
        public int EquipmentId { get; set; }
        public string ExerciseEquipmentName { get; set; }
        public string ExerciseEquipmentDescription { get; set; }
        public string ExerciseName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }


    }
}
