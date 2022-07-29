using CRUDApplication.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDApplication.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public SuperHeroController(DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeros()
        {
            var heroes = await _dataContext.SuperHeroes
                .Include(h => h.Comic)
                .Include(j => j.Movie)
                .ToListAsync();
            return Ok(heroes);
        }

        [HttpGet]
        [Route("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _dataContext.Comics.ToListAsync();
            return Ok(comics);
        }

        [HttpGet]
        [Route("movies")]
        public async Task<ActionResult<List<Movie>>> GetMovies()
        {
            var movies = await _dataContext.Movies.ToListAsync();
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = await _dataContext.SuperHeroes
            .Include(i => i.Comic)
            .Include(j => j.Movie)
            .FirstOrDefaultAsync(h => h.Id == id);
            
            if (hero != null)
            {
                return Ok(hero);
            }
            return NotFound("Record not found!");

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateSuperHero(SuperHero hero)
        {
            hero.Comic = null;
            hero.Movie = null;
            _dataContext.SuperHeroes.Add(hero);
            await _dataContext.SaveChangesAsync();
             
            return Ok(await GetDBHeroes());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
        {
            var dbhero = await _dataContext.SuperHeroes
                .Include(h => h.Comic)
                .Include(h => h.Movie)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (dbhero == null)
            {
                return NotFound("Sorry, no record found!");
            }

            dbhero.FirstName = hero.FirstName;
            dbhero.LastName = hero.LastName;
            dbhero.HeroName = hero.HeroName;
            dbhero.ComicId = hero.ComicId;
            dbhero.MovieId = hero.MovieId;
           
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBHeroes());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
        {
            var dbhero = await _dataContext.SuperHeroes
                .Include(h => h.Comic)
                .Include(h => h.Movie)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (dbhero == null)
            {
                return NotFound("Sorry, no record found!");
            }

           _dataContext.SuperHeroes.Remove(dbhero);

            await _dataContext.SaveChangesAsync();

            return Ok(await GetDBHeroes());
        }

        private async Task<List<SuperHero>> GetDBHeroes()
        {
            return await _dataContext.SuperHeroes
                .Include(h => h.Comic)
                .Include(h => h.Movie)
                .ToListAsync();
        }


    }
}
