using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data
{
      public class WorkoutSummary
      {
            [Key]
            public int WorkoutSummaryID { get; set; }

            [Required]
            public Guid UserID { get; set; }

            [ForeignKey(nameof(Equipment))]
            public int EquipmentId { get; set; }
            public virtual ExerciseEquipment Equipment { get; set; }

      }
}
