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
        public async static Task<Login> Authenticate(string username, string password) {
            Login user = new Login() {
                Password = password,
                UserName = username
            };
            var result = await Service.PostService<Login>(user, Constants.uriLogin);

            if (result is Login) {
                return result;
            }
            throw new Exception("Error conect service.");

        }
    }
}
