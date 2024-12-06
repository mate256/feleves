using KK12FG_HSZF_2024251.Model;
using Microsoft.EntityFrameworkCore;

namespace KK12FG_HSZF_2024251.Persistence.MsSql
{
    public class PetRegistrationDbContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public PetRegistrationDbContext()
        {
            Database.EnsureDeleted();//ez a későbbiekben nem kell, csak a tesztnél mindig hozzáadja az adatokat
            this.Database.EnsureCreated();
        }

        public PetRegistrationDbContext(DbContextOptions<PetRegistrationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=petregistrationdb;Integrated Security=True;MultipleActiveResultSets=true";
            optionsBuilder.UseSqlServer(connStr);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
