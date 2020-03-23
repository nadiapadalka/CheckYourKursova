using System;
using Xunit;
using Kursova.DAL.EF;
using Kursova.DAL.Repositories;
using Kursova.BLL.DTO;
using System.Linq;
using Kursova.BLL.Services;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UnitTestProject1
{

    public class StudentServiceTest : IDisposable
    {
        KursovaDbContext databaseContext;
        DbContextOptions<KursovaDbContext> options = new DbContextOptionsBuilder<KursovaDbContext>()
                      .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                      .Options;
        KursovaDbContext CreateDatabase()
        {
            databaseContext = new KursovaDbContext(options);
            return databaseContext;
        }

        StudentService CreateStudentService()
        {
            databaseContext = CreateDatabase();
            return new StudentService(new EFUnitOfWork(databaseContext));
        }
        StudentService CreateTestStudents()
        {
            StudentService StudentService = CreateStudentService();


            StudentService.CreateStudent(new StudentDTO
            {
                Id = 132,
                Name = "Yaroslav",
                Surname = "Nolkuchak",
                Group = "Pmi31",
                Kafedra = "Programming",
                Email = "simonnolkuchak@com",
                Password = "1178"

            });
            StudentService.CreateStudent(new StudentDTO
            {
                Id = 122,
                Name = "Nadiia",
                Surname = "Padalka",
                Group = "Pmi33",
                Kafedra = "Programming",
                Email = "nadiiapadalka@com",
                Password = "2124"

            });
            return StudentService;
        }

        public void Dispose()
        {
            databaseContext.Database.EnsureDeleted();
        }
        [Fact]
        public void TestCreateStudentMethod()
        {

            var StudentService = CreateTestStudents();

            int res = StudentService.GetAll().Count();

            Assert.Equal(2, res);

        }

        [Fact]
        public void TestDeleteStudentMethod()
        {
            var StudentService = CreateStudentService();


            StudentService.CreateStudent(new StudentDTO
            {
                Id = 132,
                Name = "Yaroslav",
                Surname = "Nolkuchak",
                Group = "Pmi31",
                Kafedra = "Programming",
                Email = "simonnolkuchak@com",
                Password = "1178"

            });
            StudentService.CreateStudent(new StudentDTO
            {
                Id = 122,
                Name = "Nadiia",
                Surname = "Padalka",
                Group = "Pmi33",
                Kafedra = "Programming",
                Email = "nadiiapadalka@com",
                Password = "2124"

            });
            //var Student = StudentService.GetAll().FirstOrDefault();
            StudentService.Dispose(122);
            int res = StudentService.GetAll().Count();

            Assert.Equal(1, res);

        }
        [Fact]
        public void TestGetByID()
        {

            var StudentService = CreateTestStudents();

            var Student = StudentService.GetAll().FirstOrDefault();

            Assert.NotNull(StudentService.GetById(Student.Id));

        }

        [Fact]
        public void TestGetByID_StudentIdEqualNull_Exeption()
        {

            var StudentService = CreateTestStudents();

            Exception ex = Assert.Throws<ValidationException>(() => StudentService.GetById(null));
           
            Assert.Equal("ID not set.", ex.Message);

        }

        [Fact]
        public void TestGetByID_StudentEqualNull_Exeption()
        {
            var StudentService = CreateTestStudents();
            var Student = StudentService.GetAll().FirstOrDefault();
            StudentService.Dispose(132);
            StudentService.Dispose(122);

            Exception ex = Assert.Throws<ValidationException>(() => StudentService.GetById(Student.Id));

            Assert.Equal("Student with this ID was not found", ex.Message);

        }

        [Fact]
        public void TestGetStudent()
        {


            var StudentService = CreateTestStudents();

            var Student = StudentService.GetAll().FirstOrDefault();
            Assert.Equal(132, StudentService.Get(Student.Id).Id);



        }
        [Fact]
        public void TestGetStudentName()
        {


            var StudentService = CreateTestStudents();

            var Student = StudentService.GetAll().FirstOrDefault();
            Assert.Equal(Student.Name, StudentService.GetFirstName(Student.Id));



        }
    }
}
