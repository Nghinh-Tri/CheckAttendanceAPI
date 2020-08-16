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

        //Get all
        [HttpGet]
        public ActionResult<IEnumerable<Users>> GetAllUsers()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Users>> result = new Dictionary<string, IEnumerable<Users>>();
                result.Add("Users", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get by Id
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult<Users> GetUserById(string id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<UserGetDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Insert
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

        //Delete
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

        //Update
        [HttpPut("{id}")]
        public ActionResult UpdateUser(string id, [FromBody] UserUpdateDTO userUpdate)
        {
            try
            {
                var isExist = repository.GetById(id);
                if (isExist != null)
                {
                    mapper.Map(userUpdate, isExist);
                    repository.Update(isExist);
                    bool resutl = repository.SaveChanges();
                    if (resutl)
                        return Ok();
                }
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
    }
}