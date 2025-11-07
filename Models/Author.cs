using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStudio.Models;

[Table("Authors")]
public class Author
{
    [Key]
    public int  Id { get; set; }

    public required string Name { get; set; }

    public required string Surname { get; set; }

    public DateTime BirthDate { get; set; }

    public string? Biography { get; set; }

    public List<Books>? Books { get; set; }
}
