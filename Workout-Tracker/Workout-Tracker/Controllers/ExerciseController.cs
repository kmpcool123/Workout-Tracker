using Microsoft.AspNet.Identity;
using System;
using System.Web.Http;
using Workout_Tracker.Models;
using Workout_Tracker.Models.Exercise_Models;
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

        public IHttpActionResult Get(int id)
        {
            ExerciseService exerciseService = CreateExerciseService();
            var exercise = exerciseService.GetExerciseById(id);
            return Ok(exercise);
        }

        public IHttpActionResult Get(string exerciseName)
        {
            ExerciseService exerciseService = CreateExerciseService();
            var exercise = exerciseService.GetExerciseByName(exerciseName);
            return Ok(exercise);
        }

        public IHttpActionResult Put(ExerciseEdit exercise)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateExerciseService();

            if (!service.UpdateExercise(exercise ))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {

            var service = CreateExerciseService();

            if (!service.DeleteExercise(id))
                return InternalServerError();

            return Ok();
        }
    }
}
