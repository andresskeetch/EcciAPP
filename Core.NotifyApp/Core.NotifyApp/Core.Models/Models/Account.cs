using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class Account
    {
        public Authorization result  { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public Person Person { get; set; }
    }
}
