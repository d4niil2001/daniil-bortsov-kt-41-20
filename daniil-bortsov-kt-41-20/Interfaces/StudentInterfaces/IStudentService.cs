using daniil_bortsov_kt_41_20.Database;
using daniil_bortsov_kt_41_20.Filters.StudentFilter;
using daniil_bortsov_kt_41_20.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace daniil_bortsov_kt_41_20.Interfaces.IStudentInterfaces
{
    public interface IStudentService
    {
        public Task<int[]> GetMarksByStudentAsync(MarkStudentFilter filter, CancellationToken cancellationToken);
        public Task<double> GetGPAByGroupAsync(GPAFilter filter, CancellationToken cancellationToken);
        public Task<double> GetGPAByYearAsync(GPAYearFilter filter, CancellationToken cancellationToken);
    }

    public class StudentService : IStudentService
    {

        private readonly StudentDbContext _dbContext;

        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int[]> GetMarksByStudentAsync(MarkStudentFilter filter, CancellationToken cancellationToken = default)
        {
            var marks = _dbContext.Set<Grade>().Where(d => d.Student.StudentName == filter.Name && d.Subject.SubjectName == filter.Subject).Select(t => t.Mark).ToArrayAsync(cancellationToken);
            return marks;
        }

        public Task<double> GetGPAByGroupAsync(GPAFilter filter, CancellationToken cancellationToken =default)
        {
            var gpa = _dbContext.Set<Grade>().Where(d => d.Subject.SubjectName == filter.Subject && d.Student.Group.GroupName==filter.Group).Average(d => d.Mark);
            return Task.FromResult(gpa);
        }

        public Task<double> GetGPAByYearAsync(GPAYearFilter filter, CancellationToken cancellationToken)
        {
            var gpa = _dbContext.Set<Grade>().Where(d => d.Year == filter.Year).Average(d => d.Mark);
            return Task.FromResult(gpa);
        }
    }
}
