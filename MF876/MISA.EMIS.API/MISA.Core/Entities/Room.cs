using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Room:BaseEntity
    {
        public Guid? RoomId { get; set; }
        public string Description { get; set; }
        public string RoomName { get; set; }
    }
}
