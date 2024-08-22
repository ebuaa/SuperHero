using hero_csharp.Models;

namespace hero_csharp.Services.HeroService
{
    public interface IHeroService
    {
        Task<List<Hero>> GetAllHeroes();

        Hero GetHero(int id);

        List<Hero> AddHero(Hero hero);

        List<Hero> UpdateHero(int id, Hero request);

        List<Hero> DeleteHero(int id);

    }
}
