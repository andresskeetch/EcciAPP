using Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Communication
{
    public class Schedule
    {
        public static IEnumerable<ScheduleAll> GetScheduleToday(int personId)
        {
            try
            {
                Task<IEnumerable<ScheduleAll>> result = Task.Run(() =>
                {
                    return Service.GetService<IEnumerable<ScheduleAll>>(string.Format(Constants.uriScheduleToday, personId));
                });
                result.Wait();

                if (result.Result is IEnumerable<ScheduleAll>)
                {
                    return result.Result;
                }
                throw new Exception("Error conect service.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<ScheduleAll> GetSchedule(int personId)
        {
            try
            {
                Task<IEnumerable<ScheduleAll>> result = Task.Run(() =>
                {
                    return Service.GetService<IEnumerable<ScheduleAll>>(string.Format(Constants.uriSchedule, personId));
                });
                result.Wait();

                if (result.Result is IEnumerable<ScheduleAll>)
                {
                    return result.Result;
                }
                throw new Exception("Error conect service.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static ScheduleAll Update(ScheduleAll activity, int personId) {
            try
            {
                Task<ScheduleAll> result = Task.Run(() =>
                {
                    return Service.PostService<ScheduleAll>(activity, string.Format(Constants.uriScheduleUpdate, personId));
                });
                result.Wait();

                if (result.Result is ScheduleAll)
                {
                    return result.Result;
                }
                throw new Exception("Error conect service.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
