using Application.Entities;
using Application.Enums;

namespace Application.Entities.Access;

public class Pass : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Guid SubscriptionId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public PassState PassState { get; set; }
}
