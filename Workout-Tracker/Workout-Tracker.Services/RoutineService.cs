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
                    RoutineName = model.RoutineName,
                    RoutineDescription = model.RoutineDescription,
                    CreatedUtc = DateTimeOffset.Now
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
                    .Where(e => .UserId == _userId)
                    .Select(
                        e =>
                        new RoutineDetail
                        {
                            RoutineName = e.RoutineName,
                            RoutineDescription = e.RoutineDescription,
                            Workout = e.Workout,
                            Exercise = e.Exercise,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
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
                    .Single(e => e.RoutineID == model.RoutineID && e.UserId == _userId);

                entity.RoutineName = model.RoutineName;
                entity.RoutineDescription = model.RoutineDescription;

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
