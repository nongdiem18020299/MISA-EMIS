using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Interfaces.Infrantructure;

namespace MISA.EMIS.API.Controllers
{
    [ApiController]
    [Route("api/v1/Rooms")]
    public class RoomController : Controller
    {
        #region Field
        IRoomRepository _roomRepository;
        #endregion
        #region Constructure    
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
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
                var rooms = _roomRepository.GetAll();
                return Ok(rooms);
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
