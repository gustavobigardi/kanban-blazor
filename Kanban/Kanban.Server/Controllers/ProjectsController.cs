using System;
using System.Linq;
using System.Net;
using Kanban.Server.Services;
using Kanban.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var projects = _projectService.ListAll();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var project = _projectService.GetById(id);
            return Ok(project);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            if (ModelState.IsValid)
            {
                project = _projectService.Create(project);
                return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Project project, long id)
        {
            if (ModelState.IsValid)
            {
                project = _projectService.Update(project);
                return Ok(project);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _projectService.Delete(id);
            return NoContent();
        }
    }
}