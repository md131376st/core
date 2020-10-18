using core.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace core.Model
{
    public class TestDBContext : DbContext
    {
        static readonly string ConnectionString = @"Data Source=LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                                           AppDomain.CurrentDomain.BaseDirectory +
                                            "TestDB.mdf" +
                                            ";Integrated Security = True;";
        public DbSet<Info> Info { get; set; }
        public TestDBContext()
            : base(ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TestDBContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Info>().ToTable("Info");
        }
        public static TestDBContext Create()
        {
            return new TestDBContext();
        }
        
    }
}
