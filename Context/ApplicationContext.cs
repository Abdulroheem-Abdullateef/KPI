using KpiNew.Entities;
using Microsoft.EntityFrameworkCore;
namespace KpiNew.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 

        }

        
        public DbSet<Employee> Employees {get; set;}
        public DbSet<KpiResult> KpiResults {get; set;}
        public DbSet<Department> Departments {get; set;}
        public DbSet<KpiForm> KpiForms {get; set;}
        public DbSet<Kpi> Kpis {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<User> Users {get; set;}   
        public DbSet<UserRole> UserRoles {get; set;}
        

    }

}