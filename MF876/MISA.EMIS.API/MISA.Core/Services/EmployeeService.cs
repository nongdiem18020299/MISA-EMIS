using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Services;

namespace MISA.Core.Services
{
    public class EmployeeService:BaseService<Employee>, IEmployeeService
    {
        IEmployeeRepository _emmployeRepo;
        IBaseRepository<Employee> _baseRepo;
        #region Constructor
        public EmployeeService(IEmployeeRepository emmployeRepo, IBaseRepository<Employee> baseRepo) : base(baseRepo)
        {
            ServiceResult = new ServiceResult();
            _emmployeRepo = emmployeRepo;
            _baseRepo = baseRepo;
        }
        #endregion


    }
}
