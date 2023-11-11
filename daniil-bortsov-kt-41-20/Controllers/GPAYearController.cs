using daniil_bortsov_kt_41_20.Filters.StudentFilter;
using daniil_bortsov_kt_41_20.Interfaces.IStudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace daniil_bortsov_kt_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GPAYearController : Controller
    {
        private readonly ILogger<GPAYearController> _logger;
        private readonly IStudentService _studentService;

        public GPAYearController(ILogger<GPAYearController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetGPAByYear")]

        public async Task<IActionResult> GetGPAByYearAsync(GPAYearFilter filter, CancellationToken cancellationToken = default)
        {
            var gpa = await _studentService.GetGPAByYearAsync(filter, cancellationToken);
            return Ok(gpa);
        }

    }
}
