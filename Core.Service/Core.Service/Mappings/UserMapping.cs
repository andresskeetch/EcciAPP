using Core.Models.Enums;
using Core.Models.Models;
using Core.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Service.Mappings
{
    public class UserMapping
    {
        public IEnumerable<ScheduleAllViewModel> MapToListViewModel(IEnumerable<ScheduleAll> entities)
        {
            IList<ScheduleAllViewModel> result = new List<ScheduleAllViewModel>();

            foreach (var item in entities)
            {
                result.Add(MapToViewModel(item));
            }
            return result;
        }
        public ScheduleAllViewModel MapToViewModel(ScheduleAll entity)
        {
            ScheduleAllViewModel result = new ScheduleAllViewModel();

            result.Class = new ClassViewModel()
            {
                ClassID = entity.ClassID.Value,
                ClassRoom = new ClassRoomViewModel()
                {
                    ClassRoomID = entity.Class.ClassRoomID.Value,
                    Name = entity.Class.ClassRoom.Name,
                    Seat = new SeatViewModel()
                    {
                        Name = entity.Class.ClassRoom.Seat.Name,
                        SeatID = entity.Class.ClassRoom.Seat.SeatID
                    }
                },
                Course = new CourseViewModel()
                {
                    CourseID = entity.Class.Course.CourseID,
                    Name = entity.Class.Course.Name
                },
                Name = entity.Class.Name,
                Teacher = new PersonViewModel() { 
                    CellPhone = entity.Class.Person.CellPhone,
                    LastName1 = entity.Class.Person.LastName1,
                    LastName2 = entity.Class.Person.LastName2,
                    Name = entity.Class.Person.Name,
                    PersonID = entity.Class.Person.PersonID
                }
            };
            result.Date = entity.Date.Value;
            result.ScheduleAllID = entity.ScheduleAllID;
            result.State = (StateClass)entity.State;
            return result;
        }
    }
}