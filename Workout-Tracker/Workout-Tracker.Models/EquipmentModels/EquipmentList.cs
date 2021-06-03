using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.EquipmentModels
{
    public class EquipmentList
    {
        [Display(Name = "Equipment ID")]
        public int EquipmentId { get; set; }

        [Display(Name = "Equipment Name")]
        public string ExerciseEquipmentName { get; set; }

        [Display(Name = "Equipment Description")]
        public string ExerciseEquipmentDescription { get; set; }

        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
