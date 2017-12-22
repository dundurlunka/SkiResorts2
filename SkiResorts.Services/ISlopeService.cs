namespace SkiResorts.Services
{
    using Data.Models;
    using Models.Slopes;
    using System.Threading.Tasks;

    public interface ISlopeService
    {
        Task CreateAsync(string name, int length, SlopeDifficulty slopeDifficulty, Status status, string userId);

        Task<bool> SlopeExistsAsync(int id);

        Task<SlopeFormServiceModel> GetSlopeFormModelAsync(int id);

        Task DeleteSlopeAsync(int id);

        Task<bool> IsSlopeOfUserAsync(int slopeId, string username);

        Task<bool> EditAsync(string name, int length, SlopeDifficulty slopeDifficulty, Status status, int slopeId);
    }
}
