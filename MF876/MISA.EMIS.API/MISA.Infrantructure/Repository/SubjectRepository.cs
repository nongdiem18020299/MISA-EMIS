using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MISA.Core.Entities;
using MISA.Core.Interfaces.Infrantructure;

namespace MISA.Infrantructure.Repository
{
    public class SubjectRepository:BaseRepository<Subject>, ISubjectRepository
    {
        #region Field
        IConfiguration _configuration;
        #endregion

        #region Constructure
        public SubjectRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }
        #endregion
    }
}
