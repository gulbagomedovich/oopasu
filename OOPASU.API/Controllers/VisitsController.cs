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
    public class VisitsController : Controller
    {
        private readonly Context _context;

        public VisitsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Visit>>> GetVisits()
        {
            return await _context.Visits.ToListAsync();
        }

        [HttpGet]
        [Route("{ClassId}/{StudentId}")]
        public async Task<ActionResult<Visit>> GetVisit([FromRoute] int ClassId,
            [FromRoute] int StudentId)
        {
            return await _context.Visits.FirstAsync(v => v.ClassId == ClassId && v.StudentId == StudentId);
        }

        [HttpPost]
        public async Task<ActionResult<Visit>> AddVisit(Visit v)
        {
            _context.Add(v);
            await _context.SaveChangesAsync();
            return v;
        }

        [HttpPut]
        [Route("{ClassId}/{StudentId}")]
        public async Task<ActionResult<Visit>> UpdateVisit([FromRoute] int ClassId,
            [FromRoute] int StudentId,
            [FromBody] Visit Visit)
        {
            var v = await _context.Visits.FirstAsync(v => v.ClassId == ClassId && v.StudentId == StudentId);
            v.Status = Visit.Status;
            v.ClassId = Visit.ClassId;
            v.StudentId = Visit.StudentId;
            await _context.SaveChangesAsync();
            return v;
        }

        [HttpDelete]
        [Route("{ClassId}/{StudentId}")]
        public async Task<ActionResult> DeleteVisit([FromRoute] int ClassId,
            [FromRoute] int StudentId)
        {
            var v = await _context.Visits.FirstAsync(v => v.ClassId == ClassId && v.StudentId == StudentId);
            _context.Remove(v);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
