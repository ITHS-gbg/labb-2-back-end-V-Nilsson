using Microsoft.AspNetCore.Mvc;
using WestCoast_Education.DAL;
using WestCoast_Education.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WCEStorage>();

var app = builder.Build();


app.MapGet("/courses", ([FromServices] WCEStorage storage) =>
{
    var courses = storage.GetAllCourses();

    if (courses.Count <= 0)
    {
        return Results.NotFound();
    }

    return Results.Ok(courses);
});

app.MapGet("/courses/{id}", ([FromServices] WCEStorage storage, int id) =>
{
    var course = storage.GetCourse(id);

    return course is null ? Results.NotFound() : Results.Ok(course);
});

app.MapPost("/courses", ([FromServices] WCEStorage storage, Course course) =>
{
    if (course is null)
    {
        return Results.BadRequest();
    }

    return storage.CreateCourse(course) ? Results.Ok() : Results.Conflict();
});

app.MapPut("/courses/{id}", ([FromServices] WCEStorage storage, Course course, int id) =>
{
    if (course is null)
    {
        return Results.BadRequest();
    }

    return storage.UpdateCourse(id, course) ? Results.Ok() : Results.Conflict();

});

app.MapMethods("/courses/status/{id}", new[] {"PATCH"},
    ([FromServices] WCEStorage storage, int id) =>
    {
        return storage.RetireCourse(id) ? Results.Ok() : Results.BadRequest() ;
    });



app.Run();
