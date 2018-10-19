using Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class RoleViewModel
    {
        public int RolID { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }
    }
}
