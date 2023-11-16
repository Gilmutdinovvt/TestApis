using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;

namespace WebApplication7.Context
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        { 
        }
        public DbSet<TASKS> TASKS { get;set;}
    }
}
