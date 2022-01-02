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
    public class DisciplinesController : Controller
    {
        private readonly Context _context;

        public DisciplinesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discipline>>> GetDisciplines()
        {
            return await _context.Disciplines.ToListAsync();
        }

        [HttpGet]
        [Route("{DisciplineId}")]
        public async Task<ActionResult<Discipline>> GetDiscipline(int DisciplineId)
        {
            return await _context.Disciplines.FirstAsync(d => d.DisciplineId == DisciplineId);
        }

        [HttpPost]
        public async Task<ActionResult<Discipline>> AddDiscipline(Discipline d)
        {
            _context.Add(d);
            await _context.SaveChangesAsync();
            return d;
        }

        [HttpPut]
        [Route("{DisciplineId}")]
        public async Task<ActionResult<Discipline>> UpdateDiscipline([FromRoute] int DisciplineId,
            [FromBody] Discipline Discipline)
        {
            var d = await _context.Disciplines.FirstAsync(d => d.DisciplineId == DisciplineId);
            d.Title = Discipline.Title;
            d.Classes = Discipline.Classes;
            await _context.SaveChangesAsync();
            return d;
        }

        [HttpDelete]
        [Route("{DisciplineId}")]
        public async Task<ActionResult> DeleteDiscipline(int DisciplineId)
        {
            var d = await _context.Disciplines.FirstAsync(cr => cr.DisciplineId == DisciplineId);
            _context.Remove(d);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
