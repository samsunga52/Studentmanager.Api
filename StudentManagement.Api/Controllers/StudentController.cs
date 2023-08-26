using Microsoft.AspNetCore.Mvc;
using StudentManagement.Interface.IStudent;
using StudentManagement.Model.Student;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudents _repository;
        public StudentController(IStudents repository)
        {
            _repository = repository;
        }

        [HttpGet("Students/{UserId}")]
        [SwaggerOperation]
        public async Task<ActionResult<IEnumerable<StudentSubjectModel>>> GetAll(int UserId)
        {
            var users = await _repository.GetStudentSubjects(UserId);
            return Ok(users);
        }


        [HttpPut("Delete/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<Student>> Delete(Student e)
        {
            _repository.Delete(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to delete user");
        }

        //api/Users/3
        [HttpGet("GetById/{Id}")]
        [SwaggerOperation]
        public async Task<ActionResult<StudentSubjectModel>> GetById(int Id)
        {
            return await _repository.GetStudentSubjectsById(Id);

        }

        [HttpGet("GetStudentByIdNumber/{Id}")]
        [SwaggerOperation]
        public async Task<ActionResult<Student>> GetStudentByIdNumber(string Id)
        {
            return await _repository.GetStudentByIdNumber(Id);
        }

        [HttpPut("Update/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Update(StudentSubjectModel e)
        {

             _repository.Put(e);
            if (await _repository.SaveAllAsync()) return NoContent();
             
            return BadRequest("Failed to update user");
        }

        [HttpPost("Post/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Post(Student e)
        {

            _repository.Post(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}
