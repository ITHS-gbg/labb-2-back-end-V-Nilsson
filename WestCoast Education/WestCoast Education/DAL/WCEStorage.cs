using System.Linq;

namespace WestCoast_Education.DAL.Models
{
    public class WCEStorage
    {

        private readonly WCEContext _wceContext;

        public WCEStorage(WCEContext wceContext)
        {
            _wceContext = wceContext;
        }
        

        public bool CreateCourse(Course course)
        {
            if (_wceContext.Courses.Contains(course))
            {
                return false;
            }

            _wceContext.Courses.Add(course);
            _wceContext.SaveChanges();
            return true;
        }

        public ICollection<Course> GetAllCourses()
        {
            return _wceContext.Courses.Where(c => true).ToList();
        }

        public Course? GetCourse(int id)
        {
            return _wceContext.Courses.FirstOrDefault(c => c.Id == id);
        }

        public bool UpdateCourse(int id, Course course)
        {
            var newCourse = _wceContext.Courses.FirstOrDefault(c => c.Id == id);
            if (newCourse is null)
            {
                return false;
            }

            newCourse.Title = course.Title;
            newCourse.Description = course.Description;
            newCourse.Length = course.Length;
            newCourse.Level = course.Level;
            _wceContext.SaveChanges();
            return true;
        }

        public bool DeleteCourse(int id)
        {
            var existingCourse = GetCourse(id);
            if (existingCourse is null)
            {
                return false;
            }

            _wceContext.Remove(existingCourse);
            _wceContext.SaveChanges();
            return true;
        }

        public bool RetireCourse(int id)
        {
            var existingCourse = GetCourse(id);
            if (existingCourse is null)
            {
                return false;
            }

            existingCourse.IsActive = false;
            _wceContext.SaveChanges();
            return true;
        }

        public bool CreateUser(User user)
        {
            var newUser = _wceContext.Users.FirstOrDefault(u => u.Email == user.Email);

            if (newUser is not null)
            {
                return false;
            }

            _wceContext.Users.Add(user);
            _wceContext.SaveChanges();
            return true;
        }

        public ICollection<User> GetAllUsers()
        {
            return _wceContext.Users.Where(u => true).ToList();
        }

        public User? GetUserByEmail(string email)
        {
            return _wceContext.Users.FirstOrDefault(u => u.Email == email);
        }
        public User? GetUserById(int id)
        {
            return _wceContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public bool UpdateUser(int id, User user)
        {
            var newUser = _wceContext.Users.FirstOrDefault(u => u.Id == id);
            if (newUser is null)
            {
                return false;
            }

            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.Email = user.Email;
            newUser.Cellphone = user.Cellphone;
            newUser.City = user.City;
            newUser.ZipCode = user.ZipCode;
            newUser.Street = user.Street;
            _wceContext.SaveChanges();
            return true;
        }

        public bool DeleteUser(int id)
        {
            var existingUser = GetUserById(id);
            if (existingUser is null)
            {
                return false;
            }

            _wceContext.Remove(existingUser);
            _wceContext.SaveChanges();
            return true;
        }
    }

}
