using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using Domain.Entities;
using Domain.Interfaces.IEntitiesRepositories;

namespace DataAcces.EFCore.Repositories.EntiiesRepositories
{
    public class UserPlaylistRepository(ApplicationDbContext context)
        : GenericRepository<UserPlaylist>(context), IUserPlaylistRepository
    {
    }
}
