using Microsoft.EntityFrameworkCore;
using LibraryManagement.Core.Entities;
using System.Collections.Generic;

namespace LibraryManagement.Infrastructure.Persistence
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
