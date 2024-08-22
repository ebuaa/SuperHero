using hero_csharp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace hero_csharp.Services.HeroService
{
    public class HeroService : IHeroService
    {
        private static List<Hero> heroes = new List<Hero>
        {
            new Hero
            {
                Id = 1,
                superpower = "Flying",
                name = "Axel",
            },
        };
        public List<Hero> AddHero(Hero hero)
        {
            heroes.Add(hero);

        }

        public List<Hero> DeleteHero(int id)
        {
        }

        public Task<List<Hero>> GetAllHeroes(Task<List<Hero>> heroes)
        {
            return heroes;
        }

        public Task<List<Hero>> GetAllHeroes()
        {
            throw new NotImplementedException();
        }

        public Hero GetHero(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hero> UpdateHero(int id, Hero request)
        {
            throw new NotImplementedException();
        }
        CrefBracketedParameterListSyntax 

    }
}
