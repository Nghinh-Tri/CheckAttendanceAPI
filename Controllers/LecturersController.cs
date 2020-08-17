using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.DTOs;
using CheckAttendanceAPI.Models;

namespace Controllers
{
    [Authorize]
    [Route("api/lecturers")]
    public class LecturersController : ControllerBase
    {
        private readonly ILecturersRepository repository;
        private readonly IMapper mapper;
        public LecturersController(ILecturersRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Lecturers>>> GetAllStudents()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Lecturers>> result = new Dictionary<string, IEnumerable<Lecturers>>();
                result.Add("Lecturers", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get by Id
        [HttpGet("{id}")]
        public ActionResult<LecturersDTO> GetSlotById(string id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<LecturersDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] LecturersDTO dto)
        {
            try
            {
                var model = mapper.Map<Lecturers>(dto);
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
        //Update
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] LecturersDTO dto)
        {
            try
            {
                var isExist = repository.GetById(id);
                if (isExist != null)
                {
                    mapper.Map(dto, isExist);
                    repository.Update(isExist);
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