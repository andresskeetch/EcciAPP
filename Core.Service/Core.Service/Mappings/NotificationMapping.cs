using Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Service.Mappings
{
    public static class NotificationMapping
    {
        public static NotificationViewModel MapToViewModel(Repository.Notification noty)
        {
            UserMapping mapper = new UserMapping();
            NotificationViewModel notyed = new NotificationViewModel()
            {
                Person = new PersonViewModel()
                {
                    CellPhone = noty.User.Person.CellPhone,
                    LastName1 = noty.User.Person.LastName2,
                    LastName2 = noty.User.Person.LastName2,
                    Name = noty.User.Person.Name,
                    PersonID = noty.User.Person.PersonID,
                    Roles = noty.User.Role?.Select(f => new RoleViewModel()
                    {
                        Name = f.Name,
                        RolID = f.RolID
                    })
                },
                Date = noty.Date.Value,
                Description = noty.Description,
                ID = noty.ID,
                ScheduleAll = mapper.MapToViewModel(noty.ScheduleAll)
            };
            return notyed;
        }
    }
}