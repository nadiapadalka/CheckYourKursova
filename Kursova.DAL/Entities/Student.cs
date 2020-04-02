namespace Kursova.DAL.Entities
{
    public class Student
    {
        public Student() { }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public string Kafedra { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
