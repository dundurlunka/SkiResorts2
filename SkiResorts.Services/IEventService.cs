namespace SkiResorts.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IEventService
    {
        Task Create(string name, string description, DateTime date, string managerId, int resortId);
    }
}
