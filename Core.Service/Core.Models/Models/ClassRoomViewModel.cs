using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Models
{
    public class ClassRoomViewModel
    {
        public SeatViewModel Seat { get; set; }
        public int ClassRoomID { get; set; }
        public string Name { get; set; }

    }
}
