using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces;
using Dapper;
using MySqlConnector;

namespace MISA.Infrantructure
{
    public class BaseRepository<Entity>:IBaseRepository<Entity> where Entity:class
    {
        #region Fields
        public IDbConnection DbConnection;
        public IConfiguration _configuration;
        #endregion

        #region Constructure
        public BaseRepository(
            IConfiguration configuration)
        {
            _configuration = configuration;
            DbConnection = new MySqlConnection(_configuration.GetConnectionString("MISA-EMISConnectionString"));
        }
        #endregion
        #region Get
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns>Toàn bộ dữ liệu của Entity</returns>
        /// CreateBy: NTDIEM(14/09/2021
        public List<Entity> GetAll()
        {
            var className = typeof(Entity).Name;
            var entities = DbConnection.Query<Entity>($"Proc_Get{className}s", commandType: CommandType.StoredProcedure).ToList();
            return entities;
        }

        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <param name="entityId">entityId</param>
        /// <returns>Dữ liệu theo Id truyền vào</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public Entity GetById(Guid entityId)
        {
            var className = typeof(Entity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", entityId);
            var entity = DbConnection.QueryFirstOrDefault<Entity>($"Proc_Get{className}ById", parameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        /// <summary>
        /// Lấy Mã mới
        /// </summary>
        /// <returns>Mã số mới</returns>
        /// CreateBy: NTDIEM (24/09/2021)
        public string GetNewCode()
        {
            var className = typeof(Entity).Name;
            var newCode = DbConnection.QueryFirstOrDefault<string>($"Proc_GetNew{className}Code", commandType: CommandType.StoredProcedure);
            return newCode;
        }
        #endregion
        #region DELETE
        /// <summary>
        /// Xóa dữ liệu theo id
        /// </summary>
        /// <param name="id">EntityId</param>
        /// <returns>Thông báo xóa thành công hay không</returns>
        /// CreateBy: NTDIEM(15/09/2021)
        public int Delete(Guid entityId)
        {
            var className = typeof(Entity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", entityId);
            var res = DbConnection.Execute($"Proc_Delete{className}ById", parameters, commandType: CommandType.StoredProcedure);
            return (int)res;
        }
        #endregion
        #region PUT
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <param name="Entity">emtity</param>
        /// <returns>Số lượng dòng trong db bị ảnh hưởng</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public int Put(Entity misaEntity)
        {
            DynamicParameters parameters = new DynamicParameters();
            var className = typeof(Entity).Name;
            parameters.AddDynamicParams(misaEntity);
            var res = DbConnection.Execute($"Proc_Update{className}", parameters, commandType: CommandType.StoredProcedure);
            return (int)res;
        }
        #endregion
        #region POST
        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="Entity">entity</param>
        /// <returns>Số lượng dòng trong db bị ảnh hưởng</returns>
        /// CreateBy: NTDIEM (15/09/2021)
        public int Add(Entity misaEntity)
        {
            DynamicParameters parameters = new DynamicParameters();
            var className = typeof(Entity).Name;
            parameters.AddDynamicParams(misaEntity);
            var res = DbConnection.Execute($"Proc_Insert{className}", parameters, commandType: CommandType.StoredProcedure);
            return (int)res;
        }
        #endregion
    }
}
