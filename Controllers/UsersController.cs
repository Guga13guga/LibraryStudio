using LibraryStudio.Database;
using LibraryStudio.Interface;
using LibraryStudio.Models;
using LibraryStudio.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryStudio.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IGenericService<User> _userService;

    public UsersController(LibraryDbContext context)
    {
        _userService = new GenericService<User>(context);
    }

    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var all = _userService.GetAllAsync();
        if (all.Any() == false) return NotFound("Users not found");
        return Ok(all);
    }

    [HttpGet("GetById/{id}")]
    public  IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound("No user found");
        return Ok(user);
    }

    [HttpPost("AddNewUser")]
    public IActionResult AddNewUser(User user)
    {
        _userService.Add(user);
        return Ok();
    }

    [HttpDelete("DeleteUserById/{id}")]
    public IActionResult Delete(int id)
    {
        _userService.DeleteById(id);
        return Ok("User deleted");
    }

    [HttpPut("UpdateUser")]
    public IActionResult UpdateUser(User user)
    {
        _userService.Update(user);
        return Ok();
    }
}
