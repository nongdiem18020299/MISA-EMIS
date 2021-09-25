using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.Core.Const;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using MISA.Core.Interfaces.Services;

namespace MISA.Core.Services
{
    public class BaseService<Entity>:IBaseService<Entity>
    {
        #region Field
        public ServiceResult ServiceResult;
        IBaseRepository<Entity> _baseRepo;
        #endregion
        #region Constructor
        public BaseService(IBaseRepository<Entity> baseRepo)
        {
            ServiceResult = new ServiceResult();
            _baseRepo = baseRepo;
        }
        #endregion

        #region ADD        
        /// <summary>
        /// Thêm mới
        /// </summary>
        /// <param name="entity">Thông tin thêm mới</param>
        /// <returns>Kết quả thêm mới</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public ServiceResult Add(Entity entity)
        {
            //Kiểm tra mã có bị trống không?
            var className = typeof(Entity).Name;
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity, null).ToString();
            //Kiểm tra các trường bắt buộc có bị trống không?
            //if (!CheckNullRequired(entity).Success)
            //{
            //    return CheckNullRequired(entity);
            //}
            // Kiểm tra email
            //if (!CheckEmail(entity).Success)
            //{
            //    return CheckEmail(entity);
            //}
            //Kiểm tra số điện thoại
            //if (!CheckPhoneNumber(entity).Success)
            //{
            //    return CheckPhoneNumber(entity);
            //}
            //TODO: mã trả về 200? Success là true hay false
            //Kiểm tra trùng mã
            //if (_baseValidate.CheckCodeDublicate(entity))
            //{
            //    ServiceResult.Success = false;
            //    ServiceResult.UserMsg = Resources.ValidateError_EmployeeCodeExist;
            //    ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
            //    ServiceResult.Data = $"{entity}Code";
            //    return ServiceResult;
            //}
            ServiceResult.UserMsg = Resources.Status_PostSuccess;
            ServiceResult.Data = _baseRepo.Add(entity);
            return ServiceResult;
        }
        #endregion
        #region PUT
        /// <summary>
        /// Sửa thông tin
        /// </summary>
        /// <param name="entity">Thông tin</param>
        /// <param name="id">Id entity</param>
        /// <returns>Kết quả sửa</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public ServiceResult Put(Entity entity, Guid id)
        {
            var className = typeof(Entity).Name;
            var entityCode = entity.GetType().GetProperty($"{className}Code").GetValue(entity, null).ToString();
            //Kiểm tra các trường bắt buộc có bị trống không?
            //if (!CheckNullRequired(entity).Success)
            //{
            //    return CheckNullRequired(entity);
            //}
            //// Kiểm tra email
            //if (!CheckEmail(entity).Success)
            //{
            //    return CheckEmail(entity);
            //}
            ////Kiểm tra số điện thoại
            //if (!CheckPhoneNumber(entity).Success)
            //{
            //    return CheckPhoneNumber(entity);
            //}
            ////Kiểm tra trùng mã nhân viên
            //if (_baseValidate.CheckDublicateCodePut(entityCode, id))
            //{
            //    ServiceResult.Success = false;
            //    ServiceResult.UserMsg = Resources.ValidateError_EmployeeCodeExist;
            //    ServiceResult.ErrorCode = MISAConst.MISACodeGetSuccess;
            //    ServiceResult.Data = $"{entity}Code";
            //    return ServiceResult;
            //}
            ServiceResult.UserMsg = Resources.Status_PutSuccess;
            ServiceResult.Data = _baseRepo.Put(entity);
            return ServiceResult;
        }
        #endregion
        #region DELETE
        /// <summary>
        /// Xóa thông tin
        /// </summary>
        /// <param name="id">entityId</param>
        /// <returns>Kết quả xóa</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public ServiceResult Delete(Guid id)
        {
            var entity = _baseRepo.GetById(id);
            //Kiểm tra id cần xóa có ở trong db không
            if (entity == null)
            {
                ServiceResult.Success = false;
                ServiceResult.ErrorCode = MISAConst.MISACodeNoContent;
            }
            else
            {
                ServiceResult.Data = _baseRepo.Delete(id);
                ServiceResult.UserMsg = Resources.Status_DeleteSuccess;
            }
            return ServiceResult;
        }

        #endregion
        #region Error Exception
        /// <summary>
        /// Trả về lỗi exception
        /// </summary>
        /// <param name="e">exception</param>
        /// <returns>Lỗi trả về</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public ServiceResult ErrorException(Exception e)
        {
            ServiceResult.Success = false;
            ServiceResult.ErrorCode = MISAConst.MISACodeErrorException;
            ServiceResult.DevMsg = e.Message;
            ServiceResult.UserMsg = Resources.ValidateError_Exception;
            return ServiceResult;
        }
        #endregion
    }
}
