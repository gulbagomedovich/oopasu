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
    public class ClassesController : Controller
    {
        private readonly Context _context;

        public ClassesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        {
            return await _context.Classes.ToListAsync();
        }

        [HttpGet]
        [Route("{ClassId}")]
        public async Task<ActionResult<Class>> GetClass(int ClassId)
        {
            return await _context.Classes.FirstAsync(c => c.ClassId == ClassId);
        }

        [HttpPost]
        public async Task<ActionResult<Class>> AddClass(Class c)
        {
            _context.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        [HttpPut]
        [Route("{ClassId}")]
        public async Task<ActionResult<Class>> UpdateClass([FromRoute] int ClassId,
            [FromBody] Class Class)
        {
            var c = await _context.Classes.FirstAsync(d => d.ClassId == ClassId);
            c.Topic = Class.Topic;
            c.StartDate = Class.StartDate;
            c.EndDate = Class.EndDate;
            c.Status = Class.Status;
            c.GroupId = Class.GroupId;
            c.TeacherId = Class.TeacherId;
            c.ClassRoomId = Class.ClassRoomId;
            c.DisciplineId = Class.DisciplineId;
            c.Visits = Class.Visits;
            c.Students = Class.Students;
            await _context.SaveChangesAsync();
            return c;
        }

        [HttpDelete]
        [Route("{ClassId}")]
        public async Task<ActionResult> DeleteClass(int ClassId)
        {
            var c = await _context.Classes.FirstAsync(c => c.ClassId == ClassId);
            _context.Remove(c);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
