using Microsoft.EntityFrameworkCore;

namespace ReportingTool.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ReportingTool.Models.Fault_Type> Fault_Type { get; set; }
        public DbSet<ReportingTool.Models.Action> Action { get; set; }
        public DbSet<ReportingTool.Models.Route_Call> Route_Call { get; set; }
        public DbSet<ReportingTool.Models.Route_Call> Route { get; set; }
        public DbSet<ReportingTool.Models.Route_Call> Area { get; set; }
    }
}
