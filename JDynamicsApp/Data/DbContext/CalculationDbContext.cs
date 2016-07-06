namespace JDynamicsApp.Data.DbContext
{
    using Migrations;
    using Models;
    using System.Data.Entity;

    public class CalculationDbContext : DbContext
    {        
        public CalculationDbContext()
            : base("name=Calculation")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CalculationDbContext, Configuration>("Calculation"));
        }       

        public virtual DbSet<CalculationResult> Calculations { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        //public virtual DbSet<Operation> Users { get; set; }

    }   
}