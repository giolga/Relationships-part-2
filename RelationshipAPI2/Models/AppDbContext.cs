using Microsoft.EntityFrameworkCore;

namespace RelationshipAPI2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<BookPublisher> BookPublishers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired();

                entity.HasOne(a => a.Publisher).WithOne(p => p.Author).HasForeignKey<Publisher>(p => p.AuthorId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Title).IsRequired();

                entity.HasOne(a => a.Author).WithMany(b => b.Books).HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired();
            });

            modelBuilder.Entity<BookPublisher>(entity =>
            {
                entity.HasKey(bp => new { bp.PublisherId, bp.BookId });
                entity.HasOne(bp => bp.Book).WithMany(bp => bp.BookPublishers).HasForeignKey(bp => bp.BookId).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(bp => bp.Publisher).WithMany(bp => bp.BookPublishers).HasForeignKey(bp => bp.PublisherId).OnDelete(DeleteBehavior.NoAction);
            });
        }

    }
}
