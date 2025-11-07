using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStudio.Models;

[Table("Reservations")]
public class Reservations
{
    [Key]
    public int Id  { get; set; }

    [ForeignKey("Book")]
    public int BookId { get; set; }

    public Books? Book  { get; set; }

    [ForeignKey("User")]
    public int  UserId { get; set; }

    public User? User { get; set; }

    public DateTime TakeDate { get; set; } = DateTime.Now;

    public DateTime ReturnDate { get; set; }

    public string? Note { get; set; }
}
