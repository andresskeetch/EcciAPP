using Core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Communication
{
    public static class User
    {
        public static Login Authenticate(string username, string password) {

            Login user = new Login() {
                Password = password,
                UserName = username
            };
            Task<Login> result = Task.Run(() =>
            {
                return Service.PostService<Login>(user, Constants.uriLogin);
            });
            result.Wait();

            if (result.Result is Login) {
                return result.Result;
            }
            throw new Exception("Error conect service.");

        }
    }
}
