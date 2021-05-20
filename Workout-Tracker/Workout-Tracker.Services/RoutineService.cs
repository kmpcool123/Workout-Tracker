using System;
using System.Collections.Generic;
using System.Linq;
using Workout_Tracker.Data;
using Workout_Tracker.Models;
using Workout_Tracker.Models.RoutineModel;

namespace Workout_Tracker.Services
{
  /*  public class RoutineService
    {
        private readonly Guid _userId;
        public bool CreateRoutine(RoutineCreate model)
        {
            var entity =
                new Routine()
                {
                    UserId = _userId,
                    RoutineName = model.RoutineName,
                    RoutineDescription = model.RoutineDescription,
                    WorkoutID = WorkoutID,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Routines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExerciseListItem> GetAllRoutines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Routines
                    .Where(e => e.UserId == _userId)
                    .Select(
                        e =>
                        new Routine
                        {
                            RoutineName = e.RoutineName,
                            RoutineDescription = e.RoutineDescription,
                            WorkoutID = e.WorkoutID,
                            ExerciseId = e.ExerciseId,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        });
            }
        }

        public RoutineDetail GetRoutineById(int routineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Routines
                    .Single(e => .UserId == _userId);
                return
                        new RoutineDetail
                        {
                            RoutineName = e.RoutineName,
                            RoutineDescription = e.RoutineDescription,
                            WorkoutID = e.WorkoutID,
                            ExerciseId = e.ExerciseId,
                            CreatedUtc = e.CreatedUtc,
                            ModifiedUtc = e.ModifiedUtc
                        });
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

        public bool RoutineDelete(int routineID)
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
    }*/
}
