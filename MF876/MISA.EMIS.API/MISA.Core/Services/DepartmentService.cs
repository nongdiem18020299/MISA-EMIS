using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Infrantructure;
using MISA.Core.Interfaces.Services;

namespace MISA.Core.Services
{
    public class DepartmentService: BaseService<Department>, IDepartmentService
    {
        IDepartmentRepository _departmentRepo;
        IBaseRepository<Department> _baseRepo;
        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepo, IBaseRepository<Department> baseRepo) : base(baseRepo)
        {
            ServiceResult = new ServiceResult();
            _departmentRepo = departmentRepo;
            _baseRepo = baseRepo;
        }
        #endregion
    }
}
