using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models.WSummary;

namespace Workout_Tracker.Services
{
      public class wsService
      {
            private readonly Guid _userID;

            public wsService(Guid userId)
            {
                  _userID = userId;
            }

            public bool Create(WSCreate model)
            {
                  var entity =
                        new WorkoutSummary
                        {
                              WorkoutSummaryID = model.WorkoutSummaryID,
                              ExerciseId = model.ExerciseID,
                        };

                  using (var ctx = new ApplicationDbContext())
                  {
                        ctx.WSummaries.Add(entity);

                        return ctx.SaveChanges() == 1;
                  }
            }

            public WSDetails GetWSbyID(int workoutID)
            {
                  using (var ctx = new ApplicationDbContext())
                  {
                        var entity =
                              ctx.WSummaries

                              .Single(e => e.WorkoutSummaryID == workoutID );

                        return
                              new WSDetails
                              {
                                   WSID = entity.WorkoutSummaryID,
                                   ExerciseID = entity.ExerciseId,
                                   RoutineID = entity.Exercise.RoutineID,
                                   WorkoutID = entity.Exercise.Routine.WorkoutID,  
         
                                    
                              };
                  }
            }
      }
}
