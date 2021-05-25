using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workout_Tracker.Models;
using Workout_Tracker.Services;

namespace Workout_Tracker.Controllers
{
      [Authorize]
      public class WorkoutController : ApiController
      {
            private WorkoutService CreateWorkoutService()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());

                  var wService = new WorkoutService(userId);

                  return wService;
            }

            public IHttpActionResult Post(WorkoutCreate workout)
            {
                  if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                  var Service = CreateWorkoutService();

                  if (!Service.CreateWorkout(workout))
                  {
                        return InternalServerError();
                  }

                  return Ok("Workout successfully Created");
            }


            public IHttpActionResult Get()
            {
                  WorkoutService wService = CreateWorkoutService();

                  var content = wService.GetAllWorkout();

                  return Ok(content);
            }


            public IHttpActionResult GetByID(int workoutID)
            {

                  WorkoutService wService = CreateWorkoutService();

                  var content = wService.GetWorkoutbyID(workoutID);

                  return Ok(content);
            }


            public IHttpActionResult GetByName(string workoutName)
            {

                  WorkoutService wService = CreateWorkoutService();

                  var content = wService.GetWorkoutByName(workoutName);

                  return Ok(content);
            }


            public IHttpActionResult Put(WorkoutEdit workout)
            {
                  if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                  var wService = CreateWorkoutService();

                  if (!wService.UpdateListItem(workout))
                  {
                        return InternalServerError();
                  }

                  return Ok("Content Successfully Updated");
            }

            public IHttpActionResult Delete(int workoutID)
            {
                  if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                  var wService = CreateWorkoutService();

                  if (!wService.DeleteWorkout(workoutID))
                  {
                        return InternalServerError();
                  }

                  return Ok("Workout Successfully removed");
            }
      }
}
