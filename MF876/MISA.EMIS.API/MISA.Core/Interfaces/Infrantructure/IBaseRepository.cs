using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IBaseRepository<Entity>
    {
        public List<Entity> GetAll();
        public Entity GetById(Guid entityId);
        public int Delete(Guid entityId);
        public int Put(Entity misaEntity);
        public int Add(Entity misaEntity);
    }
}
