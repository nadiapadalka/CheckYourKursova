namespace Kursova.DAL.Entities
{
    public class Student
    {
        public Student() { }
        public Student(int _Id, string _FullName, string _Group, string _Kafedra, string _Email, string _Password) {
            Id = _Id;
            FullName = _FullName;
            Group = _Group;
            Kafedra = _Kafedra;
            Email = _Email;
            Password = _Password;
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Group { get; set; }
        public string Kafedra { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
