using core.Model;
using System.Data.Entity.Migrations;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.Helper
{
    internal sealed class Configuration : DbMigrationsConfiguration<TestDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "core.Model.TestDBContext";
        }

        protected override void Seed(TestDBContext context)
        {
            context.Info.AddOrUpdate(
             
                   new Info() { Name = "test1", Age=20, IsFemale= false },
                   new Info() {  Name = "test2", Age = 10, IsFemale = false }
               );

            
            base.Seed(context);
        }
    }
}
