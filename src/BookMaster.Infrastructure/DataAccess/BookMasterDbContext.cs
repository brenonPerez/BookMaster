using BookMaster.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookMaster.Infrastructure.DataAccess;
internal class BookMasterDbContext : DbContext
{
    public BookMasterDbContext(DbContextOptions<BookMasterDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
}
