using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.EquipmentModels
{
    public class EquipmentEdit
    {
        public int EquipmentId { get; set; }
        public string ExerciseEquipmentName { get; set; }
        public string ExerciseEquipmentDescription { get; set; }
        public DateTime TimeLenght { get; set; }
    }
}
