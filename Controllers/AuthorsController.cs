using LibraryStudio.Database;
using LibraryStudio.Interface;
using LibraryStudio.Models;
using LibraryStudio.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryStudio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController : ControllerBase
{
    private readonly IGenericService<Author> _authorService;

    public AuthorsController(LibraryDbContext context)
    {
        _authorService = new GenericService<Author>(context);
    }

    /// <summary>
    // Get All Authors from database
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllAuthors")]
    public IActionResult GetAllAuthors()
    {
        var authors = _authorService.GetAllAsync();
        if (authors.Any() == false)
        {
            return NotFound("No authors found.");
        }
        return Ok(authors);
    }

    /// <summary>
    /// Get Author by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetAuthorById/{id}")]
    public IActionResult GetAuthorById(int id)
    {
        var author = _authorService.GetById(id);
        if (author == null)
        {
            return NotFound($"Author with ID {id} not found.");
        }
        return Ok(author);
    }

    /// <summary>
    /// Add New Author to database
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    [HttpPost("AddAuthor")]
    public IActionResult AddAuthor([FromBody] Author author)
    {
        _authorService.Add(author);
        return Ok("Author added successfully.");
    }

    /// <summary>
    /// Update Author in database
    /// </summary>
    /// <param name="author"></param>
    /// <returns></returns>
    [HttpPut("UpdateAuthor")]
    public IActionResult UpdateAuthor([FromBody] Author author)
    {
        _authorService.Update(author);
        return Ok("Author updated successfully.");
    }

    /// <summary>
    /// Delete Author by ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteAuthor/{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        var author = _authorService.GetById(id);
        if (author == null)
        {
            return NotFound($"Author with ID {id} not found.");
        }
        _authorService.Delete(author);
        return Ok("Author deleted successfully.");
    }

    /// <summary>
    /// Delete All Authors from database
    /// </summary>
    /// <returns></returns>
    [HttpGet("DeleteAllAuthors")]
    public IActionResult DeleteAllAuthors()
    {
        _authorService.DeleteAll();
        return Ok("All authors deleted successfully.");
    }

    /// <summary>
    /// Get All Books by Author ID
    /// </summary>
    /// <param name="authorId"></param>
    /// <returns></returns>
    [HttpGet("GetAllBooksByAuthor/{authorId}")]
    public IActionResult GetAllBooksByAuthor(int authorId)
    {
        var author = _authorService.GetById(authorId);
        if (author == null)
        {
            return NotFound($"Author with ID {authorId} not found.");
        }
        var books = author.Books;
        if (books == null || !books.Any())
        {
            return NotFound($"No books found for author with ID {authorId}.");
        }
        return Ok(books);
    }
}
