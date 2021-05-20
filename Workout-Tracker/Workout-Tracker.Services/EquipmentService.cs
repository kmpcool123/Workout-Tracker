using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workout_Tracker.Data;

namespace Workout_Tracker.Services
{
  /*  public  class EquipmentService
    {
        private readonly Guid _userID;
        public EquipmentService (Guid userID)
        {
            _userID = userID;
        }

        public bool EquipmentCreate (EquipmentCreate model)
        {
            var entity =
                new Eqiupment()
                {
                    UserID = _userID,
                    Name = model.Name,
                    TimeLenght = model.TimeLenght
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Equipments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EquipmentList> GetEquipment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                         .Equipments
                         .where(e => e.UserId == _userID)
                         .select(
                               e =>
                                    new EquipmentList
                                    {
                                        EquipmentId = e.EquipmentId,
                                        Name = e.Name,
                                        TimeLenght = e.TimeLenght
                                    }
                        );

                return query.ToArray();
            }
        }
    }*/
}
