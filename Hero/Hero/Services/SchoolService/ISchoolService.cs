using hero_csharp.Models;

namespace hero_csharp.Services.SchoolService
{
    public interface ISchoolService
    {
        Task<List<School>> GetSchoolListAsync();

        School GetSchool(int id);

        List<School> AddSchool(School school);

        List<School> UpdateSchool(int id, School request);

        List<School> DeleteSchool(int id);

    }
}
