namespace SkiResorts.Services
{
    using Models.Admin;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAdminUserService
    {
        Task<IEnumerable<UserListingServiceModel>> GetAllUsersAsync();
    }
}
