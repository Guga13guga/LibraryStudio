using LibraryStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryStudio.Database;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Books> Books { get; set; }
}
