using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.IEntitiesRepositories
{
    public interface IRatingRepository : IGenericRepository<Rating>
    {
        Task<double> CalcAvgRatings(Guid bookId);
        Task<int> NumberOfReviws(Guid bookId);
    }
}
