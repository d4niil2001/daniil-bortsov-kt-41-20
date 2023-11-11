using daniil_bortsov_kt_41_20.Filters.StudentFilter;
using daniil_bortsov_kt_41_20.Interfaces.IStudentInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace daniil_bortsov_kt_41_20.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentService _studentService;

        public StudentController(ILogger<StudentController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetMarksByStudent")]


        public async Task<IActionResult> GetMarksByStudentAsync(MarkStudentFilter filter, CancellationToken cancellationToken = default)
        {
            var marks = await _studentService.GetMarksByStudentAsync(filter, cancellationToken);
            return Ok(marks);
        }
    }

}
