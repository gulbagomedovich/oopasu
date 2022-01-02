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
    public class ClassRoomsController : Controller
    {
        private readonly Context _context;

        public ClassRoomsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassRoom>>> GetClassRooms()
        {
            return await _context.ClassRooms.ToListAsync();
        }

        [HttpGet]
        [Route("{ClassRoomId}")]
        public async Task<ActionResult<ClassRoom>> GetClassRoom(int ClassRoomId)
        {
            return await _context.ClassRooms.FirstAsync(cr => cr.ClassRoomId == ClassRoomId);
        }

        [HttpPost]
        public async Task<ActionResult<ClassRoom>> AddClassRoom(ClassRoom cr)
        {
            _context.Add(cr);
            await _context.SaveChangesAsync();
            return cr;
        }

        [HttpPut]
        [Route("{ClassRoomId}")]
        public async Task<ActionResult<ClassRoom>> UpdateClassRoom([FromRoute] int ClassRoomId,
            [FromBody] ClassRoom ClassRoom)
        {
            var cr = await _context.ClassRooms.FirstAsync(cr => cr.ClassRoomId == ClassRoomId);
            cr.Number = ClassRoom.Number;
            cr.Classes = ClassRoom.Classes;
            await _context.SaveChangesAsync();
            return cr;
        }

        [HttpDelete]
        [Route("{ClassRoomId}")]
        public async Task<ActionResult> DeleteClassRoom(int ClassRoomId)
        {
            var cr = await _context.ClassRooms.FirstAsync(cr => cr.ClassRoomId == ClassRoomId);
            _context.Remove(cr);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
