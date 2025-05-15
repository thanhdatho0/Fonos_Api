using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces.IEntitiesRepositories
{
    public interface IAudiobookRepository : IGenericRepository<Audiobook>
    {
        Task<IEnumerable<Audiobook?>> GetNewAudiobook();
        Task<IEnumerable<Audiobook?>> GetTopAudiobook();
        //Task<IEnumerable<Audiobook?>> GetAudiobooksHaveSameAuthor(Guid auiobookId);
        //Task<IEnumerable<Audiobook?>> GetAudiobooksHaveSameCategory(Guid auiobookId);
        //Task<IEnumerable<Audiobook?>> GetAudiobooksHaveSamePublisher(Guid auiobookId);
    }
}
