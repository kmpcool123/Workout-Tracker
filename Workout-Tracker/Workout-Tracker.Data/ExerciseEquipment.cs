
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data

{
    public class ExerciseEquipment
    {


        [Key]
        public int EquipmentID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string ExerciseEquipmentName { get; set; }

        [Required]
        public string ExerciseEquipmentDescription { get; set; }

         
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }

    }
}
