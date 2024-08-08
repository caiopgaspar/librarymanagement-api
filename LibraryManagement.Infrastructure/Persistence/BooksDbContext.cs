using LibraryManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryManagement.Infrastructure.Persistence
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(o => {
                o.HasKey(o => o.Id);
            });

            modelBuilder.Entity<Loan>(o => {
                o.HasKey(o => o.Id);

                o.HasOne(l => l.User)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.UserId);

                o.HasOne(l => l.Book)
                .WithMany(u => u.Loans)
                .HasForeignKey(l => l.BookId);


            });

            modelBuilder.Entity<Book>(o => {
                o.HasKey(o => o.Id);


            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
