using Core.Models.Models;
using Core.Service.Mappings;
using Core.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Service.Logic
{
    public class ScheduleLogic
    {
        private static APP_ECCI_ENTITIES db = new APP_ECCI_ENTITIES();

        public static IEnumerable<ScheduleAllViewModel> GetTodayActivities(int personID)
        {
            //Person person = db.Person.Where(f => f.Class.Where(t => t.ScheduleAll.Where(s => DateTime.Now <= s.Date.Value && s.Date.Value >= DateTime.Now).Any()).Any()).FirstOrDefault();
            Person person = db.Person.Where(f => f.PersonID == personID).FirstOrDefault();
            if (person == null)
            {
                return new List<ScheduleAllViewModel>();
            }
            List<ScheduleAllViewModel> result = new List<ScheduleAllViewModel>();
            UserMapping mapping = new UserMapping();
            User user = db.User.Where(f => f.PersonID == personID).FirstOrDefault();
            if (user.Role.Any())
            {
                foreach (var item in user.Role)
                {
                    foreach (var clase in item.Name == "Estudiante" ? person.Class1 : person.Class)
                    {
                        result.AddRange(mapping.MapToListViewModel(clase.ScheduleAll));
                    }
                }
            }
            return result;
        }

        public static IEnumerable<ScheduleAllViewModel> GetActivities(int personID)
        {
            List<ScheduleAllViewModel> result = new List<ScheduleAllViewModel>();
            UserMapping mapping = new UserMapping();
            //Person person = db.Person.Where(f => f.Class.Where(t => t.ScheduleAll.Where(s => DateTime.Now <= s.Date.Value && s.Date.Value >= DateTime.Now).Any()).Any()).FirstOrDefault();
            Person person = db.Person.Where(f => f.PersonID == personID).FirstOrDefault();
            if (person == null)
            {
                return new List<ScheduleAllViewModel>();
            }
            User user = db.User.Where(f => f.PersonID == personID).FirstOrDefault();
            if (user.Role.Any())
            {
                foreach (var item in user.Role)
                {
                    foreach (var clase in item.Name == "Estudiante" ? person.Class1 : person.Class)
                    {
                        result.AddRange(mapping.MapToListViewModel(clase.ScheduleAll));
                    }
                }
            }
            
            
            
            return result;
        }


        public static ScheduleAllViewModel Update(ScheduleAllViewModel activity, int UserID) {

            ScheduleAll schedule = db.ScheduleAll.Where(f => f.ScheduleAllID == activity.ScheduleAllID).FirstOrDefault();

            schedule.State = (int)activity.State;

            

            Repository.Notification noty = new Repository.Notification();
            noty.ScheduleAllID = schedule.ScheduleAllID;
            noty.UserID = UserID;
            noty.Description = activity.Description;
            noty.Date = DateTime.UtcNow;

            noty = db.Notification.Add(noty);

            db.SaveChanges();
            
            noty.User = db.User.Where(f => f.UserID == noty.UserID).FirstOrDefault();
            Notification.SetStaticNotification(NotificationMapping.MapToViewModel(noty));

            return activity;
        }
    }
}