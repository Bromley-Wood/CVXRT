using Microsoft.EntityFrameworkCore;

namespace ReportingTool.Models
{
    public class ActionsDbContext : DbContext
    {
        public DbSet<Action> Actions { get; set; }

        public ActionsDbContext(DbContextOptions<ActionsDbContext> options)
            : base(options)
        {
            //this.EnsureSeedData();
        }
    }
}
