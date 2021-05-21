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
        public string Name { get; set; }
        public DateTime TimeLenght { get; set; }

      
    }
}
