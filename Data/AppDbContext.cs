using Microsoft.EntityFrameworkCore;

namespace SkyProject.Data;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees{ get; set; }
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

}