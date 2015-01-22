using Abp.EntityFramework;
using Stilago.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Stilago.EntityFramework
{
    public class StilagoDbContext : AbpDbContext
    {
        //Example:
        public virtual IDbSet<Brand> Brands { get; set; }
        public virtual IDbSet<ComputerInfo> ComputerInfos { get; set; }
        public virtual IDbSet<Computer> Computers { get; set; }
        public virtual IDbSet<User> Users { get; set; }
        public virtual IDbSet<Country> Countries { get; set; }

        public StilagoDbContext()
            : base("Default")
        {

        }

        public StilagoDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<ComputerInfo>().ToTable("ComputerInfo");
            modelBuilder.Entity<Computer>().ToTable("Computer");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Country>().ToTable("Country");
        }
    }
}
