using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOPASU.Domain;
using OOPASU.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OOPASU.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly Context _context;

        public StudentsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet]
        [Route("{StudentId}")]
        public async Task<ActionResult<Student>> GetStudent(int StudentId)
        {
            return await _context.Students.FirstAsync(s => s.StudentId == StudentId);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student s)
        {
            _context.Add(s);
            await _context.SaveChangesAsync();
            return s;
        }

        [HttpPut]
        [Route("{StudentId}")]
        public async Task<ActionResult<Student>> UpdateGroup([FromRoute] int StudentId,
            [FromBody] Student Student)
        {
            var s = await _context.Students.FirstAsync(s => s.StudentId == StudentId);
            s.FullName = Student.FullName;
            s.PhotoUrl = Student.PhotoUrl;
            s.IsCertified = Student.IsCertified;
            s.Grade = Student.Grade;
            s.GroupId = Student.GroupId;
            s.Classes = Student.Classes;
            s.Visits = Student.Visits;
            await _context.SaveChangesAsync();
            return s;
        }

        [HttpDelete]
        [Route("{StudentId}")]
        public async Task<ActionResult> DeleteStudent(int StudentId)
        {
            var s = await _context.Students.FirstAsync(cr => cr.StudentId == StudentId);
            _context.Remove(s);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
