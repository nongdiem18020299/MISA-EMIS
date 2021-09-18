using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.Infrantructure.Repository
{
    public class EmployeeRepository:BaseRepository<Employee>, IEmployeeRepository
    {
        #region Field
        IConfiguration _configuration;
        #endregion

        #region Constructure
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {
            _configuration = configuration;
        }
        #endregion

    }
}
