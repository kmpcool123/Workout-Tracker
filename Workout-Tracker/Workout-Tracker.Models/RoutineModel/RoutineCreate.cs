using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Models.RoutineModel
{
    class RoutineCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string NameofRoutine { get; set; }
        [MaxLength(2000)]
        public string Description { get; set; }
    }
}
