using Microsoft.EntityFrameworkCore;

namespace ReportingTool.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<ReportingTool.Models.Fault_Type> Fault_Type { get; set; }
    }
}
