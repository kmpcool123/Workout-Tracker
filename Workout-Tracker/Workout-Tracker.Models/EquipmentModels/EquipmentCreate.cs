﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.EquipmentModels
{
    public class EquipmentCreate
    {
        [Required]
        [Display(Name = "Equipment Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ExerciseEquipmentName { get; set; }

        [Required]
        [Display(Name = "Equipment Description")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ExerciseEquipmentDescription { get; set; }

        public int? ExerciseID { get; set; }


        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
