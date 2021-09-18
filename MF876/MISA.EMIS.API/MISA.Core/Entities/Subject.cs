using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Subject:BaseEntity
    {
        public Guid? SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
    }
}
