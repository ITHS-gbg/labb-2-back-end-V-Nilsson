using System.Linq;

namespace WestCoast_Education.DAL.Models
{
    public class WCEStorage
    {
        private readonly IDictionary<int, Course> _courses;
        private int _id;

        public WCEStorage()
        {
            _courses = new Dictionary<int, Course>();
        }
        

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
            return _courses.Values;
        }

        public Course GetCourse(int id)
        {
            // TODO Should retired courses be removed from this list??
            if (!_courses.Keys.Contains(id))
            {
                return null;
            }
            return _courses[id];
        }

        public bool UpdateCourse(int id, Course course)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses[id] = course;
            return true;
        }

        public bool DeleteCourse(int id)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses.Remove(id);
            return true;
        }

        public bool RetireCourse(int id)
        {
            if (!_courses.Keys.Contains(id))
            {
                return false;
            }

            _courses[id].IsActive = false;
            return true;
        }
    }
}
