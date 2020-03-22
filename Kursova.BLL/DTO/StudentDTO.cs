namespace Kursova.BLL.DTO
{
    public class StudentDTO
    {
        public StudentDTO() { }
        public StudentDTO(int student_ID, string first_Name, string last_Name, string group, string kafedra,string email)
        {
            this.Id = student_ID;
            this.Name = first_Name;
            this.Surname = last_Name;
            this.Email = group;
            this.Group = kafedra;
            this.Email = email;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public string Kafedra { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
