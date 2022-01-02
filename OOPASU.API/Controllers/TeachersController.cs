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
    public class TeachersController : Controller
    {
        private readonly Context _context;

        public TeachersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        [HttpGet]
        [Route("{TeacherId}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int TeacherId)
        {
            return await _context.Teachers.FirstAsync(t => t.TeacherId == TeacherId);
        }

        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher(Teacher t)
        {
            _context.Add(t);
            await _context.SaveChangesAsync();
            return t;
        }

        [HttpPut]
        [Route("{TeacherId}")]
        public async Task<ActionResult<Teacher>> UpdateTeacher([FromRoute] int TeacherId,
            [FromBody] Teacher Teacher)
        {
            var t = await _context.Teachers.FirstAsync(d => d.TeacherId == TeacherId);
            t.FullName = Teacher.FullName;
            t.Position = Teacher.Position;
            t.Classes = Teacher.Classes;
            await _context.SaveChangesAsync();
            return t;
        }

        [HttpDelete]
        [Route("{TeacherId}")]
        public async Task<ActionResult> DeleteTeacher(int TeacherId)
        {
            var t = await _context.Teachers.FirstAsync(cr => cr.TeacherId == TeacherId);
            _context.Remove(t);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
