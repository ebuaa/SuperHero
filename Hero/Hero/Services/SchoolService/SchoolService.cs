using hero_csharp.Data;
using hero_csharp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace hero_csharp.Services.SchoolService
{
    public class SchoolService : ISchoolService
    {
        private readonly DataContext _context;

        public SchoolService(DataContext context)
        {
            _context = context;
        }

        // Récupère la liste de toutes les écoles
        public async Task<List<School>> GetSchoolListAsync()
        {
            return await _context.School.ToListAsync();
        }

        // Récupère une école spécifique par son identifiant
        public School GetSchool(int id)
        {
            return _context.School.Find(id);
        }

        // Ajoute une nouvelle école à la base de données
        public List<School> AddSchool(School school)
        {
            _context.School.Add(school);
            _context.SaveChanges();
            return _context.School.ToList();
        }

        // Met à jour une école existante dans la base de données
        public List<School> UpdateSchool(int id, School request)
        {
            var school = _context.School.Find(id);
            if (school != null)
            {
                school.Name = request.Name;
                _context.School.Update(school);
                _context.SaveChanges();
            }
            return _context.School.ToList();
        }

        // Supprime une école par son identifiant
        public List<School> DeleteSchool(int id)
        {
            var school = _context.School.Find(id);
            if (school != null)
            {
                _context.School.Remove(school);
                _context.SaveChanges();
            }
            return _context.School.ToList();
        }

        // Vérifie si une école existe dans la base de données
        public bool SchoolExists(int id)
        {
            return _context.School.Any(e => e.Id == id);
        }
    }
}