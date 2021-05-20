using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Workout_Tracker.Controllers
{
    [Authorize]
    public class RoutineController : ApiController
    {
        private RoutineService CreateRoutineService()
        {
            var userId = Guid.Parse(User.Identit.GetUserId());
            var routineService = new RoutineService(userId);
            return routineService;
        }

        public IHttpActionResult Get()
        {
            CreateRoutineService routineService = CreateRoutineService();
            var routine = routineService.GetAllRoutines();
            return Ok(routine);
        }

        public IHttpActionResult Post(RoutineCreate routine)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoutineService();

            if (!service.CreateRoutine(routine))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            RoutineService routineService = CreateRoutineService();
            var routine = routineService.GetRoutineById(id);
            return Ok(routine);
        }

        public IHttpActionResult Put(RoutineEdit routine)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateRoutineService();
            if(!service.UpdateRoutine(routine))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRoutineService();
            if (!service = DeleteRoutine(id))
                return InternalServerError();
            return Ok();
        }
    }
}