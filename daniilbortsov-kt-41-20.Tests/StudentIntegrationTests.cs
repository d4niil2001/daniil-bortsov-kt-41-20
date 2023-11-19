using daniil_bortsov_kt_41_20.Models;
using daniil_bortsov_kt_41_20.Database;
using Microsoft.EntityFrameworkCore;
using daniil_bortsov_kt_41_20.Filters.StudentFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using daniil_bortsov_kt_41_20.Interfaces.IStudentInterfaces;

namespace daniilbortsov_kt_41_20.Tests
{
    public class StudentIntegrationTests
    {
        public readonly DbContextOptions<StudentDbContext> _dbContextOptions;

        public StudentIntegrationTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<StudentDbContext>()
            .UseInMemoryDatabase(databaseName: "student_db")
            .Options;
        }
        [Fact]
        public async Task GetMarksByStudentsAsync_OneObject()
        {
            // Arrange
            var ctx = new StudentDbContext(_dbContextOptions);
            var studentService = new StudentService(ctx);
            var student = new List<Student>
            {
                new Student
                {
                    StudentSurname = "Борцов",
                    StudentName = "Даниил",
                    StudentMidname = "Сергеевич"
                },
                new Student
                {
                    StudentSurname = "Иванов",
                    StudentName = "Иван",
                    StudentMidname = "Иванович"
                }
            };
            await ctx.Set<Student>().AddRangeAsync(student);

            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "Программирование",

                },
                new Subject
                {
                    SubjectName = "Математика",
                },
            };
            await ctx.Set<Subject>().AddRangeAsync(subjects);

            var marks = new List<Grade>
            {
                new Grade
                {
                    Mark = 5,
                    StudentId = 1,
                    SubjectId = 1
                },
                new Grade
                {
                    Mark = 4,
                    StudentId = 2,
                    SubjectId = 1
                },
                new Grade
                {
                    Mark = 5,
                    StudentId = 1,
                    SubjectId = 2
                }
            };
            await ctx.Set<Grade>().AddRangeAsync(marks);


            await ctx.SaveChangesAsync();

            // Act
            var filter = new daniil_bortsov_kt_41_20.Filters.StudentFilter.MarkStudentFilter
            {
               Surname = "Борцов",
               Name = "Даниил",
               Midname = "Сергеевич",
               Subject = "Программирование",
            };
            var marksResult = await studentService.GetMarksByStudentAsync(filter, CancellationToken.None);

            // Assert
            Assert.Single(marksResult);

        }
    }
}
