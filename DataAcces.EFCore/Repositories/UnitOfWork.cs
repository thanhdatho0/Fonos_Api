
using DataAcces.EFCore.Dbcontext;
using DataAcces.EFCore.Repositories.EntiiesRepositories;
using Domain.Interfaces;
using Domain.Interfaces.IEntitiesRepositories;

namespace DataAcces.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private bool disposedValue;
        private readonly ApplicationDbContext _context;

        public IAudiobookRepository Audiobooks { get; private set; }

        public IAudiobookChapterRepository AudiobookChapters { get; private set; }

        public IAuthorRepository Authors { get; private set; }

        public IBookAuthorRepository BookAuthors { get; private set; }

        public IBookCategoryRepository BookCategories { get; private set; }

        public IBookRepository Books { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IDownloadRepository Downloads { get; private set; }

        public IPlaylistItemRepository PlaylistItems { get; private set; }

        public IPublisherRepository Publishers { get; private set; }

        public IRatingRepository Ratings { get; private set; }

        public IUserBookmarkRepository UserBookmarks { get; private set; }

        public IUserFavoriteRepository UserFavorites { get; private set; }

        public IUserListeningProgressRepository UserListeningProgresses { get; private set; }

        public IUserPlaylistRepository UserPlaylists { get; private set; }

        public IUserPurchaseRepository UserPurchases { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Audiobooks = new AudiobookRepository(_context);
            AudiobookChapters = new AudiobookChapterRepository(_context);
            Authors = new AuthorRepository(_context);
            BookAuthors = new BookAuthorRepository(_context);
            BookCategories = new BookCategoryRepository(_context);
            Books = new BookRepository(_context);
            Categories = new CategoryRepository(_context);
            Downloads = new DownloadRepository(_context);
            PlaylistItems = new PlaylistItemRepository(_context);
            Publishers = new PublisherRepository(_context);
            Ratings = new RatingRepository(_context);
            UserBookmarks = new UserBookmarkRepostiory(_context);
            UserFavorites = new UserFavoriteRepository(_context);
            UserListeningProgresses = new UserListeningProgressRepository(_context);
            UserPlaylists = new UserPlaylistRepository(_context);
            UserPurchases = new UserPurchaseRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
