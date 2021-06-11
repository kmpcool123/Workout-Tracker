using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workout_Tracker.Models.WSummary;
using Workout_Tracker.Services;

namespace Workout_Tracker.Controllers
{
      [Authorize]
      public class WSummaryController : ApiController
      {
            private wsService CreateWorkoutS()
            {
                  var userId = Guid.Parse(User.Identity.GetUserId());

                  var wService = new wsService(userId);

                  return wService;
            }

            public IHttpActionResult Post(WSCreate workout)
            {
                  if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                  var Service = CreateWorkoutS();

                  if (!Service.Create(workout))
                  {
                        return InternalServerError();
                  }

                  return Ok();
            }

            public IHttpActionResult GetById(int WSId)
            {
                  wsService wService = CreateWorkoutS();

                  var content = wService.GetWSbyID(WSId);

                  return Ok(content);
            }
      }
}
