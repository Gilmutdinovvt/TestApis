using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Context;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("task")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StatusController(ApplicationDbContext context) => _context = context;
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            TASKS tasks = new TASKS()
            {
                Guid = Guid.NewGuid(),
                Status = "Created"
            };
            await _context.TASKS.AddAsync(tasks);
            await  _context.SaveChangesAsync();
            return  AcceptedAtAction(nameof(Create), new { Guid = tasks.Guid });   
        }
        [HttpGet("Guid")]
        public async Task<IActionResult> Get(Guid guid)
        {
            var tasks=_context.TASKS.FirstOrDefaultAsync(t => t.Guid == guid);
            if (guid.GetType() != typeof(Guid))
                {
                return  StatusCode(400);
            }
            return tasks == null ? NotFound() : Ok(tasks.Status);
        }
  

    }
}
