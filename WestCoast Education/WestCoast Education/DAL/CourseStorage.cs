using WestCoast_Education.DAL.Models;

namespace WestCoast_Education.DAL
{
    public class CourseStorage
    {
        private readonly IDictionary<int, Course> _courses;
        private int _id;

        public CourseStorage()
        {
            _courses = new Dictionary<int, Course>();
        }
        //TODO Create CRUD operations for Courses

        public bool CreateCourse(Course course)
        {
            if (_courses.Values.Contains(course))
            {
                return false;
            }
            _courses.Add(_id++, course);
            return true;
        }

        public ICollection<Course> GetAllCourses()
        {
            if (_courses.Count <= 0)
            {
                return null;
            }

            return (ICollection<Course>) _courses.ToList();
        }

        public void GetCourse()
        {

        }

        public void UpdateCourse()
        {

        }

        public void DeleteCourse()
        {

        }
    }
}
