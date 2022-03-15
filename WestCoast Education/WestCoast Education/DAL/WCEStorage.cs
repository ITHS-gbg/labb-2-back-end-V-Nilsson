using System.Linq;

namespace WestCoast_Education.DAL.Models
{
    public class WCEStorage
    {
        private readonly IDictionary<int, Course> _courses;
        private readonly IDictionary<int, User> _users;
        private int _id;
        private int _userId;

        public WCEStorage()
        {
            _courses = new Dictionary<int, Course>();
            _users = new Dictionary<int, User>();
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

        public bool CreateUser(User user)
        {
            if (_users.Values.Contains(user))
                return false;
            _users.Add(_userId++, user);
            return true;
        }

        public ICollection<User> GetAllUsers()
        {
            return _users.Values;
        }

        public User? GetUser(int id)
        {
            if (!_users.Keys.Contains(id))
                return null;
            return _users[id];
        }

        public bool UpdateUser(int id, User user)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users[id] = user;

            return true;
        }

        public bool DeleteUser(int id)
        {
            if (!_users.Keys.Contains(id))
            {
                return false;
            }

            _users.Remove(id);

            return true;
        }
    }
}
}
