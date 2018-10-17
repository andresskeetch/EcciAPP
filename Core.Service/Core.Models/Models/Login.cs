using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Enums;

namespace Core.Models.Models
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Authorization authorization { get; set; }
    }
}
