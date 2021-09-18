using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;

namespace MISA.Core.Interfaces.Services
{
    public interface IBaseService<Entity>
    {
        public ServiceResult Add(Entity entity);
        public ServiceResult Put(Entity entity, Guid id);
        public ServiceResult Delete(Guid id);
        public ServiceResult ErrorException(Exception e);
    }
}
