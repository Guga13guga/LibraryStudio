using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStudio.Models;

[Table("Users")]
public class User
{
    [Key]
    public int Id { get; set; }

    public required string Name { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required string UserName { get; set; }

    public List<Reservations>? Reservations { get; set; }
}
