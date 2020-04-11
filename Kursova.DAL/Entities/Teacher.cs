namespace Kursova.DAL.Entities
{
    public class Teacher
    {
        public Teacher() { }
        public Teacher(int _Id, string _Initials, string _Grade, string _Kafedra, string _Email, string _Password)
        {
            Id = _Id;
            Initials = _Initials;
            Grade = _Grade;
            Kafedra = _Kafedra;
            Email = _Email;
            Password = _Password;
        }
        public int Id { get; set; }
        public string Initials { get; set; }
        public string Grade { get; set; }
        public string Kafedra { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
