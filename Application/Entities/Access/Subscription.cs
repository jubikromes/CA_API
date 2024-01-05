using Application.Entities;
using Application.Enums.Access;
namespace Application.Entities.Access;


public class Subscription : BaseEntity
{
    public string? SubscriptionName { get; set; } //eg.. single access, couple access, family access (of 4)
    public string? Description { get; set; }
    public Duration Duration { get; set; }
    public bool Activated { get; set; }
    public AccessType AccessType { get; set; }
    public decimal Amount { get; set; }
    public int PassAvailable { get; set; }
    public Guid AccessId { get; set; }
    public Access Access { get; set; }
}
