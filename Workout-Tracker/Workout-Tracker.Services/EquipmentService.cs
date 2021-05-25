using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;
using Workout_Tracker.Models.EquipmentModels;

namespace Workout_Tracker.Services
{
    public class EquipmentService
    {
        //a constructor and a private field of type Guid
        private readonly Guid _userId;
        public EquipmentService (Guid userId)
        {
            _userId = userId;
        }

        //Create an Equipment 
        public bool CreateEquipment (EquipmentCreate model)
        {
            var entity =
                new ExerciseEquipment()
                {
                    UserID = _userId,
                    ExerciseEquipmentName = model.ExerciseEquipmentName,
                    ExerciseEquipmentDescription =model.ExerciseEquipmentDescription,
                    TimeLenght = model.TimeLenght
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }


        //see all the equipment
        public IEnumerable<EquipmentList> GetEquipment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Equipments
                    .Where(e => e.UserID == _userId)
                    .Select(
                        e =>
                              new EquipmentList
                              {
                                  EquipmentId = e.EquipmentID,
                                  ExerciseEquipmentName = e.ExerciseEquipmentName,
                                  ExerciseEquipmentDescription =e.ExerciseEquipmentDescription,
                                  TimeLenght = e.TimeLenght

                              }
                        );
                return query.ToArray();
                            
            }
        }

        //to see an equipment by ID
        public EquipmentDetail GetEquipmentById (int id)
        {
            using (var ctx =new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Equipments
                    .Single(e => e.EquipmentID == id && e.UserID == _userId);
                return
                    new EquipmentDetail
                    {
                        EquipmentId = entity.EquipmentID,
                        ExerciseEquipmentName = entity.ExerciseEquipmentName,
                        ExerciseEquipmentDescription =entity.ExerciseEquipmentDescription,
                        TimeLenght = entity.TimeLenght
                    };
            }
        }

        //to update an equipment 
        public bool UpdateEquipment(EquipmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Equipments
                    .Single(e => e.EquipmentID == model.EquipmentId && e.UserID == _userId);

                entity.ExerciseEquipmentName = model.ExerciseEquipmentDescription;
                entity.ExerciseEquipmentDescription = model.ExerciseEquipmentDescription;
                entity.TimeLenght = model.TimeLenght;

                return ctx.SaveChanges() == 1;
            }
        }

        //to Delete an equipment by id
        public bool DeleteEquipment (int equipmentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Equipments
                    .Single(e => e.EquipmentID == equipmentId && e.UserID ==_userId);

                ctx.Equipments.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }

}
