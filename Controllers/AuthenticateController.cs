using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace CheckAttendanceAPI.Controllers
{
    [Authorize]
    [Route("api/admin")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthentication repository;
        private readonly IMapper mapper;

        public AuthenticateController(IAuthentication repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        /*
            Login method
            Input UserId, Password
            Url = .../api/login
            Method = POST
            Return Ok with token if success
            Return Unauthorized if account is not exist 
            Return Not Found if exception is occurred
        */
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] AdministratorsDTO dto)
        {
            try
            {
                var account = mapper.Map<Administrators>(dto);
                string token = repository.Authenticate(account);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        /*
            Sign up method
            Input UserId, Password
            Url = .../api/sign up
            Method = POST
            Return Ok if already have User id and sign up success
            Return Not Found if exception is occurred or not have User ID
        */
        [HttpPost("signup")]
        public IActionResult SignUp([FromBody] AdministratorsDTO dto)
        {
            try
            {
                var model = mapper.Map<Administrators>(dto);
                if (model != null)
                {
                    model.Status = true;
                    repository.Insert(model);
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

        /*
            Change admin stauts method
            Input UserId, Password
            Url = .../api/sign up
            Method = POST
            Return Ok if already have User id and sign up success
            Return Not Found if exception is occurred or not have User ID
        */
        [HttpPut("{id}")]
        public IActionResult ChangeStatus(string id, [FromBody] AdministratorsStatusDTO dto)
        {
            try
            {
                var isExist = repository.GetById(id);
                if (isExist != null)
                {
                    mapper.Map(dto, isExist);
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