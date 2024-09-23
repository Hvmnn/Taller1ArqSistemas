using Microsoft.EntityFrameworkCore;

public class MariaDbContext : DbContext
{
    public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
    {        
    }

    public DbSet<Grades> Grades { get; set; }
}