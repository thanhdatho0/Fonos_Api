
using System.Reflection.Emit;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Dbcontext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
                : IdentityDbContext<AppUser>(options)
    {
        #region DbSet
        public DbSet<Audiobook> Audiobooks { get; set; }
        public DbSet<AudiobookChapter> AudiobookChapters { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Download> Downloads { get; set; }
        public DbSet<PlaylistItem> PlaylistItems { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserBookmark> UserBookmarks { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UserListeningProgress> UserListeningProgresses { get; set; }
        public DbSet<UserPlaylist> UserPlaylists { get; set; }
        public DbSet<UserPurchase> UserPurchases { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            List<IdentityRole> roles =
            [
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                },
            ];

            builder.Entity<IdentityRole>().HasData(roles);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
