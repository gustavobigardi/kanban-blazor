using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Server.Controllers
{
    public class ControllerBase : Controller
    {
        protected IActionResult GetValidationErrors()
        {
            return BadRequest(new
            {
                errorCount = ModelState.ErrorCount,
                errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                )
            });
        }
    }
}