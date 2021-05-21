﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Data
{
    public class Equipment
    {
        [Key]
        public int EquipmentID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime TimeLenght { get; set; }

        [ForeignKey(nameof(Exercise))]
        public int ExericeId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
