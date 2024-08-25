using hero_csharp.Models;

namespace hero_csharp.Services.SuperPowerService
{
    public interface ISuperPowerService
    {
        Task<List<SuperPower>> GetSuperPowerListAsync();

        SuperPower GetSuperPower(int id);

        List<SuperPower> AddSuperPower(SuperPower superPower);

        List<SuperPower> UpdateSuperPower(int id, SuperPower request);
        
        List<SuperPower> DeleteSuperPower(int id);
    }
}
