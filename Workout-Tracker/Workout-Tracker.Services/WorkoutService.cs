using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models;

namespace Workout_Tracker.Services
{
      public class WorkoutService
      {
            private readonly Guid _userID;

            public WorkoutService(Guid userId)
            {
                  _userID = userId;
            }


            public bool CreateWorkout(WorkoutCreate model)
            {
                  var entity =
                        new Workout
                        {
                              UserID = _userID,
                              WorkoutName = model.WorkoutName,
                              Description = model.Description,
                              CreatedUtc = DateTimeOffset.UtcNow
                        };

                  using(var ctx = new ApplicationDbContext())
                  {
                       ctx.Workouts.Add(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }

            public IEnumerable<WorkoutListItem> GetAllWorkout()
            {
                  using(var ctx = new ApplicationDbContext())
                  {
                        var query =
                              ctx
                              .Workouts
                              
                              .Select(e => 
                              new WorkoutListItem
                              {
                                    WorkoutID = e.WorkoutID,
                                    NameOfWorkout = e.WorkoutName,                                   
                              });
                        return query.ToArray();
                                    
                  }
            }

            public WorkoutDetails GetWorkoutbyID(int workoutID)
            {
                  using(var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx.Workouts
                              
                              .Single(e => e.WorkoutID == workoutID);

                        return
                              new WorkoutDetails
                              {
                                    WorkoutID = entity.WorkoutID,
                                    WorkoutName = entity.WorkoutName,
                                    Description = entity.Description,
                                    CreatedUtc = entity.CreatedUtc,
                                    ModifiedUtc = entity.ModifiedUtc
                              };
                  }
            }

            public bool UpdateListItem(WorkoutEdit model)
            {
                  using(var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Workouts
                              .Single(e => e.WorkoutID == model.WorkoutID);

                        entity.WorkoutName = model.WorkoutName;
                        entity.Description = model.Description;
                        entity.ModifiedUtc = DateTimeOffset.UtcNow;

                        return ctx.SaveChanges() == 1;
                  }
            }

            public bool DeleteWorkout(int workoutID)
            {
                  using(var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx
                              .Workouts
                              
                              .Single(e => e.WorkoutID == workoutID);
                        ctx.Workouts.Remove(entity);

                        return ctx.SaveChanges() == 1;
                        
                  }
            }

           
      }
}
