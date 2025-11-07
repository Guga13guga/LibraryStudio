using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryStudio.Dto;

public class BookDto
{
    public required string Title { get; set; }

    public required string Description { get; set; }

    public bool? IsBestSeller { get; set; }

    public int BookCount { get; set; }

    public string? Note { get; set; }

    public int AuthorId { get; set; }
}
