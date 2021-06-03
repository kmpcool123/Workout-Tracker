using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models;
using Workout_Tracker.Models.Routine_Exercise_Models;

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
        public IEnumerable<ExerciseListItem> GetExercises()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        .Select(e =>

                               new ExerciseListItem
                               {
                                   ExerciseId = e.ExerciseId,
                                   ExerciseName = e.ExerciseName
                               });

                return query.ToArray();
            }

        }

        //=====Get all Routine_Exercises list by RoutineId
        public IEnumerable<ExerciseListItem> GetExercisebyRoutineId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        .Where(e => e.Routine.RoutineId == id)
            }
        }
    }
}
