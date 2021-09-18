using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Infrantructure;

namespace MISA.EMIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/Subjects")]
    public class SubjectController : Controller
    {
        #region Field
        ISubjectRepository _subjectRepository;
        #endregion
        #region Constructure
        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
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
                var subjects = _subjectRepository.GetAll();
                return Ok(subjects);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }
        #endregion
        #endregion
    }
}
