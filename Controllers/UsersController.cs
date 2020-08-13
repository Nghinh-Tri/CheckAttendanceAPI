using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace CheckAttendanceAPI.Controllers
{
    [Authorize]
    [Route("api/users")]
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
            var result = repository.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<Users> GetUserById(string id)
        {
            var result = repository.GetById(id);

            if (result != null)
            {
                return Ok(mapper.Map<UserGetDTO>(result));
            }
            return NotFound();
        }

        [HttpPost(Name = "CreateUsers")]
        public ActionResult CreateUsers([FromBody] UserCreatorDTO users)
        {
            Users model = mapper.Map<Users>(users);
            var isExist = repository.GetById(model.UserId);
            if (isExist == null)
            {
                repository.Insert(model);
                bool resutl = repository.SaveChanges();
                if (resutl)
                    return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUser(string id)
        {
            var isExist = repository.GetById(id);
            if (isExist != null)
            {
                repository.Delete(isExist);
                repository.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, [FromBody] UserUpdateDTO userUpdate) { 
            var isExist = repository.GetById(id);
            if (isExist != null)
            {
                mapper.Map(userUpdate, isExist);
                repository.Update(isExist);
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