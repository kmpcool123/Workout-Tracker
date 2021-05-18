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
    public class ExerciseController : ApiController
    {
        private ExerciseService CreateExerciseService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var exerciseService = new ExerciseService(userId);
            return exerciseService;
        }



        public IHttpActionResult Get()
        {
            ExerciseService exerciseService = CreateExerciseService();
            var exercises = exerciseService.GetExercises();
            return Ok(exercises);
        }

        public IHttpActionResult Post(ExerciseCreate exercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateExerciseService();

            if (!service.CreateExercise(exercise))
                return InternalServerError();

            return Ok();

        }
    }
}
