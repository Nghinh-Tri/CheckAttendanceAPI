using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs.Adminstrators;

namespace CheckAttendanceAPI.Controllers
{
    [Authorize]
    [Route("/api/authenticate")]
    public class AuthenticateController: ControllerBase
    {
        private readonly IAuthentication repository;
        private readonly IMapper mapper;

        public AuthenticateController(IAuthentication repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] AdministratorsDTO dto)
        {
            var account = mapper.Map<Administrators>(dto);
            string token = repository.Authenticate(account);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
    }
}