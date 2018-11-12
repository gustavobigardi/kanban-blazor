using Kanban.Server.Services;
using Kanban.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class IterationsController : ControllerBase
    {
        private readonly IIterationService _iterationService;

        public IterationsController(IIterationService iterationService)
        {
            _iterationService = iterationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var iterations = _iterationService.ListAll();
            return Ok(iterations);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var project = _iterationService.FindById(id);
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Iteration iteration)
        {
            if (ModelState.IsValid)
            {
                iteration = _iterationService.Create(iteration);
                return CreatedAtAction(nameof(GetById), new { id = iteration.Id }, iteration);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Iteration iteration, long id)
        {
            if (ModelState.IsValid)
            {
                iteration = _iterationService.Update(iteration);
                return Ok(iteration);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _iterationService.Delete(id);
            return NoContent();
        }
    }
}