namespace SkiResorts.Services
{
    using Models.Resorts;
    using SkiResorts.Data.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IResortService
    {
        void Create(string name, string ownerId);

        Task<IEnumerable<ResortListingServiceModel>> All();

        int GetResortIdOfUser(string userId);

        Task<bool> ResortExistsAsync(int id);

        Task<ResortFormServiceModel> GetResortAsync(int id);

        Task EditResortAsync(string resortName, int id);

        Task DeleteResortAsync(int id);

        Task<bool> IsResortOfUserAsync(int resortId, string username);

        Task<ResortWithFacilitiesServiceModel> GetResortWithFacilities(int id);

        Task<IEnumerable<ResortShortModel>> GetResortsForSelect();

        bool UserHasResort(string userId);
    }
}
