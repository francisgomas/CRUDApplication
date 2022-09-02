namespace CRUDApplication.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //seeding data to DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SuperHero>().HasData(
                new SuperHero
                {
                    Id = 1,
                    FirstName = "Francis",
                    LastName = "Gomas",
                    HeroName = "Incredible Hulk",
                    ComicId = 1,
                    MovieId = 2,
                },
                new SuperHero
                {
                    Id = 2,
                    FirstName = "Neha",
                    LastName = "Kumar",
                    HeroName = "Wonder Woman",
                    ComicId = 2,
                    MovieId = 1
                }
            );

            modelBuilder.Entity<Comic>().HasData(
                new Comic
                {
                    Id = 1,
                    Name = "Marvel"
                },
                new Comic
                {
                    Id = 2,
                    Name = "DC"
                }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Name = "Avengers End Game"
                },
                new Movie
                {
                    Id = 2,
                    Name = "Batman"
                }
            );
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }
        public DbSet<Comic> Comics { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
