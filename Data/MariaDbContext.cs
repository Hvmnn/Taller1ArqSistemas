using GradesService.Models;
using Microsoft.EntityFrameworkCore;

namespace GradesService.Data{
    public class MariaDbContext : DbContext
{
    public MariaDbContext(DbContextOptions<MariaDbContext> options) : base(options)
    {        
    }

    public DbSet<Grades> Grades { get; set; }
}
}