using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WestCoast_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        //app.MapGet("/courses", ([FromServices] WCEStorage storage) =>
    //    {
    //        var courses = storage.GetAllCourses();

    //        if (courses.Count <= 0)
    //        {
    //            return Results.NotFound();
    //        }

    //        return Results.Ok(courses);
    //    });

    //app.MapGet("/courses/{id}", ([FromServices] WCEStorage storage, int id) =>
    //{
    //    var course = storage.GetCourse(id);

    //    return course is null ? Results.NotFound() : Results.Ok(course);
    //});

    //app.MapPost("/courses", ([FromServices] WCEStorage storage, Course course) =>
    //{
    //    if (course is null)
    //    {
    //        return Results.BadRequest();
    //    }

    //    return storage.CreateCourse(course) ? Results.Ok() : Results.Conflict();
    //});

    //app.MapPut("/courses/{id}", ([FromServices] WCEStorage storage, Course course, int id) =>
    //{
    //    if (course is null)
    //    {
    //        return Results.BadRequest();
    //    }

    //    return storage.UpdateCourse(id, course) ? Results.Ok() : Results.Conflict();

    //});

    //app.MapMethods("/courses/status/{id}", new[] { "PATCH" },
    //    ([FromServices] WCEStorage storage, int id) =>
    //    {
    //        return storage.RetireCourse(id) ? Results.Ok() : Results.BadRequest();
    //    });
    //}
}
