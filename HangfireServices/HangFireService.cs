using TestApi.HingfireServices;
using WebApplication7.Context;
using WebApplication7.Models;

namespace TestApi.HangfireServices
{
    public class HangFireService : IHangFireServiceManagment
    {
        private readonly ApplicationDbContext _context;
        public HangFireService(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task UpdateDatabase(TASKS tASKS)
        {
            await  Task.Delay(1200);
            tASKS.Status = "Waiting";
            tASKS.DateTime = DateTime.Now;
            _context.Update(tASKS);
            await   _context.SaveChangesAsync();
            await Task.Delay(120000);
            tASKS.Status = "Finished";
            tASKS.DateTime = DateTime.Now;
            _context.Update(tASKS);
            await _context.SaveChangesAsync();
        }
    }
}
