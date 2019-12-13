using Microsoft.EntityFrameworkCore;

namespace ReportingTool.Models
{
    public class DatabaseContext : DbContext
    {
        
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        // HasNoKey needs to be specified for Views
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<V_Route_Machines>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("V_Route_Machines");
            });
        }


        public DbSet<ReportingTool.Models.Route_Call> Route_Call { get; set; }
        public DbSet<ReportingTool.Models.Missed_Survey> Missed_Survey { get; set; }
        public virtual DbSet<ReportingTool.Models.V_Route_Machines> V_Route_Machines { get; set; }
    }
}
