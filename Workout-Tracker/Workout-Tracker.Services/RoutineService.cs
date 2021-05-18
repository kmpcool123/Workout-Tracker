using System;
using System.Linq;
using Workout_Tracker.Data;
using Workout_Tracker.Models.RoutineModel;

namespace Workout_Tracker.Services
{
    public class RoutineService
    {
        private readonly Guid _userId;
        public bool CreateRoutine(RoutineCreate model)
        {
            var entity =
                new Routine()
                {
                    NameofRoutine = model.NameofRoutine,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Routine.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public RoutineDetail GetRoutine()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routine
                    .Where(e =>.UserId == _userId)
                    .Select(
                        e =>
                        new RoutineDetail
                        {
                            NameOfRoutine = e.NameofRoutine,
                            Description = e.Description,
                            Workout = e.ListofWorkout,
                            Exercise = e.ListofExercise
                        });
                return entity.ToArray();
            }
        }

        public bool UpdateRoutine(RoutineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routine
                    .Single(e => e.RoutineId == model.RoutineID && e.UserId == _userId);

                entity.NameOfRoutine = model.NameofRoutine;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool RoutineDelete(int routineID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routine
                    .Single(e => e.RoutineId == routineID && e.UserId == _userId);

                ctx.Routine.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
