namespace Kursova.BLL.DTO
{
    public class TeacherDTO
    {
        public TeacherDTO() { }

        public int Id { get; set; }

        public string Initials { get; set; }

        public string Grade { get; set; }

        public string Kafedra { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
