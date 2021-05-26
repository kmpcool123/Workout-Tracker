using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Workout_Tracker.Models.EquipmentModels;
using Workout_Tracker.Services;

namespace Workout_Tracker.Controllers
{
    
    [Authorize]
    public class EquipmentController : ApiController
    {
        //to create an equipment service
        private EquipmentService CreateEquipmetService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var equipmentService = new EquipmentService(userId);
            return equipmentService;
        }

        //to Get All equipment
        public IHttpActionResult Get()
        {
            EquipmentService equipmentService = CreateEquipmetService();
            var equipments = equipmentService.GetEquipments();
            return Ok(equipments);
        }

        //to post an equipment

        public IHttpActionResult Post(EquipmentCreate equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEquipmetService();

            if (!service.CreateEquipment(equipment))
                return InternalServerError();

            return Ok();
        }

        //to Get an equipment by ID
        public IHttpActionResult Get(int id)
        {
            EquipmentService equipmentService = CreateEquipmetService();
            var equipment = equipmentService.GetEquipmentById(id);
            return Ok(equipment);
        }

        //to update an equipment
        public IHttpActionResult Put (EquipmentEdit equipment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEquipmetService();

            if (!service.UpdateEquipment(equipment))
                return InternalServerError();

            return Ok();
        }

        //to Delete an equipment by id
        public IHttpActionResult Delete(int id)
        {
            var service = CreateEquipmetService();

            if (!service.DeleteExerciseEquipment(id))
                return InternalServerError();

            return Ok();

        }
    }
}
