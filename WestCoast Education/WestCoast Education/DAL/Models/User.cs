namespace WestCoast_Education.DAL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Email { get; set; }
        public string Cellphone { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }

        public ICollection<Course>? TakenCourses { get; set; } 
    }
}
