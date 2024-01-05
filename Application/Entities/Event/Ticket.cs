using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Entities.Event
{
    public class Ticket : BaseEntity
    {
        public TicketCategory TicketCategory { get; set; }
        public Guid TicketCategoryId { get; set; }
        public Guid CustomerId { get; set; }
        public int? Seat { get; set; }
    }
}
