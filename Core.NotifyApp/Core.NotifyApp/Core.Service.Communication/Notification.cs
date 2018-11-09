using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Communication
{
    public static class Notification
    {
        public static IEnumerable<Core.Models.Models.Notification> GetNotification(int PersonID) {
            try
            {
                Task<IEnumerable<Core.Models.Models.Notification>> result = Task.Run(() =>
                {
                    return Service.GetService<IEnumerable<Core.Models.Models.Notification>>(string.Format(Constants.uriGetNotification, PersonID));
                });
                result.Wait();

                if (result.Result is IEnumerable<Core.Models.Models.Notification>)
                {
                    return result.Result;
                }
                throw new Exception("Error connect service.");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
