using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using System.Text;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace CheckAttendanceAPI.Controllers
{
    [Route("/api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository repository;
        private readonly IMapper mapper;

        public UsersController(IUsersRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

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
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult CreateUsers([FromBody] UserCreatorDTO users)
        {
            Users model = mapper.Map<Users>(users);
            var isExist = repository.GetUserById(model.UserId);
            if (isExist == null)
            {
                repository.CreateUser(model);
                bool resutl = repository.SaveChanges();
                if (resutl)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var isExist = repository.GetUserById(id);
            if (isExist != null)
            {
                repository.DeleteUser(isExist);
                repository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, [FromBody] UserUpdateDTO userUpdate) { 
            var isExist = repository.GetUserById(id);
            if (isExist != null)
            {
                mapper.Map(userUpdate, isExist);
                repository.UpdateUser(isExist);
                bool resutl = repository.SaveChanges();
                if (resutl)
                {
                    return Ok();
                }
            }
            return NotFound();
         }
    }
}