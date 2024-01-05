namespace Application.Entities;

public class Company : BaseEntity
{
    public string CompanyName { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
}
