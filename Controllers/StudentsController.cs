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
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepository repository;
        private readonly IMapper mapper;
        public StudentsController(IStudentsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Students>>> GetAllStudents(){
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Students>> result = new Dictionary<string, IEnumerable<Students>>();
                result.Add("Students", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get All
        [HttpGet("{id}")]
        public ActionResult<StudentsReadDTO> GetSlotById(string id){
            try
            {
                var student =  repository.GetById(id);                
                return Ok(mapper.Map<StudentsReadDTO>(student));
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] StudentsCreateDTO dto){
            try
            {
                var model = mapper.Map<Students>(dto);
                if (model != null){
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
        public IActionResult Update(string id, [FromBody] StudentsCreateDTO dto){
            try
            {
                var isExist = repository.GetById(id);
                if (isExist != null){
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