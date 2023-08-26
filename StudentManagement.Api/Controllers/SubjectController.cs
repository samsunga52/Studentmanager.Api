using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interface.ISubject;
using StudentManagement.Model.Subjects;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubject _repository;
        public SubjectController(ISubject repository)
        {
            _repository = repository;
        }

        [HttpGet("Subjects")]
        [SwaggerOperation]
        public async Task<ActionResult<IEnumerable<Subjects>>> GetAll()
        {
            var users = await _repository.GetAllSubjects();
            return Ok(users);
        }

        [HttpPut("Delete/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<Subjects>> Delete(Subjects e)
        {
            _repository.Delete(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to delete user");
        }

        //api/Users/3
        [HttpGet("GetById/{Id}")]
        [SwaggerOperation]
        public async Task<ActionResult<Subjects>> GetById(int Id)
        {
            return await _repository.GetSubjectById(Id);

        }

        [HttpGet("GetSubjectByName/{Name}")]
        [SwaggerOperation]
        public async Task<ActionResult<Subjects>> GetSubjectByName(string Name)
        {
            return await _repository.GetSubjectByName(Name);
        }

        [HttpPut("Update/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Update(Subjects e)
        {

            _repository.Put(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpPost("Post/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Post(Subjects e)
        {

            _repository.Post(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}
