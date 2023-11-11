using daniil_bortsov_kt_41_20.Filters.StudentFilter;
using daniil_bortsov_kt_41_20.Interfaces.IStudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace daniil_bortsov_kt_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GPAGroupController : Controller
    {
        private readonly ILogger<GPAGroupController> _logger;
        private readonly IStudentService _studentService;

        public GPAGroupController(ILogger<GPAGroupController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetGPAByGroup")]

        public async Task<IActionResult> GetGPAByGroupAsync(GPAFilter filter, CancellationToken cancellationToken = default)
        {
            var gpa = await _studentService.GetGPAByGroupAsync(filter, cancellationToken);
            return Ok(gpa);

        }
    }
}
