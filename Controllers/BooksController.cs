using LibraryStudio.Database;
using LibraryStudio.Dto;
using LibraryStudio.Interface;
using LibraryStudio.Models;
using LibraryStudio.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryStudio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IGenericService<Books> _booksService;
    public BooksController(LibraryDbContext db)
    {
        _booksService = new GenericService<Books>(db);
    }

    /// <summary>
    /// Get All Books from database, return only active books
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllBooks")]
    public IActionResult GetAllBooks()
    {
        var books = _booksService.GetAllAsync();
        if (books.Any())
        {
            return Ok(books);
        }
        return NotFound("No books found.");
    }

    /// <summary>
    /// Get Book by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetBookById/{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = _booksService.GetById(id);
        if (book != null)
        {
            return Ok(book);
        }
        return NotFound($"Book with ID {id} not found.");
    }

    /// <summary>
    /// Add New Book to database
    /// </summary>
    /// <param name="newBook"></param>
    /// <returns></returns>
    [HttpPost("AddBook")]
    public IActionResult AddNewBook([FromBody] BookDto newBook)
    {
        _booksService.Add(new Books
        {
            Description = newBook.Description,
            AuthorId = newBook.AuthorId,
            BookCount = newBook.BookCount,
            IsBestSeller = newBook.IsBestSeller,
            Note = newBook.Note,
            Title = newBook.Title
        });
        return Ok("Book added successfully.");
    }

    /// <summary>
    /// Update Book information
    /// </summary>
    /// <param name="updatedBook"></param>
    /// <returns></returns>

    [HttpPut("UpdateBook")]
    public IActionResult UpdateBook([FromBody] BookDto updatedBook)
    {
        _booksService.Update(new Books
        {
            Description = updatedBook.Description,
            AuthorId = updatedBook.AuthorId,
            BookCount = updatedBook.BookCount,
            IsBestSeller = updatedBook.IsBestSeller,
            Note = updatedBook.Note,
            Title = updatedBook.Title
        });
        return Ok("Book updated successfully.");
    }

    /// <summary>
    /// Delete Book from database
    /// </summary>
    /// <param name="bookToDelete"></param>
    /// <returns></returns>
    [HttpDelete("DeleteBook")]
    public IActionResult DeleteBook([FromBody] BookDto bookToDelete)
    {
        _booksService.Delete(new Books
        {
            Description = bookToDelete.Description,
            AuthorId = bookToDelete.AuthorId,
            BookCount = bookToDelete.BookCount,
            IsBestSeller = bookToDelete.IsBestSeller,
            Note = bookToDelete.Note,
            Title = bookToDelete.Title
        });
        return Ok("Book deleted successfully.");
    }

    /// <summary>
    /// Delete Book by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteBookById/{id}")]
    public IActionResult DeleteBookById(int id)
    {
        _booksService.DeleteById(id);
        return Ok("Book deleted successfully.");
    }

    /// <summary>
    /// Delete All Books from database
    /// </summary>
    /// <returns></returns>
    [HttpDelete("DeleteAllBooks")]
    public IActionResult DeleteAllBooks()
    {
        _booksService.DeleteAll();
        return Ok("All books deleted successfully.");
    }
}
