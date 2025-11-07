using LibraryStudio.Database;
using LibraryStudio.Dto;
using LibraryStudio.Interface;
using LibraryStudio.Models;
using LibraryStudio.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryStudio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IGenericService<Reservations> _services;

    public ReservationController(LibraryDbContext _context)
    {
        _services=new GenericService<Reservations>(_context);
    }

    /// <summary>
    /// Get all reservation from database which is active
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetAllReservations")]
    public IActionResult GetAllReservations()
    {
        var all = _services.GetAllAsync();
        if (all.Any())
        {
            return Ok(all);
        }
        return NotFound("No item found");
    }

    /// <summary>
    /// add new reservation to database
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost("AddNewReservation")]
    public IActionResult AddNewReservation(ReservationDto req)
    {
        _services.Add(new Reservations
        {
            ReturnDate = req.ReturnDate,
            BookId = req.BookId,
            Note = req.Note,
            UserId = req.UserId
        });
        return Ok("new reservation is added");
    }

    /// <summary>
    /// Delete reservation to database, if user do not want anymore
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("DeleteReservationById/{id}")]
    public IActionResult DeleteReservationById(int id)
    {
        _services.DeleteById(id);
        return Ok("delete reservation");
    }
}
