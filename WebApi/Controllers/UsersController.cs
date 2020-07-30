using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
      _userService = userService;
    }

    [HttpGet(Name = "Get")]
    public ActionResult<List<User>> Get() =>
      _userService.Get();

    [HttpGet("{id:length(24)}", Name = "GetUser")]
    public ActionResult<User> Get(string id)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

    [HttpPost]
    public ActionResult<User> Create(User user)
    {
      _userService.Create(user);
      return CreatedAtRoute(nameof(Get), new { id = user.Id.ToString() }, user);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, User userIn)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      _userService.Update(id, userIn);

      return RedirectToAction();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Remove(string id)
    {
      var user = _userService.Get(id);

      if (user == null)
      {
        return NotFound();
      }

      _userService.Remove(user.Id);

      return RedirectToAction();
    }
  }
}
