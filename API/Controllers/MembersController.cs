using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")] // localhost:5236/api/members
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }

        [HttpGet("{id}")] // localhost:5236/api/members/bob-id 
        public async Task<ActionResult<AppUser>> GetMembers(string id)
        {
            var member = await context.Users.FindAsync(id);

            if (member == null) return NotFound();

            return member;
        }
    }
}
