using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workout_Tracker.Services
{
    public class RoutineService
    {
        public bool CreateRoutine(RoutineCreate model)
        {
            var entity =
                new Routine()
                {
                    Name = model.NameOfRoutine,
                    Description = modle.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Routines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public 
    }
}
