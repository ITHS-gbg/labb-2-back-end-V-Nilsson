namespace WestCoast_Education.DAL.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Length { get; set; }

        // Status, Active or retired. Gets set as active when we initiate a course
        public bool IsActive { get; set; } = true;
    }
}
