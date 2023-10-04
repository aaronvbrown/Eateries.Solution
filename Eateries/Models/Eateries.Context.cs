using Microsoft.EntityFrameworkCore;

namespace Eateries.Models
{
  public class EateriesContext : DbContext
  {
    public DbSet<Cuisine> Cuisine { get; set; }
    public DbSet<Restaurants> Restaurants { get; set; }

    public EateriesContext(DbContextOptions options) : base(options) { }
  }
}