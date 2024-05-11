using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new MealConfiguration());
            modelBuilder.ApplyConfiguration(new MachineTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MachineStatusConfiguration());
            modelBuilder.ApplyConfiguration(new ManufacturerConfiguration());
        }

        public DbSet<Company>? Companies { get; set; }
        public DbSet<Machine>? Machines { get; set; }
        public DbSet<MachineStatus>? MachineStatuses { get; set; }
        public DbSet<MachineType>? MachineTypes { get; set; }
        public DbSet<MachineSettings>? MachineSettings { get; set; }
        public DbSet<Manufacturer>? Manufacturers { get; set; }
        public DbSet<Meal>? Meals { get; set; }
        public DbSet<Order>? Order { get; set; }
    }
}
