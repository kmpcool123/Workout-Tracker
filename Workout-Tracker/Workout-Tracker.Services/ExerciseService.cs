using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models;

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
                    ExerciseName = model.Name,
                    Description = model.Description,
                    CreatedUtc = DateTimeOffset.Now
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
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e =>
                                new ExerciseListItem
                                {
                                    ExerciseId = e.ExerciseId,                                         Name = e.ExerciseName,
                                    CreatedUtc = e.CreatedUtc,

                                }
                        );

                return query.ToArray();
            }
        }


    }
}
