using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.HingfireServices;
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
            TASKS task = new TASKS()
            {
                Guid = Guid.NewGuid(),
                Status = "Created"
            };
            await _context.TASKS.AddAsync(task);
            await  _context.SaveChangesAsync();
            var jobId= BackgroundJob.Enqueue<IHangFireServiceManagment>(x=>x.UpdateDatabase(task));
            return AcceptedAtAction(nameof(Create), new { task.Guid });   
        }
        [HttpGet("Guid")]
        public async Task<IActionResult> Get(Guid guid)
        {
            var tasks= await _context.TASKS.FirstOrDefaultAsync(t => t.Guid == guid);
            if (guid.GetType() != typeof(Guid))
                {
                return  StatusCode(400);
            }
            return tasks == null ? NotFound() : Ok(tasks.Status);
        }
    }
}
