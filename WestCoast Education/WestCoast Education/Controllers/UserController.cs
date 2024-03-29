﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WestCoast_Education.DAL.Models;

namespace WestCoast_Education.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly WCEStorage _wceStorage;

        public UserController([FromServices]WCEStorage wceStorage)
        {
            _wceStorage = wceStorage;
        }

        [HttpGet]
        public IResult GetAllUsers()
        {
            var users = _wceStorage.GetAllUsers();

            if (users.Count <= 0)
            {
                return Results.NotFound();
            }

            return Results.Ok(users);
        }

        [HttpGet("{email}")]
        public IResult GetUser(string email)
        {
            var user = _wceStorage.GetUserByEmail(email);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        }

        [HttpPost]
        public IResult CreateUser([FromBody] User user)
        {
            if (user is null)
                return Results.BadRequest();

            return _wceStorage.CreateUser(user) ? Results.Ok() : Results.Conflict();
            
        }
        [HttpPut("{id}")]
        public IResult UpdateUser(int id, [FromBody] User user)
        {
            if (user is null)
            {
                return Results.BadRequest();
            }

            return _wceStorage.UpdateUser(id, user) ? Results.Ok() : Results.NotFound();
        }
    }
}
