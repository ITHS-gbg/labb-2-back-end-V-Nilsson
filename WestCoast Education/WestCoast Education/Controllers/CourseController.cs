using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WestCoast_Education.DAL;
using WestCoast_Education.DAL.Models;

namespace WestCoast_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly WCEStorage _wceStorage;

        public CourseController([FromServices] WCEStorage wceStorage)
        {
            _wceStorage = wceStorage;
        }

        [HttpGet]
        public IResult GetCourses()
        {
            var courses = _wceStorage.GetAllCourses();

            if (courses.Count <= 0)
            {
                return Results.NotFound();
            }

            return Results.Ok(courses);
        }


        [HttpGet("{id}")]
        public IResult GetCourse(int id)
        {
            var course = _wceStorage.GetCourse(id);
            return course is null ? Results.NotFound() : Results.Ok(course);

        }

        [HttpPost]
        public IResult CreateCourse([FromBody] Course course)
        {
            if (course is null)
            {
                return Results.BadRequest();
            }

            return _wceStorage.CreateCourse(course) ? Results.Ok() : Results.Conflict();
        }

        [HttpPut("{id}")]
        public IResult UpdateCourse(int id, [FromBody] Course course)
        {
            if (course is null)
            {
                return Results.BadRequest();
            }

            return _wceStorage.UpdateCourse(id, course) ? Results.Ok() : Results.Conflict();
        }

        [HttpPatch("{id}")]
        public IResult RetireCourse(int id)
        {
            return _wceStorage.RetireCourse(id) ? Results.Ok() : Results.BadRequest();
        }

        [HttpDelete("{id}")]
        public IResult DeleteCourse(int id)
        {
            return _wceStorage.DeleteCourse(id) ? Results.Ok() : Results.BadRequest();
        }
    }
}