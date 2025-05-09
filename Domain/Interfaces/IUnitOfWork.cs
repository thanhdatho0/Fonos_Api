using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.IEntitiesRepositories;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAudiobookRepository Audiobooks { get; }
        IAudiobookChapterRepository AudiobookChapters { get; }
        IAuthorRepository Authors { get; }
        IBookAuthorRepository BookAuthors { get; }
        IBookCategoryRepository BookCategories { get; }
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }
        IDownloadRepository Downloads { get; }
        IPlaylistItemRepository PlaylistItems { get; }
        IPublisherRepository Publishers { get; }
        IRatingRepository Ratings { get; }
        IUserBookmarkRepository UserBookmarks { get; }
        IUserFavoriteRepository UserFavorites { get; }
        IUserListeningProgressRepository UserListeningProgresses {  get; }
        IUserPlaylistRepository UserPlaylists {  get; }
        IUserPurchaseRepository UserPurchases { get; }
        Task<int> Complete();
    }
}
