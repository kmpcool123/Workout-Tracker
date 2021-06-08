using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models;
using Workout_Tracker.Models.Routine_Exercise_Models;
using Workout_Tracker.Models.RoutineModel;

namespace Workout_Tracker.Services
{
    public class Routine_ExerciseService
    {
        private readonly Guid _userId;

        public Routine_ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        //=====Create Routine_Exercise===//
        public bool CreateRoutine_Exercise(Routine_ExerciseCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                new Routine_Exercise()
                {
                    RoutineId = model.RoutineId,
                    ExerciseId = model.ExerciseId,
                };

                ctx.Routine_Exercises.Add(entity);
                return ctx.SaveChanges() >= 1;
            }
        }

        //=====Get all Routine_Exercises===//
        public IEnumerable<RoutineListItem> GetRoutine()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Routines
                        .Select(e =>

                               new RoutineListItem
                               {
                                   RoutineId = e.RoutineId,
                                   RoutineName = e.RoutineName,
                                   ExerciseName = e.Exercise.ExerciseName,
                                   
                               });

                return query.ToArray();
            }

        }

        //=====Get all Routine_Exercises list by RoutineId
        public IEnumerable<RoutineListItem> GetExercisesbyRoutine(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Routines
                        .Where(e => e.RoutineId == id)
                        .Select(
                            e =>
                                new RoutineListItem
                                {
                                    RoutineName = e.RoutineName,
                                    RoutineId = e.RoutineId,
                                    ExerciseName = e.Exercise.ExerciseName,
                                });
                return query.ToArray();
            }
        }

        public RoutineDetail GetRoutineById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Routines
                        .Single(e => e.RoutineId == id);

                return
                    new RoutineDetail
                    {
                        RoutineName = entity.RoutineName,
                        RoutineID = entity.RoutineId,
                        ExerciseName = entity.Exercise.ExerciseName,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,


                    };
            }
                
        }

        //====Update a Routine_Exercise by Id====//

        public bool UpdateRoutine(RoutineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Routines
                        .Single(e => e.RoutineId == model.RoutineID);

                entity.RoutineName = model.RoutineName;
                entity.RoutineDescription = model.RoutineDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        //====Delete Routine_Exercise by Id=====//

        public bool DeleteRoutine_(int routineId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Routines
                        .Single(e => e.RoutineId == routineId);

                ctx.Routines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
