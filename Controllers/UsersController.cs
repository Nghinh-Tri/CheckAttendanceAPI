using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Controllers
{
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;

        public UsersController(IUsersRepository repository) { this.repository = repository; }

        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetAllUsers()
        {
            var result = repository.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Users> GetUserById(string id)
        {
            var result = repository.GetUserById(id);
            if (result != null){
                return Ok(result);
            }
            return NotFound();
        }
    }
}