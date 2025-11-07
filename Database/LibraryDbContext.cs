using LibraryStudio.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryStudio.Database;

public class LibraryDbContext : DbContext
{
    public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
    {
    }

    public DbSet<Books> Books { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Author> Authors { get; set; }

    public DbSet<Reservations> Reservations { get; set; }
}
