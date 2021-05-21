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
        public string Name { get; set; }

        [Display(Name = "Time Duration")]
        public DateTime TimeLenght { get; set; }
    }
}
