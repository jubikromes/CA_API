using Application.Entities;
using Application.Enums;

namespace Application.Entities.Access;

public class Feature : BaseEntity
{
    public Guid SubscriptionId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public FeatureType FeatureType { get; set; }
}
