using Kanban.Server.Services;
using Kanban.Shared.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    public class ArtifactsController : ControllerBase
    {
        private readonly IArtifactService _artifactService;

        public ArtifactsController(IArtifactService artifactService)
        {
            _artifactService = artifactService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var artifacts = _artifactService.ListAll();
            return Ok(artifacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var artifact = _artifactService.FindById(id);
            return Ok(artifact);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Artifact artifact)
        {
            if (ModelState.IsValid)
            {
                artifact = _artifactService.Create(artifact);
                return CreatedAtAction(nameof(GetById), new { id = artifact.Id }, artifact);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Artifact artifact, long id)
        {
            if (ModelState.IsValid)
            {
                artifact = _artifactService.Update(artifact);
                return Ok(artifact);
            }
            else
            {
                return GetValidationErrors();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _artifactService.Delete(id);
            return NoContent();
        }
    }
}