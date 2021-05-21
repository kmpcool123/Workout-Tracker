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
            private readonly Guid  _userId;

            public RoutineService(Guid userID)
            {
                  _userId = userID;
            }

<<<<<<< HEAD
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
=======
        public IEnumerable<Routine> GetAllRoutines()
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
                return query.ToArray();
>>>>>>> b763e21d790c1d42d13ee48cdec2a935a25cbb5e
            }


            public IEnumerable<RoutineListItem> GetAllRoutines()
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var query =
                            ctx
                            .Routines

                            .Select(
                                e =>
                                new RoutineListItem
                                {
                                      RoutineName = e.RoutineName,
                                      RoutineDescription = e.RoutineDescription,
                                      CreatedUtc = e.CreatedUtc
                                });
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
                            .Single(e => e.RoutineId == routineID);
                        return
                                new RoutineDetail
                                {
                                      RoutineID = entity.RoutineId,
                                      RoutineName = entity.RoutineName,
                                      RoutineDescription = entity.RoutineDescription,
                                      WorkoutName = entity.Workout.WorkoutName,
                                      ExerciseName = entity.Exercise.ExerciseName,
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

<<<<<<< HEAD

            public bool RoutineDelete(int routineID)
=======
        public bool DeleteRoutine(int routineID)
        {
            using (var ctx = new ApplicationDbContext())
>>>>>>> b763e21d790c1d42d13ee48cdec2a935a25cbb5e
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
