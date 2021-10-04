using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces;

namespace MISA.Infrantructure.Repository
{
    public class EmployeeRepository:BaseRepository<Employee>, IEmployeeRepository
    {

        #region Constructure
        public EmployeeRepository(IConfiguration configuration):base(configuration)
        {
        }
        #endregion

        #region Method
        /// <summary>
        /// Lọc nhân viên
        /// </summary>
        /// <param name="employeeFilter">Từ khóa lọc</param>
        /// <param name="DepartmentId">Id phòng ban</param>
        /// <returns>danh sách nhân viên sau khi lọc</returns>
        /// CreateBy: NTDIEM(03/10/2021)
        public object GetEmployeeFilter(Guid DepartmentId, string EmployeeFilter)
        {
            //var totalRecord = 0;
            //var totalPage = 0;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeFilter", EmployeeFilter);
            parameters.Add("@DepartmentId", DepartmentId);
            //parameters.Add("@TotalRecord", totalRecord, DbType.Int32, ParameterDirection.Output);
            //parameters.Add("@TotalPage", totalPage, DbType.Int32, ParameterDirection.Output);
            var res = DbConnection.Query<Employee>("Proc_GetEmployeeFilter", parameters, commandType: CommandType.StoredProcedure);
            //totalPage = parameters.Get<int>("@TotalPage");
            //totalRecord = parameters.Get<int>("@TotalRecord");
            return res;
        }
        #endregion
    }
}
