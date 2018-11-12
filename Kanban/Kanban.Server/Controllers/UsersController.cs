using System.Linq;
using Kanban.Server.Services;
using Kanban.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.ListAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var user = _userService.FindById(id);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                user = _userService.Create(user);
                return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] User user, long id)
        {
            if (ModelState.IsValid)
            {
                user = _userService.Update(user);
                return Ok(user);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _userService.Delete(id);
            return NoContent();
        }
    }
}