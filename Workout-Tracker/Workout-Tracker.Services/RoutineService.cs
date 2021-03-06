using System;
using System.Collections.Generic;
using System.Linq;
using Workout_Tracker.Data;
using Workout_Tracker.Models;
using Workout_Tracker.Models.RoutineModel;

namespace Workout_Tracker.Services
{

    public class RoutineService
    {
        private readonly Guid _userId;
        public RoutineService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRoutine(RoutineCreate model)
        {
            var entity =
                new Routine()
                {
                    UserId = _userId,
                    RoutineName = model.RoutineName,
                    RoutineDescription = model.RoutineDescription,
                    WorkoutID = model.WorkoutID,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Routines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoutineListItem> GetAllRoutines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Routines
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                            new RoutineListItem
                            {
                                RoutineId = e.RoutineId,
                                RoutineName = e.RoutineName,
                                RoutineDescription = e.RoutineDescription,
                                WorkoutName = e.Workout.WorkoutName,
                                CreatedUtc = e.CreatedUtc,
                                ModifiedUtc = e.ModifiedUtc
                            }
                            );
                return query.ToArray();

            }

        }

        public RoutineDetail GetRoutineById(int routineID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => e.RoutineId == routineID && e.UserId == _userId);
                return
                        new RoutineDetail
                        {
                            RoutineID = entity.RoutineId,
                            RoutineName = entity.RoutineName,
                            RoutineDescription = entity.RoutineDescription,
                            WorkoutName = entity.Workout.WorkoutName,
                            CreatedUtc = entity.CreatedUtc,
                            ModifiedUtc = entity.ModifiedUtc
                        };
            }
        }


        public bool UpdateRoutine(RoutineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => e.RoutineId == model.RoutineID && e.UserId == _userId);

                entity.RoutineName = model.RoutineName;
                entity.RoutineDescription = model.RoutineDescription;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteRoutine(int routineID)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => e.RoutineId == routineID && e.UserId == _userId);

                ctx.Routines.Remove(entity);
                return ctx.SaveChanges() == 1;
            }

        }
    }
}
