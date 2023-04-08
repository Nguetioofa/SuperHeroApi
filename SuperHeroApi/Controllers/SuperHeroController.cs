using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController( DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id); /*(from h in _context.SuperHeroes
                              where h.Id == id
                              select h).FirstOrDefaultAsync();*/

            if (hero == null)
                return BadRequest("Hero Not Found.");

            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero newHero)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(newHero.Id);
            if (dbhero == null)
                return BadRequest("Hero Not Found.");

            dbhero.Name = newHero.Name;
            dbhero.FristName=newHero.FristName;
            dbhero.LastName = newHero.LastName;
            dbhero.Place = newHero.Place;

            await _context.SaveChangesAsync();

            return Ok(dbhero);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero == null)
                return BadRequest("Hero Not Found.");
              _context.SuperHeroes.Remove(hero);

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
