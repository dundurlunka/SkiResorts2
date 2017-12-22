namespace SkiResorts.Services
{
    using SkiResorts.Data.Models;
    using SkiResorts.Services.Models.Lifts;
    using System.Threading.Tasks;

    public interface ILiftService
    {
        Task CreateAsync(string name, int capacity, int seats, int verticalDrop, int length, Status status, string userId);

        Task<bool> LiftExistsAsync(int id);

        Task<bool> IsLiftOfUserAsync(int liftId, string username);

        Task<Lift> GetLiftAsync(int liftId);

        Task<LiftFormServiceModel> GetLiftFormModelAsync(int liftId);

        Task Edit(string name, int capacity, int seats, int verticalDrop, Status status, int length, int liftId);

        Task DeleteAsync(int liftId);
    }
}
