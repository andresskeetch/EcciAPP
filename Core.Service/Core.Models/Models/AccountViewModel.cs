using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class AccountViewModel
    {
        public Authorization result  { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public PersonViewModel Person { get; set; }
    }
}
