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
            foreach (var item in person.Class1)
            {
                result.AddRange(mapping.MapToListViewModel(item.ScheduleAll));
            }
            return result;
        }

        public static IEnumerable<ScheduleAllViewModel> GetActivities(int personID)
        {
            //Person person = db.Person.Where(f => f.Class.Where(t => t.ScheduleAll.Where(s => DateTime.Now <= s.Date.Value && s.Date.Value >= DateTime.Now).Any()).Any()).FirstOrDefault();
            Person person = db.Person.Where(f => f.PersonID == personID).FirstOrDefault();
            if (person == null)
            {
                return new List<ScheduleAllViewModel>();
            }
            List<ScheduleAllViewModel> result = new List<ScheduleAllViewModel>();
            UserMapping mapping = new UserMapping();
            foreach (var item in person.Class1)
            {
                result.AddRange(mapping.MapToListViewModel(item.ScheduleAll));
            }
            return result;
        }
    }
}