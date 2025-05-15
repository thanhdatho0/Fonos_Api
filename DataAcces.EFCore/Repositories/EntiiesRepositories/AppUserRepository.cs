using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using Domain.Entities;
using Domain.Interfaces.IEntitiesRepositories;
using Domain.Pagination;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Repositories.EntiiesRepositories
{
    public class AppUserRepository(ApplicationDbContext context)
        : GenericRepository<AppUser>(context), IAppUserRepository
    {
    }
}
