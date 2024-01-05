using Application.Interfaces.Repository.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Event
{
    public class EventRepository : BaseRepository<Application.Entities.Event.Event>, IEventRepository
    {
        public EventRepository(ConfamAppDbContext context) : base(context)
        {
        }
    }
}
