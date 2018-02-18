using Microsoft.EntityFrameworkCore;
using Mts.Core.Interface.Repository;
using Mts.Core.Resource;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = Mts.Core.Entity;
namespace Mts.Infrastructure.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MtsContext _context;
        public UserRepository(MtsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<entity.ApplicationFeature>> GetUserSecurityProfileAsync(int userid)
        {
            try
            {
                var sp = StoredProcedureResource.spRetrieveSecurityProfile.Replace("@userid", userid.ToString());
                return await _context.ApplicationFeature.FromSql(sp, userid).ToListAsync();
            }catch(Exception e)
            {
                return null;
            }
        }
    }
}
