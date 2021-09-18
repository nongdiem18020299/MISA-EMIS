using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Services;

namespace MISA.EMIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/Employees")]
    public class EmployeeController : Controller
    {
        #region Field
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;
        #endregion
        #region Constructure
        public EmployeeController(IEmployeeService employeeService, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }
        #endregion
        #region Method
        #region Get
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Lấy toàn bộ dữ liệu</returns>
        /// CreateBy: NTDIEM(15/09/2021)
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var employees = _employeeRepository.GetAll();
                return Ok(employees);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
           
        }
        /// <summary>
        /// Lấy dữ liệu  theo id
        /// </summary>
        /// <param name="id">employeeId</param>
        /// <returns>Dữ liệu lấy được theo id nhân viên</returns>
        /// CreateBy:NTDIEM(15/09/2021)
        [HttpGet("{id}")]
        public IActionResult GetId(Guid id)
        {
            try
            {
                var employee = _employeeRepository.GetById(id);
                return employee != null ? Ok(employee) : NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }
        }
        #endregion
        #region POST
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="employee">Nhân viên</param>
        /// <returns>trạng thái thêm mới</returns>
        /// CreateBy:NTDIEM(15/09/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            try
            {
                //Validate dữ liệu
                var employeeResult = new ServiceResult();
                employeeResult = _employeeService.Add(employee);
                //Kiểm tra dữ liệu có bị bỏ trống không
                return employeeResult.Success ? StatusCode(201, employeeResult) : StatusCode(200, employeeResult);

            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }
        }
        #endregion
        #region PUT
        /// <summary>
        /// Hàm sửa dữ liệu
        /// </summary>
        /// <param name="id">ID nhân viên</param>
        /// <param name="employee">thông tin nhân viên</param>
        /// <returns>Trạng thái sửa thông tin nhân viên</returns>
        /// CreateBy:NTDIEM(15/09/2021)
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, [FromBody] Employee employee)
        {
            try
            {
                //Validate dữ liệu
                var employeeResult = new ServiceResult();
                employeeResult = _employeeService.Put(employee, id);
                return employeeResult.Success ? StatusCode(201, employeeResult) : StatusCode(200, employeeResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }

        }
        #endregion
        #region DELETE
        /// <summary>
        /// Xóa nhân viên theo id
        /// </summary>
        /// <param name="id">employeeId</param>
        /// <param name="employee">Thông tin nhân viên</param>
        /// <returns>Trạng thái xóa dữ liệu</returns>
        /// CreateBy:NTDIEM(15/09/2021)
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //Validate dữ liệu
                var employeeResult = new ServiceResult();

                employeeResult = _employeeService.Delete(id);
                return employeeResult.Success ? StatusCode(200, employeeResult) : StatusCode(204, employeeResult);

            }
            catch (Exception e)
            {
                return StatusCode(500, _employeeService.ErrorException(e));
            }

        }
        #endregion
        #endregion

    }
}
