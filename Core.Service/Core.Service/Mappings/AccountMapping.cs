using Core.Models.Enums;
using Core.Models.Models;
using Core.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Core.Service.Mappings
{
    public static class AccountMapping
    {
        public static AccountViewModel MapToViewModel(User user)
        {

            AccountViewModel account = new AccountViewModel()
            {
                Person = new PersonViewModel()
                {
                    CellPhone = user.Person.CellPhone,
                    LastName1 = user.Person.LastName2,
                    LastName2 = user.Person.LastName2,
                    Name = user.Person.Name,
                    PersonID = user.Person.PersonID,
                },
                UserID = user.UserID,
                UserName = user.UserName
            };
            return account;
        }
    }
}