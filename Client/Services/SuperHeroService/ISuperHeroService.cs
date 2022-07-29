global using CRUDApplication.Shared;

namespace CRUDApplication.Client.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        List<SuperHero> Heroes { get; set; }
        List<Comic> Comics { get; set; }
        List<Movie> Movies { get; set; }
        Task GetComics();
        Task GetMovies();
        Task GetSuperHeroes();
        Task <SuperHero> GetSingleSuperHero(int id);
        Task CreateSuperHero(SuperHero hero);
        Task DeleteSuperHero(int id);
        Task UpdateSuperHero(SuperHero hero);

    }
}
