using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class PersonViewModel
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public string CellPhone { get; set; }
        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
