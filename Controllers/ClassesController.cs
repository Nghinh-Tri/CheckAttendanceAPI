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
    [Route("api/classes")]
    public class ClassesController : ControllerBase
    {
        private readonly IClassesRepository repository;
        private readonly IMapper mapper;
        public ClassesController(IClassesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Classes>>> GetAllClasses()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Classes>> result = new Dictionary<string, IEnumerable<Classes>>();
                result.Add("Classes", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get By id
        [HttpGet("{id}")]
        public ActionResult<ClassesReadDTO> GetClassesById(int id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<ClassesReadDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] ClassesWriteDTO dto)
        {
            try
            {
                var model = mapper.Map<Classes>(dto);
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
        public IActionResult Update(int id, [FromBody] ClassesWriteDTO dto)
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