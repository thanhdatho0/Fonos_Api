using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using DataAcces.EFCore.Mappers;
using Domain.Entities;
using Domain.Interfaces.IEntitiesRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Repositories.EntiiesRepositories
{
    public class AudiobookRepository(ApplicationDbContext context)
        : GenericRepository<Audiobook>(context), IAudiobookRepository
    {
    }
}
