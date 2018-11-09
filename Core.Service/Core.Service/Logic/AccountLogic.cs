using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Service.Repository;
using Core.Models.Models;
using Core.Service.Mappings;

namespace Core.Service.Logic
{

    public class AccountLogic : BaseLogic
    {

        public Login Authenticate(Login user)
        {
            User account = db.User.Where(f => f.UserName == user.UserName && f.Password == user.Password).FirstOrDefault();
            if (account != null)
            {
                return new Login()
                {
                    authorization = Models.Enums.Authorization.IsAuthenticated,
                    UserName = user.UserName,
                    User = AccountMapping.MapToViewModel(account)
                };
            }
            else
            {
                return new Login()
                {
                    authorization = Models.Enums.Authorization.IncorrectUserPassword,
                    UserName = user.UserName
                };
            }
        }
        public User GetAccount(Login user)
        {
            User account = db.User.Where(f => f.UserName == user.UserName && f.Password == user.Password).FirstOrDefault();

            if (account != null)
            {

            }


            return account;
        }
        public IEnumerable<Role> GetRoles(int UserID)
        {
            return db.Role.Where(f => f.User.Where(t => t.UserID == UserID).Any());
        }
    }
}