using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStudio.Models;

[Table("Books")]
public class Books
{
    [Key]
    public int Id { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public bool? IsBestSeller { get; set; }

    public int BookCount  { get; set; }

    public string? Note { get; set; }

    [ForeignKey("Author")]
    public int AuthorId { get; set; }

    public Author? Author { get; set; }

    public List<Reservations>? Reservations { get; set; }
}
