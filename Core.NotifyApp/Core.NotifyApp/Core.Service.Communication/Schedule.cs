﻿using Core.Models.Models;
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
    }
}