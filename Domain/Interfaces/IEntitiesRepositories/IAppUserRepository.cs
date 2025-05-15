using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Pagination;

namespace Domain.Interfaces.IEntitiesRepositories
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
    {
    }
}
