namespace SkiResorts.Services
{
    using SkiResorts.Data.Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> UserHasResortAsync(string id);

        Task<User> GetUserAsync(string id);
    }
}
