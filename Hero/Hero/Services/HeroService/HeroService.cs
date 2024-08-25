using hero_csharp.Models;

namespace hero_csharp.Services.HeroService
{
    public class HeroService : IHeroService
    {
        // Liste statique pour stocker les héros
        private static List<Hero> heroes = new List<Hero>
        {
            new Hero
            {
                Id = 1,
                Name = "Axel",
            },

            new Hero
            {
                Id = 2,
                Name = "Bob",
            },  
        };

        // Méthode pour ajouter un nouveau héros à la liste et retourner la liste mise à jour
        public List<Hero> AddHero(Hero hero)
        {
            heroes.Add(hero);
            return heroes;
        }

        // Méthode pour supprimer un héros par son identifiant
        public List<Hero> DeleteHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero != null)
            {
                heroes.Remove(hero);
            }
            return heroes;
        }

        // Méthode pour obtenir tous les héros de manière asynchrone
        public Task<List<Hero>> GetAllHeroes()
        {
            return Task.FromResult(heroes);
        }

        // Méthode pour obtenir un héros par son identifiant
        public Hero GetHero(int id)
        {
            return heroes.FirstOrDefault(h => h.Id == id);
        }

        // Méthode pour mettre à jour un héros par son identifiant
        public List<Hero> UpdateHero(int id, Hero request)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero != null)
            {
                hero.Name = request.Name;
            }
            return heroes;
        }
    }
}