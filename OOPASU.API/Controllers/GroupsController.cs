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
    public class GroupsController : Controller
    {
        private readonly Context _context;

        public GroupsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            return await _context.Groups.ToListAsync();
        }

        [HttpGet]
        [Route("{GroupId}")]
        public async Task<ActionResult<Group>> GetGroup(int GroupId)
        {
            return await _context.Groups.FirstAsync(t => t.GroupId == GroupId);
        }

        [HttpPost]
        public async Task<ActionResult<Group>> AddGroup(Group g)
        {
            _context.Add(g);
            await _context.SaveChangesAsync();
            return g;
        }

        [HttpPut]
        [Route("{GroupId}")]
        public async Task<ActionResult<Group>> UpdateGroup([FromRoute] int GroupId,
            [FromBody] Group Group)
        {
            var g = await _context.Groups.FirstAsync(d => d.GroupId == GroupId);
            g.Code = Group.Code;
            g.Specialization = Group.Specialization;
            g.Classes = Group.Classes;
            g.Students = Group.Students;
            await _context.SaveChangesAsync();
            return g;
        }

        [HttpDelete]
        [Route("{GroupId}")]
        public async Task<ActionResult> DeleteGroup(int GroupId)
        {
            var g = await _context.Groups.FirstAsync(cr => cr.GroupId == GroupId);
            _context.Remove(g);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
