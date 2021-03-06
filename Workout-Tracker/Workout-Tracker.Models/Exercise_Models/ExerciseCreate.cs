using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models
{
    public class ExerciseCreate
    {   
        [Required]
        [MinLength(1, ErrorMessage = "Please enter at least 1 character.")]

        [MaxLength(300, ErrorMessage = "There are too many characters in this field. Max length 300 characters.")]
        public string ExerciseName { get; set; }

        [Required]
        [Display(Name = "Equipment Description")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(250, ErrorMessage = "There are too many characters in this field.")]
        public string ExerciseDescription { get; set; }
        
        
        public int RoutineID { get; set; }
        
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
