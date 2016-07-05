namespace JDynamicsApp.Data.Migrations
{
    using DbContext;
    using Models;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CalculationDbContext>
    {
        public Configuration()
        {
            //uncomment this to run first time
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CalculationDbContext context)
        {
            if (!context.Operations.Any(x => x.Name == "Add"))
            {
                context.Operations.AddOrUpdate(
                  new Operation { Name = "Add", Description = "Add two integers, decimals or long" }                  
                );
                context.SaveChanges();
            }
            if (!context.Operations.Any(x => x.Name == "Subtract"))
            {
                context.Operations.AddOrUpdate(
                  new Operation { Name = "Subtract", Description = "Subtract two integers, decimals or long" }
                );
                context.SaveChanges();
            }
            if (!context.Operations.Any(x => x.Name == "Divide"))
            {
                context.Operations.AddOrUpdate(
                  new Operation { Name = "Divide", Description = "Divide two integers, decimals or long" }
                );
                context.SaveChanges();
            }
            
        }
    }
}
