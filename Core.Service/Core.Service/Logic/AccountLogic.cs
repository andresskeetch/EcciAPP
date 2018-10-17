using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Service.Repository;
using Core.Models.Models;

namespace Core.Service.Logic
{
    
    public static class AccountLogic
    {
        private static APP_ECCI_ENTITIES db = new APP_ECCI_ENTITIES();

        public static Login Authenticate (Login user) {
            User account = db.User.Where(f => f.UserName == user.UserName && f.Password == user.Password).FirstOrDefault();
            if (account != null) {
                return new Login()
                {
                    authorization = Models.Enums.Authorization.IsAuthenticated,
                    UserName = user.UserName
                };
            }   
            else {
                return new Login()
                {
                    authorization = Models.Enums.Authorization.IncorrectUserPassword,
                    UserName = user.UserName
                };
            }
        }
        public static User GetAccount(Login user)
        {
            User account = db.User.Where(f => f.UserName == user.UserName && f.Password == user.Password).FirstOrDefault();

            if (account != null)
            {
                
            }


            return account;
        }
        public static IEnumerable<Role> GetRoles(int UserID) {
            return db.Role.Where(f => f.User.Where(t => t.UserID == UserID).Any());
        }
    }
}