namespace SkiResorts.Services.Implementations
{
    using SkiResorts.Data;
    using SkiResorts.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class EventService : IEventService
    {
        private readonly SkiResortsDbContext db;

        public EventService(SkiResortsDbContext db)
        {
            this.db = db;
        }

        public async Task Create(string name, string description, DateTime date, string managerId, int resortId)
        {
            var eventEntity = new Event
            {
                Name = name,
                Description = description,
                Date = date,
                ManagerId = managerId,
                ResortId = resortId,
            };

            await db.Events.AddAsync(eventEntity);
            await db.SaveChangesAsync();
        }
    }
}
