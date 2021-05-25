using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models;
using Workout_Tracker.Models.Exercise_Models;

namespace Workout_Tracker.Services
{
    public class ExerciseService
    {
        private readonly Guid _userId;

        public ExerciseService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateExercise(ExerciseCreate model)
        {
            var entity =
                new Exercise()
                {
                    UserId = _userId,
                    ExerciseName = model.ExerciseName,
                    ExerciseDescription = model.ExerciseDescription,
                    CreatedUtc = DateTimeOffset.UtcNow,
                    RoutineID = model.RoutineID,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Exercises.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ExerciseListItem> GetExercises()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Exercises
                        
                        .Select(
                            e =>
                                new ExerciseListItem
                                {

                                    ExerciseId = e.ExerciseId,
                                    ExerciseName = e.ExerciseName, 
                                    RoutineName = e.Routine.RoutineName,
                                    WorkoutName = e.Routine.Workout.WorkoutName,
                                    CreatedUtc = e.CreatedUtc,

                                }
                        );

                return query.ToArray();
            }
        }

        public ExerciseDetail GetExerciseById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == id && e.UserId == _userId);

                return
                new ExerciseDetail
                {
                    ExerciseId = entity.ExerciseId,
                    ExerciseName = entity.ExerciseName,
                    ExerciseDescription = entity.ExerciseDescription,
                    RoutineName = entity.Routine.RoutineName,
                    WorkoutName = entity.Routine.Workout.WorkoutName,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc

                };
            }
        }
        public ExerciseDetail GetExerciseByName(string exerciseName)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseName == exerciseName && e.UserId == _userId);

                return
                new ExerciseDetail
                {
                    ExerciseId = entity.ExerciseId,
                    ExerciseName = entity.ExerciseName,
                    ExerciseDescription = entity.ExerciseDescription,
                    RoutineName = entity.Routine.RoutineName,
                    WorkoutName = entity.Routine.Workout.WorkoutName,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc

                };
            }

        }
        public bool UpdateExercise(ExerciseEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == model.ExerciseId && e.UserId == _userId);

                entity.ExerciseName = model.ExerciseName;
                entity.ExerciseDescription = model.ExerciseDescription;
                entity.RoutineID = model.RoutineId;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteExercise(int exerciseId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Exercises
                        .Single(e => e.ExerciseId == exerciseId && e.UserId == _userId);

                ctx.Exercises.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
