using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrantructure;
using MISA.Core.Interfaces.Services;

namespace MISA.EMIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/Departments")]
    public class DepartmentController : Controller
    {
        #region Field
        IDepartmentRepository _departmentRepository;
        IDepartmentService _departmentService;
        #endregion
        #region Constructure
        public DepartmentController(IDepartmentService departmentService, IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _departmentService = departmentService;
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
                var departments = _departmentRepository.GetAll();
                return Ok(departments);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        #endregion
        #region POST
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <param name="department">phòng ban</param>
        /// <returns>trạng thái thêm mới</returns>
        /// CreateBy:NTDIEM(15/09/2021)
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            try
            {
                //Validate dữ liệu
                var departmentResult = new ServiceResult();
                departmentResult = _departmentService.Add(department);
                //Kiểm tra dữ liệu có bị bỏ trống không
                return departmentResult.Success ? StatusCode(201, departmentResult) : StatusCode(200, departmentResult);

            }
            catch (Exception e)
            {
                return StatusCode(500, _departmentService.ErrorException(e));
            }
        }
        #endregion
        #region PUT
        /// <summary>
        /// Hàm sửa dữ liệu
        /// </summary>
        /// <param name="id">ID phòng ban</param>
        /// <param name="department">thông tin phòng ban</param>
        /// <returns>Trạng thái sửa thông tin phòng ban</returns>
        /// CreateBy:NTDIEM(15/09/2021)
        [HttpPut("{id}")]

        public IActionResult Put(Guid id, [FromBody] Department department)
        {
            try
            {
                //Validate dữ liệu
                var departmentResult = new ServiceResult();
                departmentResult = _departmentService.Put(department, id);
                return departmentResult.Success ? StatusCode(201, departmentResult) : StatusCode(200, departmentResult);
            }
            catch (Exception e)
            {
                return StatusCode(500, _departmentService.ErrorException(e));
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
                var departmentResult = new ServiceResult();

                departmentResult = _departmentService.Delete(id);
                return departmentResult.Success ? StatusCode(200, departmentResult) : StatusCode(204, departmentResult);

            }
            catch (Exception e)
            {
                return StatusCode(500, _departmentService.ErrorException(e));
            }

        }
        #endregion
        #endregion
    }
}
