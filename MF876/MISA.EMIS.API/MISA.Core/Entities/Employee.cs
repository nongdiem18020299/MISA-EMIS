using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Employee:BaseEntity
    {
        public Guid? EmployeeId{ get; set; }
        public string EmployeeCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? RoomId { get; set; }

        public int? TrainingStatus { get; set; }
        public int? WorkStatus { get; set; }

        public DateTime? DayOff { get; set; }
    }
}

