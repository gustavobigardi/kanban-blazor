using Kanban.Server.Services;
using Kanban.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var teams = _teamService.ListAll();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var team = _teamService.FindById(id);
            return Ok(team);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Team team)
        {
            if (ModelState.IsValid)
            {
                team = _teamService.Create(team);
                return CreatedAtAction(nameof(GetById), new { id = team.Id }, team);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Team team, long id)
        {
            if (ModelState.IsValid)
            {
                team = _teamService.Update(team);
                return Ok(team);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _teamService.Delete(id);
            return NoContent();
        }
    }
}