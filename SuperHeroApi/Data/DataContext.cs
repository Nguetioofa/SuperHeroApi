using Microsoft.EntityFrameworkCore;


namespace SuperHeroApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) {  }

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
