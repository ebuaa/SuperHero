using hero_csharp.Services.HeroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using hero_csharp.Models;

namespace hero_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroService _heroService;

        public HeroController(IHeroService heroService)
        {
            _heroService = heroService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Hero>>> GetAllHeroes()
        {
            var result = _heroService.GetAllHeroes();
            if (result is null)
                return NotFound("Heroes not found");
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<Hero>>> AddHero(Hero hero)
        {
            var result = _heroService.AddHero(hero);
            if (result is null)
                return NotFound("Heroes not found");
            return Ok(result);
        }

    }
}
