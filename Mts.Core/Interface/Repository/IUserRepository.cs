using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using entity = Mts.Core.Entity;

namespace Mts.Core.Interface.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<entity.ApplicationFeature>> GetUserSecurityProfileAsync(int userid);
    }
}
