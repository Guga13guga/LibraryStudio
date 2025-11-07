namespace LibraryStudio.Dto;

public class ReservationDto
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime ReturnDate { get; set; }
    public string? Note { get; set; }
}
