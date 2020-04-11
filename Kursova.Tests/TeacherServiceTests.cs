//using System;
//using Xunit;
//using Kursova.DAL.EF;
//using Kursova.DAL.Repositories;
//using Kursova.BLL.DTO;
//using System.Linq;
//using Kursova.BLL.Services;
//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;

//namespace Kursova.Tests
//{
//    public class StudentServiceTest : IDisposable
//    {

//        KursovaDbContext Context;
//        public DbContextOptions<KursovaDbContext> options = new DbContextOptionsBuilder<KursovaDbContext>()
//                       .UseInMemoryDatabase(databaseName: "TeacherDatabase")
//                       .Options;

//        TeacherService CreateTeacherService()
//        {
//            Context = new KursovaDbContext(options);


//            return new TeacherService(new EFUnitOfWork(Context));
//        }
//        public void Dispose()
//        {
//            Context.Database.EnsureDeleted();
//        }
//        TeacherService CreateTestTeachers()
//        {
//            TeacherService TeacherService = CreateTeacherService();


//            TeacherService.CreateTeacher(new TeacherDTO
//            {
//                Id = 132,
//                Initials = "Oleksii Nyzhyuk",
//                Grade = "Professor",
//                Kafedra = "Programming",
//                Email = "oleksii@com",
//                Password = "2288"

//            });
//            TeacherService.CreateTeacher(new TeacherDTO
//            {
//                Id = 122,
//                Initials = "Nadiia Padalka",
//                Grade = "dean",
//                Kafedra = "Programming",
//                Email = "nadiiapadalka@com",
//                Password = "2124"

//            });
//            return TeacherService;
//        }
//        [Fact]
        

//        public void TestCreateTeacherMethod()
//        {
//            var TeacherService = CreateTestTeachers();

//            int res = TeacherService.GetAll().Count();

//            Assert.Equal(2, res);

//        }

        
//        [Fact]
//        public void GetTeacherByID()
//        {
//            var TeacherService = CreateTestTeachers();

//            var Teacher = TeacherService.GetAll().FirstOrDefault();

//            Assert.NotNull(TeacherService.GetById(Teacher.Id));
//        }
//        [Fact]
//        public void TestGetByID()
//        {


//            var TeacherService = CreateTestTeachers();

//            var Teacher = TeacherService.GetAll().FirstOrDefault();

//            Assert.Equal("oleksii@com" ,TeacherService.GetById(Teacher.Id).Email);



//        }

//        [Fact]
//        public void TestGetByID_TeachersIdEqualNull_Exeption()
//        {

//            var TeachersService = CreateTestTeachers();

//            Exception ex = Assert.Throws<ValidationException>(() => TeachersService.GetById(null));

//            Assert.Equal("ID not set.", ex.Message);

//        }

//        [Fact]
//        public void TestGetByID_TeachersEqualNull_Exeption()
//        {
//            var TeachersService = CreateTestTeachers();
//            var Teachers = TeachersService.GetAll().FirstOrDefault();
//            TeachersService.Dispose(132);
//            TeachersService.Dispose(122);

//            Exception ex = Assert.Throws<ValidationException>(() => TeachersService.GetById(Teachers.Id));

//            Assert.Equal("Teacher with this ID was not found", ex.Message);

//        }

//        [Fact]
//        public void TestGetTeacher()
//        {


//            var TeacherService = CreateTestTeachers();
//            TeacherService.Dispose(132);

//            var Student = TeacherService.GetAll().FirstOrDefault();

//            Assert.Equal("dean", TeacherService.Get(Student.Id).Grade);



//        }
//        [Fact]
//        public void TestGetTeacherName()
//        {


//            var teacherService = CreateTestTeachers();

//            var Student = teacherService.GetAll().FirstOrDefault();

//            Assert.Equal("Oleksii Nyzhyuk", teacherService.GetInitials(Student.Id));



//        }
//    }
//}
//