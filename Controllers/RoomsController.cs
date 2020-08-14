using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace Controllers
{
    [Authorize]
    [Route("api/rooms")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomsRepository repository;
        private readonly IMapper mapper;

        public RoomsController(IRoomsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, List<Rooms>>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, List<Rooms>> result = new Dictionary<string, List<Rooms>>();
                result.Add("Rooms", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get by ID
        [HttpGet("{id}")]
        public ActionResult<RoomsDTO> GetById(int id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<RoomsDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Insert
        [HttpPost]
        public IActionResult Insert([FromBody] RoomsDTO dto)
        {
            try
            {
                var model = mapper.Map<Rooms>(dto);
                if (model != null)
                {
                    repository.Insert(model);
                    var result = repository.SaveChanges();
                    if (result)
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